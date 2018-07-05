using AccessoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls.GridView;

namespace Medica2.Farmacia.Materiales
{
    /// <summary>
    /// Lógica de interacción para SolicitudDoctor.xaml
    /// </summary>
    public partial class SolicitudDoctor : Window
    {
        DateTime fechareg = DateTime.Now;
        int idsol;
        Decimal total;
        int idUsuario;
        public SolicitudDoctor()
        {
            InitializeComponent();
            llenarAutocompletes();
        }

        public SolicitudDoctor(int idu)
        {
            InitializeComponent();
            llenarAutocompletes();
            idUsuario = idu;
        }

        public SolicitudDoctor(int ids, int idmedic)
        {
            InitializeComponent();
            llenarAutocompletes();
            idsol = ids;
            var m = BaseDatos.GetBaseDatos().MEDICOS.Find(idmedic);

            var solicitud = BaseDatos.GetBaseDatos().MATERIALES_DOCTORES.Find(idsol);
            autoMedico.SearchText = m.PERSONA.NOMBRE + " " + m.PERSONA.A_PATERNO + " " + m.PERSONA.A_MATERNO;
            autoMedico.IsEnabled = false;
            btnNuevaSolicitud.IsEnabled = false;
            autoMaterial.IsEnabled = true;
            txtCantidad.IsEnabled = true;
            btnAgregar.IsEnabled = true;
            VistaGrid();
            total = Decimal.Parse(solicitud.TOTAL.ToString());
            btnFinalizar.IsEnabled = true;
        }

        private void validarLetras(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        private void validarNumeros(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 4 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void validarNumLetras(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 46)

                e.Handled = false;

            else e.Handled = true;
        }

        void VistaGrid()
        {
            rgvDetalle.ItemsSource = (from MATERIALES_DOCTORES in BaseDatos.GetBaseDatos().MATERIALES_DOCTORES
                                      join detalle in BaseDatos.GetBaseDatos().DETALLE_MATER_DOCTORES
                                      on MATERIALES_DOCTORES.ID_MATERIAL equals detalle.MATERIALES_DOCTORESID
                                      join medicamento in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                      on detalle.MATERIALID equals medicamento.ID_MEDICAMENTO
                                      where MATERIALES_DOCTORES.ID_MATERIAL == idsol
                                      select new
                                      {
                                          ID_SOLICITUD = MATERIALES_DOCTORES.ID_MATERIAL,
                                          ID_DETALLE_MATER_DOCTORES = detalle.ID_DETALLE_MATER_DOCTOR,
                                          ID_MEDICAMENTO = medicamento.ID_MEDICAMENTO,
                                          NOMMEDI = medicamento.NOMBRE_MEDI,
                                          UMEDIDA = medicamento.U_MEDIDA,
                                          CANTIDAD = detalle.CANTIDAD,
                                          COSTO = medicamento.P_COMPRA
                                      }).ToList();
        }

        void llenarAutocompletes()
        {
            autoMedico.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                      join e in BaseDatos.GetBaseDatos().MEDICOS
                                      on PERSONA.ID_PERSONA equals e.PERSONAID
                                      where PERSONA.ESTADOPERSONA == "Activo"
                                      select new
                                      {
                                          ID_MEDICO = e.ID_MEDICO,
                                          NOMBRE = PERSONA.NOMBRE + " " + PERSONA.A_PATERNO + " " + PERSONA.A_MATERNO
                                      }).ToList();

            autoMaterial.ItemsSource = (from CATALOGO_MEDICAMENTOS in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                        where CATALOGO_MEDICAMENTOS.ALMACEN == "Materiales" && CATALOGO_MEDICAMENTOS.STATUS == "Activo"
                                        select new
                                        {
                                            ID_MATERIAL = CATALOGO_MEDICAMENTOS.ID_MEDICAMENTO,
                                            NOMBRE = CATALOGO_MEDICAMENTOS.NOMBRE_MEDI + " " + CATALOGO_MEDICAMENTOS.COMENTARIO + " " + CATALOGO_MEDICAMENTOS.U_MEDIDA,
                                            EXISTENCIAS = CATALOGO_MEDICAMENTOS.CADUCIDAD
                                        }).ToList();
        }

        void limpiar()
        {
            autoMaterial.SearchText = String.Empty;
            txtUMedida.Text = String.Empty;
            txtCosto.Text = String.Empty;
            txtCantidad.Text = String.Empty;
            txtExistencias.Text = String.Empty;
        }

