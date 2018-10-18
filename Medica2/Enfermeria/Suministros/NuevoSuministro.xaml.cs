using AccessoDB;
using Medica2.Enfermeria.Pacientes;
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

namespace Medica2.Enfermeria.Suministros
{
    /// <summary>
    /// Lógica de interacción para NuevoSuministro.xaml
    /// </summary>
    public partial class NuevoSuministro : Window
    {
        private int idpaciente;
        int idsumi;
        int idcuenta;
        DateTime fechac = DateTime.Now;
        Decimal total = 0;
        Decimal totalEditar = 0;
        int idUsuario;
        public NuevoSuministro()
        {
            InitializeComponent();
            
        }

        public NuevoSuministro(int idpac, String cuar, int idcuen, int idu)
        {
            InitializeComponent();
            idpaciente = idpac;
            idcuenta = idcuen;
            idUsuario = idu;
            var paciente = BaseDatos.GetBaseDatos().PACIENTES.Find(idpaciente);
            txtPaciente.Text = paciente.PERSONA.NOMBRE;
            txtHabitacion.Text = cuar.ToString();
            llenarAutocompletes();
            Guardar();
            VistaGrid();
        }

        //constructor para editar
        public NuevoSuministro(int s, int p, String c, Decimal t, int idc, int idu)
        {
            InitializeComponent();
            idpaciente = p;
            idcuenta = idc;
            idUsuario = idu;
            idsumi = s;
            total = t;
            totalEditar = t;
            var paciente = BaseDatos.GetBaseDatos().PACIENTES.Find(idpaciente);
            txtPaciente.Text = paciente.PERSONA.NOMBRE;
            txtHabitacion.Text = c.ToString();
            llenarAutocompletes();
            VistaGrid();
        }

        void llenarAutocompletes()
        {
            autoMedicamentos.ItemsSource = (from medi in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                            where medi.STATUS == "Activo"
                                            select new
                                            {
                                                ID_MEDICAMENTO = medi.ID_MEDICAMENTO,
                                                NOMBRE = medi.NOMBRE_MEDI + " " + medi.COMENTARIO + " " + medi.U_MEDIDA
                                            });
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
            ///

        }

        void VistaGrid()
        {
            rgvDetalle.ItemsSource = (from SUMINISTROS_MEDICAMENTOS in BaseDatos.GetBaseDatos().SUMINISTROS_MEDICAMENTOS
                                      join detalle in BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS
                                      on SUMINISTROS_MEDICAMENTOS.ID_SUMINISTRO_MEDICAMENTO equals detalle.SUMINISTRO_MEDICAMENTOID
                                      join medicamento in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                      on detalle.MEDICAMENTOID equals medicamento.ID_MEDICAMENTO
                                      where SUMINISTROS_MEDICAMENTOS.ID_SUMINISTRO_MEDICAMENTO == idsumi
                                      select new
                                      {
                                          ID_SUMINISTRO = SUMINISTROS_MEDICAMENTOS.ID_SUMINISTRO_MEDICAMENTO,
                                          ID_DETALLE_SUMINISTRO = detalle.ID_DETALLE_SUMINISTRO,
                                          ID_MEDICAMENTO = medicamento.ID_MEDICAMENTO,
                                          NOMMEDI = medicamento.NOMBRE_MEDI,
                                          UMEDIDA = medicamento.U_MEDIDA,
                                          CANTIDAD = detalle.CANTIDAD
                                      }).ToList();
        }

        void llenar()
        {
            if (autoMedicamentos.SelectedItem != null)
            {
                dynamic medi = autoMedicamentos.SelectedItem;
                int idm = medi.ID_MEDICAMENTO;
                var medicamento = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                txtUMedida.Text = medicamento.U_MEDIDA;
                txtPrecio.Text = medicamento.P_VENTA.ToString();
                txtExistencias.Text = medicamento.CANTIDAD.ToString();
            }

        }

        void Limpiar()
        {
            autoMedicamentos.SearchText = String.Empty;
            autoMedicamentos.SelectedItem = null;
            txtPrecio.Text = String.Empty;
            txtUMedida.Text = String.Empty;
            txtCantidad.Text = String.Empty;
            txtExistencias.Text = String.Empty;
        }

