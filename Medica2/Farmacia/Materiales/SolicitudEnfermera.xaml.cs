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
    /// Lógica de interacción para SolicitudEnfermera.xaml
    /// </summary>
    public partial class SolicitudEnfermera : Window
    {
        DateTime fechareg = DateTime.Now;
        int idsol;
        Decimal total;

        public SolicitudEnfermera()
        {
            InitializeComponent();
            llenarAutocompletes();
        }

        public SolicitudEnfermera(int idso, int ide)
        {
            InitializeComponent();
            llenarAutocompletes();
            idsol = idso;

            var enferm = BaseDatos.GetBaseDatos().ENFERMERAS.Find(ide);
            var solicitud = BaseDatos.GetBaseDatos().MATERIALES_ENFERMERAS.Find(idsol);
            autoEnfermera.SearchText = enferm.PERSONA.NOMBRE + " " + enferm.PERSONA.A_PATERNO + " " + enferm.PERSONA.A_MATERNO;
            autoEnfermera.IsEnabled = false;
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
            rgvDetalle.ItemsSource = (from MATERIALES_ENFERMERAS in BaseDatos.GetBaseDatos().MATERIALES_ENFERMERAS
                                      join detalle in BaseDatos.GetBaseDatos().DETALLE_MATER_ENFERMERAS
                                      on MATERIALES_ENFERMERAS.ID_MATERIAL equals detalle.MATERIALES_ENFERMERASID
                                      join medicamento in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                      on detalle.MATERIALID equals medicamento.ID_MEDICAMENTO
                                      where MATERIALES_ENFERMERAS.ID_MATERIAL == idsol
                                      select new
                                      {
                                          ID_SOLICITUD = MATERIALES_ENFERMERAS.ID_MATERIAL,
                                          ID_DETALLE_MATER_ENFERMERA = detalle.ID_DETALLE_MATER_ENFERMERA,
                                          ID_MEDICAMENTO = medicamento.ID_MEDICAMENTO,
                                          NOMMEDI = medicamento.NOMBRE_MEDI,
                                          UMEDIDA = medicamento.U_MEDIDA,
                                          CANTIDAD = detalle.CANTIDAD,
                                          COSTO = medicamento.P_COMPRA
                                      }).ToList();
        }

        void llenarAutocompletes()
        {
            autoEnfermera.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                      join e in BaseDatos.GetBaseDatos().ENFERMERAS
                                      on PERSONA.ID_PERSONA equals e.PERSONAID
                                      where PERSONA.ESTADOPERSONA == "Activo"
                                      select new
                                      {
                                          ID_ENFERMERA = e.ID_ENFERMERA,
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
            autoMaterial.SearchText = String.Empty;
            txtCantidad.IsEnabled = false;
            txtCantidad.Text = String.Empty;
            txtCosto.IsEnabled = false;
            txtCosto.Text = String.Empty;
            txtUMedida.IsEnabled = false;
            txtUMedida.Text = String.Empty;
            btnAgregar.IsEnabled = false;
            btnFinalizar.IsEnabled = false;
            total = 0;
            autoEnfermera.SearchText = String.Empty;
            autoEnfermera.IsEnabled = true;
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
            if (autoEnfermera.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una enfermera");
            }
            else
            {
                dynamic enfermera = autoEnfermera.SelectedItem;
                int idenfermera = enfermera.ID_ENFERMERA;
                MATERIALES_ENFERMERAS md = new MATERIALES_ENFERMERAS
                {
                    USUARIOID = 2,
                    ENFERMERAID = idenfermera,
                    FECHA_CREACION = fechareg
                };
                BaseDatos.GetBaseDatos().MATERIALES_ENFERMERAS.Add(md);
                BaseDatos.GetBaseDatos().SaveChanges();
                idsol = md.ID_MATERIAL;

                btnNuevaSolicitud.IsEnabled = false;
                autoEnfermera.IsEnabled = false;
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
            }
            else
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Ingresa una cantidad");
                }
                else
                {
                    dynamic matt = autoMaterial.SelectedItem;
                    int idmaterial = matt.ID_MATERIAL;
                    var material = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmaterial);
                    if (material.CANTIDAD == 0)
                    {
                        MessageBox.Show("Se agotaron las existencias");
                        autoMaterial.SearchText = String.Empty;
                        txtCantidad.Text = String.Empty;
                        txtCosto.Text = String.Empty;
                        txtUMedida.Text = String.Empty;
                    }
                    else
                    {
                        if (Int32.Parse(txtCantidad.Text) <= material.CANTIDAD)
                        {
                            DETALLE_MATER_ENFERMERAS dm = new DETALLE_MATER_ENFERMERAS
                            {
                                MATERIALES_ENFERMERASID = idsol,
                                MATERIALID = idmaterial,
                                CANTIDAD = Int32.Parse(txtCantidad.Text),
                                COSTO = Decimal.Parse(txtCosto.Text),
                                FECHA_CREACION = fechareg,
                                SUBTOTAL = Int32.Parse(txtCantidad.Text) * Decimal.Parse(txtCosto.Text)
                            };
                            BaseDatos.GetBaseDatos().DETALLE_MATER_ENFERMERAS.Add(dm);
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
            var solicitud = BaseDatos.GetBaseDatos().MATERIALES_ENFERMERAS.Find(idsol);
            solicitud.TOTAL = total;
            BaseDatos.GetBaseDatos().SaveChanges();
            MessageBox.Show("Se finalizó la solicitud correctamente");
            Bloquear();
        }

        void Actualizar()
        {
            dynamic detalleSol = rgvDetalle.SelectedItem;
            int iddetalle = detalleSol.ID_DETALLE_MATER_ENFERMERA;
            if (rgvDetalle.SelectedItem != null)
            {
                var detalleMaterial = BaseDatos.GetBaseDatos().DETALLE_MATER_ENFERMERAS.Find(iddetalle);

                //Actualizar existencias
                int idmate = detalleSol.ID_MEDICAMENTO;
                var material = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmate);
                material.CANTIDAD = material.CANTIDAD + detalleMaterial.CANTIDAD;
                BaseDatos.GetBaseDatos().SaveChanges();

                //Actualizamos el total
                total = total - (Decimal.Parse(detalleMaterial.SUBTOTAL.ToString()));

                //Eliminar el suministro
                BaseDatos.GetBaseDatos().DETALLE_MATER_ENFERMERAS.Remove(detalleMaterial);
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
                            int iddetalle = detalle.ID_DETALLE_MATER_ENFERMERA;
                            var detalleSolicitud = BaseDatos.GetBaseDatos().DETALLE_MATER_ENFERMERAS.Find(iddetalle);

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

                            //Actualizamos el subtotal
                            detalleSolicitud.SUBTOTAL = (Int32.Parse(txtCantidad.Text) * (Decimal.Parse(txtCosto.Text)));

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
                        int iddetalle = detalle.ID_DETALLE_MATER_ENFERMERA;
                        var detalleSolicitud = BaseDatos.GetBaseDatos().DETALLE_MATER_ENFERMERAS.Find(iddetalle);
                        int idm = detalleSolicitud.MATERIALID;

                        //Se actualizan las existencias
                        var exi = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                        exi.CANTIDAD = exi.CANTIDAD + detalleSolicitud.CANTIDAD;
                        
                        //Asigna los valores a los txt
                        var material = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                        txtCantidad.Text = detalleSolicitud.CANTIDAD.ToString();

                        //Se actualizan los totales
                        total = total - (Decimal.Parse(detalleSolicitud.SUBTOTAL.ToString()));

                        //autoMedicamentos.TextSearchPath = detalleSuministro.MEDICAMENTOID.ToString();
                        autoMaterial.SearchText = material.NOMBRE_MEDI;
                        llenar();
                    }
                }
            }
        }
        //

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