        void Bloquear()
        {
            btnNuevaSolicitud.IsEnabled = true;
            autoMaterial.IsEnabled = false;
            txtCantidad.IsEnabled = false;
            txtCosto.IsEnabled = false;
            txtUMedida.IsEnabled = false;
            btnAgregar.IsEnabled = false;
            btnFinalizar.IsEnabled = false;
            total = 0;
            autoMedico.SearchText = String.Empty;
            autoMedico.IsEnabled = true;
            idsol = 0;
            VistaGrid();
        }

        void llenar()
        {
            if (autoMaterial.SelectedItem != null)
            {
                dynamic material = autoMaterial.SelectedItem;
                int idm = material.ID_MATERIAL;
                var medicamento = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                txtUMedida.Text = medicamento.U_MEDIDA;
                txtCosto.Text = medicamento.P_COMPRA.ToString();
                txtExistencias.Text = medicamento.CANTIDAD.ToString();
            }

        }

        void Guardar()
        {
            if (autoMedico.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un medico");
            }else
            {
                dynamic medico = autoMedico.SelectedItem;
                int idmedico = medico.ID_MEDICO;
                MATERIALES_DOCTORES md = new MATERIALES_DOCTORES
                {
                    USUARIOID = idUsuario,
                    DOCTORID = idmedico,
                    FECHA_CREACION = fechareg
                };
                BaseDatos.GetBaseDatos().MATERIALES_DOCTORES.Add(md);
                BaseDatos.GetBaseDatos().SaveChanges();
                idsol = md.ID_MATERIAL;

                btnNuevaSolicitud.IsEnabled = false;
                autoMedico.IsEnabled = false;
                btnAgregar.IsEnabled = true;
                autoMaterial.IsEnabled = true;
                txtCantidad.IsEnabled = true;
            }
        }