        void Guardar()
        {
            SUMINISTROS_MEDICAMENTOS sm = new SUMINISTROS_MEDICAMENTOS
            {
                CUENTAID = idcuenta,
                USUARIOID = idUsuario,
                FECHA_CREACION = fechac,
                TOTAL = 0
            };
            BaseDatos.GetBaseDatos().SUMINISTROS_MEDICAMENTOS.Add(sm);
            BaseDatos.GetBaseDatos().SaveChanges();

            idsumi = sm.ID_SUMINISTRO_MEDICAMENTO;
        }

        void GuardarDetalle()
        {
            if (autoMedicamentos.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un medicamento");
            }else
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Ingresa la cantidad deseada");
                }else
                {
                    dynamic med = autoMedicamentos.SelectedItem;
                    int idm = med.ID_MEDICAMENTO;
                    var mediexistencia = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                    if (mediexistencia.CANTIDAD == 0)
                    {
                        MessageBox.Show("Se agotarion las existencias");
                    }else
                    {
                        if (Int32.Parse(txtCantidad.Text) <= mediexistencia.CANTIDAD)
                        {
                            DETALLE_SUMINISTROS_MEDICAMENTOS sum = new DETALLE_SUMINISTROS_MEDICAMENTOS
                            {
                                SUMINISTRO_MEDICAMENTOID = idsumi,
                                MEDICAMENTOID = idm,
                                PRECIO = Decimal.Parse(txtPrecio.Text),
                                CANTIDAD = Int32.Parse(txtCantidad.Text),
                                FECHA_CREACION = fechac
                            };
                            BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS.Add(sum);
                            BaseDatos.GetBaseDatos().SaveChanges();
                            total = (total) + ((Decimal.Parse(txtPrecio.Text)) * (Decimal.Parse(txtCantidad.Text)));
                            mediexistencia.CANTIDAD = mediexistencia.CANTIDAD - (Int32.Parse(txtCantidad.Text));
                            VistaGrid();
                            Limpiar();
                            btnFinalizar.IsEnabled = true;
                        }else
                        {
                            MessageBox.Show("Solo hay en existencia: " + mediexistencia.CANTIDAD.ToString());
                        }
                    }
                }
            }
        }

        void Finalizar()
        {
            var suministro = BaseDatos.GetBaseDatos().SUMINISTROS_MEDICAMENTOS.Find(idsumi);
            //suministro.TOTAL = suministro.TOTAL - totalEditar;
            suministro.TOTAL = total;
            BaseDatos.GetBaseDatos().SaveChanges();

            var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuenta);
            cuenta.TOTAL = cuenta.TOTAL - totalEditar;
            cuenta.SALDO = cuenta.SALDO - totalEditar;
            cuenta.TOTAL = cuenta.TOTAL + total;
            cuenta.SALDO = cuenta.SALDO + total;
            BaseDatos.GetBaseDatos().SaveChanges();
            MessageBox.Show("Suministro exitoso");
            MostrarPacientes mp = new MostrarPacientes(idUsuario);
            mp.Show();
            this.Close();
        }

        void Editar()
        {
            if (rgvDetalle.SelectedItem != null)
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Ingresa una cantidad");
                }else
                {
                    dynamic med = autoMedicamentos.SelectedItem;
                    int idme = med.ID_MEDICAMENTO;
                    var mediexistencia = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idme);
                    if (mediexistencia.CANTIDAD == 0)
                    {
                        MessageBox.Show("Se agotarion las existencias");
                    }else
                    {
                        if (Int32.Parse(txtCantidad.Text) <= mediexistencia.CANTIDAD)
                        {
                            dynamic detalle = rgvDetalle.SelectedItem;
                            int iddetalle = detalle.ID_DETALLE_SUMINISTRO;
                            var detalleSuministro = BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS.Find(iddetalle);

                            //Actualizamos el detalle medicamento
                            dynamic medi = autoMedicamentos.SelectedItem;
                            int idm = medi.ID_MEDICAMENTO;
                            detalleSuministro.MEDICAMENTOID = idm;
                            detalleSuministro.CANTIDAD = Int32.Parse(txtCantidad.Text);
                            detalleSuministro.PRECIO = Decimal.Parse(txtPrecio.Text);
                            BaseDatos.GetBaseDatos().SaveChanges();

                            //Actualizamos las existencias
                            var medica = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                            medica.CANTIDAD = medica.CANTIDAD - (Int32.Parse(txtCantidad.Text));

                            //Actualizar la cuenta
                            var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuenta);
                            cuenta.TOTAL = cuenta.TOTAL + (detalleSuministro.PRECIO * detalleSuministro.CANTIDAD);
                            cuenta.SALDO = cuenta.SALDO + (detalleSuministro.PRECIO * detalleSuministro.CANTIDAD);
                            BaseDatos.GetBaseDatos().SaveChanges();

                            //Se actualizan los botones 
                            btnEditar.Visibility = Visibility.Hidden;
                            btnAgregar.Visibility = Visibility.Visible;
                            btnFinalizar.IsEnabled = true;
                            VistaGrid();
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Solo hay en existencia: " + mediexistencia.CANTIDAD.ToString());
                        }
                    }
                }
            }
        }

        void Actualizar()
        {
            dynamic detalleSumini = rgvDetalle.SelectedItem;
            int iddetalle = detalleSumini.ID_DETALLE_SUMINISTRO;
            if (rgvDetalle.SelectedItem != null)
            {
                var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuenta);
                var detalleMedicamento = BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS.Find(iddetalle);

                //Actualizar existencias
                int idmed = detalleSumini.ID_MEDICAMENTO;
                var med = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmed);
                med.CANTIDAD = med.CANTIDAD + detalleMedicamento.CANTIDAD;
                BaseDatos.GetBaseDatos().SaveChanges();

                //Actualizamos la cuenta
                //cuenta.TOTAL = cuenta.TOTAL - (detalleMedicamento.PRECIO * detalleMedicamento.CANTIDAD);
                //cuenta.SALDO = cuenta.SALDO - (detalleMedicamento.PRECIO * detalleMedicamento.CANTIDAD);
                //BaseDatos.GetBaseDatos().SaveChanges();
                total = total - Decimal.Parse(detalleMedicamento.PRECIO.ToString()) * detalleMedicamento.CANTIDAD;

                //Eliminaar el suministro
                BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS.Remove(detalleMedicamento);
                BaseDatos.GetBaseDatos().SaveChanges();
                VistaGrid();
                
            }
        }

        //
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
                MessageBoxResult result = MessageBox.Show("¿Está seguro de eliminar el medicamento?", "Farmacia", MessageBoxButton.YesNo);
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
                        int iddetalle = detalle.ID_DETALLE_SUMINISTRO;
                        var detalleSuministro = BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS.Find(iddetalle);
                        int idm = detalleSuministro.MEDICAMENTOID;

                        //Se actualizan las existencias
                        var exi = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                        exi.CANTIDAD = exi.CANTIDAD + detalleSuministro.CANTIDAD;

                        //Se eliminan los totales de la cuenta
                        var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuenta);
                        cuenta.TOTAL = cuenta.TOTAL - (detalleSuministro.PRECIO * detalleSuministro.CANTIDAD);
                        cuenta.SALDO = cuenta.SALDO - (detalleSuministro.PRECIO * detalleSuministro.CANTIDAD);
                        BaseDatos.GetBaseDatos().SaveChanges();

                        //Asigna los valores a los txt
                        var medica = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                        txtCantidad.Text = detalleSuministro.CANTIDAD.ToString();
                        //autoMedicamentos.TextSearchPath = detalleSuministro.MEDICAMENTOID.ToString();
                        autoMedicamentos.SearchText = medica.NOMBRE_MEDI;
                        llenar();
                        
                    }
                }
            }
        }
        //

        private void autoMedicamentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            llenar();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            GuardarDetalle();
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            Finalizar();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }
    }
}