        void Agregar()
        {
            if (autoMaterial.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un material");
            }else
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Ingresa una cantidad");
                }else
                {
                    dynamic matt = autoMaterial.SelectedItem;
                    int idmaterial = matt.ID_MATERIAL;
                    var material = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmaterial);
                    if (material.CANTIDAD == 0)
                    {
                        MessageBox.Show("Se agotaron las existencias");
                    }else
                    {
                        if (Int32.Parse(txtCantidad.Text) <= material.CANTIDAD)
                        {
                            DETALLE_MATER_DOCTORES dm = new DETALLE_MATER_DOCTORES
                            {
                                MATERIALES_DOCTORESID = idsol,
                                MATERIALID = idmaterial,
                                CANTIDAD = Int32.Parse(txtCantidad.Text),
                                COSTO = Decimal.Parse(txtCosto.Text),
                                FECHA_CREACION = fechareg
                            };
                            BaseDatos.GetBaseDatos().DETALLE_MATER_DOCTORES.Add(dm);
                            BaseDatos.GetBaseDatos().SaveChanges();

                            //Actualizamos Existencias
                            material.CANTIDAD = material.CANTIDAD - (Int32.Parse(txtCantidad.Text));
                            BaseDatos.GetBaseDatos().SaveChanges();

                            //Almacenamos el total
                            total = total + (Int32.Parse(txtCantidad.Text) * Decimal.Parse(txtCosto.Text));

                            //Llenamos la datagrid
                            VistaGrid();

                            //Limpiamos
                            limpiar();

                            //Habilitamos el boton de finalizar
                            btnFinalizar.IsEnabled = true;


                        }
                        else
                        {
                            MessageBox.Show("Solo hay en existencia: " + material.CANTIDAD);
                        }
                    }
                }
            }
        }

        void Finalizar()
        {
            var solicitud = BaseDatos.GetBaseDatos().MATERIALES_DOCTORES.Find(idsol);
            solicitud.TOTAL = total;
            BaseDatos.GetBaseDatos().SaveChanges();
            MessageBox.Show("Se finalizó la solicitud correctamente");
            Bloquear();
        }

        void Actualizar()
        {
            dynamic detalleSol = rgvDetalle.SelectedItem;
            int iddetalle = detalleSol.ID_DETALLE_MATER_DOCTORES;
            if (rgvDetalle.SelectedItem != null)
            {
                var detalleMaterial = BaseDatos.GetBaseDatos().DETALLE_MATER_DOCTORES.Find(iddetalle);

                //Actualizar existencias
                int idmate = detalleSol.ID_MEDICAMENTO;
                var material = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmate);
                material.CANTIDAD = material.CANTIDAD + detalleMaterial.CANTIDAD;
                BaseDatos.GetBaseDatos().SaveChanges();

                //Actualizamos el total
                total = total - (Decimal.Parse(detalleMaterial.CANTIDAD.ToString()) * Decimal.Parse(detalleMaterial.COSTO.ToString()));

                //Eliminar el suministro
                BaseDatos.GetBaseDatos().DETALLE_MATER_DOCTORES.Remove(detalleMaterial);
                BaseDatos.GetBaseDatos().SaveChanges();
                VistaGrid();

            }
        }

        void Editar()
        {
            if (rgvDetalle.SelectedItem != null)
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Ingresa una cantidad");
                }
                else
                {
                    dynamic medi = autoMaterial.SelectedItem;
                    int idma = medi.ID_MATERIAL;
                    var mediexistencia = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idma);
                    if (mediexistencia.CANTIDAD == 0)
                    {
                        MessageBox.Show("Se agotarion las existencias");
                    }
                    else
                    {
                        if (Int32.Parse(txtCantidad.Text) <= mediexistencia.CANTIDAD)
                        {
                            dynamic detalle = rgvDetalle.SelectedItem;
                            int iddetalle = detalle.ID_DETALLE_MATER_DOCTORES;
                            var detalleSolicitud = BaseDatos.GetBaseDatos().DETALLE_MATER_DOCTORES.Find(iddetalle);

                            //Actualizamos el detalle medicamento
                            dynamic materia = autoMaterial.SelectedItem;
                            int idm = materia.ID_MATERIAL;
                            detalleSolicitud.MATERIALID = idm;
                            detalleSolicitud.CANTIDAD = Int32.Parse(txtCantidad.Text);
                            detalleSolicitud.COSTO = Decimal.Parse(txtCosto.Text);
                            BaseDatos.GetBaseDatos().SaveChanges();

                            //Actualizamos las existencias
                            var materi = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                            materi.CANTIDAD = materi.CANTIDAD - (Int32.Parse(txtCantidad.Text));

                            //Actualizamos el total
                            total = total + (Int32.Parse(txtCantidad.Text) * (Decimal.Parse(txtCosto.Text)));

                            //Se actualizan los botones 
                            btnEditar.Visibility = Visibility.Hidden;
                            btnAgregar.Visibility = Visibility.Visible;
                            btnFinalizar.IsEnabled = true;
                            VistaGrid();
                            limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Solo hay en existencia: " + mediexistencia.CANTIDAD.ToString());
                        }
                    }
                }
            }
        }

        private GridViewRow ClickedRow
        {
            get
            {
                return this.GridContextMenu2.GetClickedElement<GridViewRow>();
            }
        }

        private void GridContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            if (ClickedRow != null)
            {
                itemEliminar.IsEnabled = true;
                itemEditar.IsEnabled = true;
            }
        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemEliminar)
            {
                //
                MessageBoxResult result = MessageBox.Show("¿Está seguro de eliminar el material?", "Farmacia", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Actualizar();
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                if (sender == itemEditar)
                {
                    if (rgvDetalle.SelectedItem != null)
                    {
                        btnFinalizar.IsEnabled = false;
                        btnAgregar.Visibility = Visibility.Hidden;
                        btnEditar.Visibility = Visibility.Visible;

                        //Se busca el detalle suministro
                        dynamic detalle = rgvDetalle.SelectedItem;
                        int iddetalle = detalle.ID_DETALLE_MATER_DOCTORES;
                        var detalleSolicitud = BaseDatos.GetBaseDatos().DETALLE_MATER_DOCTORES.Find(iddetalle);
                        int idm = detalleSolicitud.MATERIALID;

                        //Se actualizan las existencias
                        var exi = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                        exi.CANTIDAD = exi.CANTIDAD + detalleSolicitud.CANTIDAD;

                        //Asigna los valores a los txt
                        var material = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                        txtCantidad.Text = detalleSolicitud.CANTIDAD.ToString();

                        //Se actualizan los totales
                        total = total - (Decimal.Parse(detalleSolicitud.CANTIDAD.ToString()) * Decimal.Parse(detalleSolicitud.COSTO.ToString()));

                        //autoMedicamentos.TextSearchPath = detalleSuministro.MEDICAMENTOID.ToString();
                        autoMaterial.SearchText = material.NOMBRE_MEDI;
                        llenar();
                    }
                }
            }
        }

        private void btnNuevaSolicitud_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Agregar();
        }

        private void autoMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            llenar();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            Finalizar();
        }
    }
}
