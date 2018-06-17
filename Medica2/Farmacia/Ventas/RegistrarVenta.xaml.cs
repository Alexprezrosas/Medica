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

namespace Medica2.Farmacia.Ventas
{
    /// <summary>
    /// Lógica de interacción para RegistrarVenta.xaml
    /// </summary>
    public partial class RegistrarVenta : Window
    {
        int venta;
        Decimal total = 0;
        DateTime dh = DateTime.Now;

        public RegistrarVenta()
        {
            InitializeComponent();
            VistaRad();
            autoMedicamentos.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.ToList();
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

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;

        }

        private void validarDecimal(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else if (e.Key == Key.Decimal)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void validarPunto(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci == 46) e.Handled = false;

            else e.Handled = true;

        }

        //Constructor para Editar
        public RegistrarVenta(int idv)
        {
            InitializeComponent();
            autoMedicamentos.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.ToList();

            venta = idv;
            VistaRad();
            HabilitarDetalle();
            btnNuevaVenta.IsEnabled = false;
            var ven = BaseDatos.GetBaseDatos().VENTAS_GENERALES.Find(venta);
            total = Convert.ToDecimal(ven.TOTAL.ToString());
            txtTotal.Text = total.ToString();
        }

        void VistaRad()
        {
            rgvDetalle.ItemsSource = (from VENTAS_GENERALES in BaseDatos.GetBaseDatos().VENTAS_GENERALES
                                      join detalle in BaseDatos.GetBaseDatos().DETALLE_VENTAS
                                      on VENTAS_GENERALES.ID_VENTA_GENERAL equals detalle.VENTAID
                                      join medicamento in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                      on detalle.MEDICAMENTOID equals medicamento.ID_MEDICAMENTO
                                      where VENTAS_GENERALES.ID_VENTA_GENERAL == venta
                                      select new
                                      {
                                          ID_VENTA = VENTAS_GENERALES.ID_VENTA_GENERAL,
                                          ID_DETALLE_VENTA = detalle.ID_DETALLE_VENTA,
                                          ID_MEDICAMENTO = medicamento.ID_MEDICAMENTO,
                                          NOMMEDI = medicamento.NOMBRE_MEDI,
                                          UMEDIDA = medicamento.U_MEDIDA,
                                          CANTIDAD = detalle.CANTIDAD,
                                          COSTO = medicamento.P_VENTA,
                                          SUBTOTAL = detalle.SUBTOTAL
                                      }).ToList();
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

                    int idma = ((CATALOGO_MEDICAMENTOS)autoMedicamentos.SelectedItem).ID_MEDICAMENTO;
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
                            int iddetalle = detalle.ID_DETALLE_VENTA;
                            var detalleVenta = BaseDatos.GetBaseDatos().DETALLE_VENTAS.Find(iddetalle);

                            //Actualizamos el detalle medicamento

                            int idm = ((CATALOGO_MEDICAMENTOS)autoMedicamentos.SelectedItem).ID_MEDICAMENTO;
                            detalleVenta.MEDICAMENTOID = idm;
                            detalleVenta.CANTIDAD = Int32.Parse(txtCantidad.Text);
                            detalleVenta.COSTO = Decimal.Parse(txtPVenta.Text);
                            detalleVenta.SUBTOTAL = Int32.Parse(txtCantidad.Text) * Decimal.Parse(txtPVenta.Text);
                            BaseDatos.GetBaseDatos().SaveChanges();

                            //Actualizamos las existencias
                            var me = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                            me.CANTIDAD = me.CANTIDAD - (Int32.Parse(txtCantidad.Text));

                            //Actualizamos el total
                            total = total + (Int32.Parse(txtCantidad.Text) * (Decimal.Parse(txtPVenta.Text)));
                            txtTotal.Text = total.ToString();

                            //Se actualizan los botones 
                            btnEditar.Visibility = Visibility.Hidden;
                            btnAgregar.Visibility = Visibility.Visible;
                            btnFinalizar.IsEnabled = true;
                            VistaRad();
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

        void HabilitarDetalle()
        {
            autoMedicamentos.IsEnabled = true;
            txtCantidad.IsEnabled = true;
            btnAgregar.IsEnabled = true;
            chbVenta.IsEnabled = true;
        }

        void Limpiar()
        {
            autoMedicamentos.SearchText = String.Empty;
            txtCantidad.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtPVenta.Text = String.Empty;
            txtUMedida.Text = String.Empty;
            txtExistencias.Text = String.Empty;
        }

        void NuevaVenta()
        {
            VENTAS_GENERALES v = new VENTAS_GENERALES()
            {
                USUARIOID = 2,
                CLIENTE = txtCliente.Text,
                FECHA_CREACION = dh
            };
            BaseDatos.GetBaseDatos().VENTAS_GENERALES.Add(v);
            BaseDatos.GetBaseDatos().SaveChanges();
            var ventaid = BaseDatos.GetBaseDatos().VENTAS_GENERALES.Find(v.ID_VENTA_GENERAL);
            venta = ventaid.ID_VENTA_GENERAL;
            btnNuevaVenta.IsEnabled = false;
            HabilitarDetalle();
        }

        void GuardarDetalle()
        {
            if (autoMedicamentos.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un medicamento valido");
            }else
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Ingresa la cantidad");
                }else
                {
                    int idme = ((CATALOGO_MEDICAMENTOS)autoMedicamentos.SelectedItem).ID_MEDICAMENTO;
                    var medic = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idme);
                    if (medic.CANTIDAD == 0)
                    {
                        MessageBox.Show("Existencias agotadas");
                    }else
                    {
                        if (Convert.ToInt32(txtCantidad.Text) > medic.CANTIDAD)
                        {
                            MessageBox.Show("Existencias: " + medic.CANTIDAD);
                        }else
                        {
                            DETALLE_VENTAS dv = new DETALLE_VENTAS
                            {
                                VENTAID = venta,
                                MEDICAMENTOID = idme,
                                CANTIDAD = Convert.ToInt32(txtCantidad.Text),
                                COSTO = Decimal.Parse(txtPVenta.Text),
                                F_CADUCIDAD = medic.CADUCIDAD,
                                SUBTOTAL = ((Convert.ToInt32(txtCantidad.Text)) * (Decimal.Parse(txtPVenta.Text))),
                                FECHA_CREACION = dh
                            };
                            BaseDatos.GetBaseDatos().DETALLE_VENTAS.Add(dv);
                            BaseDatos.GetBaseDatos().SaveChanges();

                            //Calculamos el total
                            total = total + ((Convert.ToInt32(txtCantidad.Text)) * (Decimal.Parse(txtPVenta.Text)));
                            txtTotal.Text = total.ToString();

                            //Llenamos la DataGrid
                            VistaRad();

                            //Actualizamos exixtencias
                            medic.CANTIDAD = medic.CANTIDAD - Convert.ToInt32(txtCantidad.Text);
                            BaseDatos.GetBaseDatos().SaveChanges();

                            //Limpiamos
                            Limpiar();

                            //Habilitamos el btn Finalizar
                            btnFinalizar.IsEnabled = true;

                            chbVenta.IsEnabled = false;
                        }
                    }
                }
            }
        }

        void llenar()
        {

            if (autoMedicamentos.SelectedItem != null)
            {
                if (chbVenta.IsChecked == true)
                {
                    int idmedi = ((CATALOGO_MEDICAMENTOS)autoMedicamentos.SelectedItem).ID_MEDICAMENTO;
                    var busquedamed = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmedi);
                    txtUMedida.Text = Convert.ToString(busquedamed.U_MEDIDA);
                    txtDescripcion.Text = busquedamed.COMENTARIO.ToString();
                    txtUMedida.Text = Convert.ToString(busquedamed.U_MEDIDA);
                    txtPVenta.Text = busquedamed.P_MEDICOS.ToString();
                    txtExistencias.Text = busquedamed.CANTIDAD.ToString();
                }else
                {
                    
                    int idmedi = ((CATALOGO_MEDICAMENTOS)autoMedicamentos.SelectedItem).ID_MEDICAMENTO;
                    var busquedamed = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmedi);
                    txtUMedida.Text = Convert.ToString(busquedamed.U_MEDIDA);
                    txtDescripcion.Text = busquedamed.COMENTARIO.ToString();
                    txtUMedida.Text = Convert.ToString(busquedamed.U_MEDIDA);
                    txtPVenta.Text = busquedamed.P_VENTA.ToString();
                    txtExistencias.Text = busquedamed.CANTIDAD.ToString();
                    
                }
            }
        }

        void llenarMed()
        {
            if (autoMedicamentos.SelectedItem != null)
            {
                int idmedi = ((CATALOGO_MEDICAMENTOS)autoMedicamentos.SelectedItem).ID_MEDICAMENTO;
                var busquedamed = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmedi);
                txtUMedida.Text = Convert.ToString(busquedamed.U_MEDIDA);
                txtDescripcion.Text = busquedamed.COMENTARIO.ToString();
                txtUMedida.Text = Convert.ToString(busquedamed.U_MEDIDA);
                txtPVenta.Text = busquedamed.P_MEDICOS.ToString();
                txtExistencias.Text = busquedamed.CANTIDAD.ToString();
            }
        }

        void FinalizarVenta()
        {
            var comp = BaseDatos.GetBaseDatos().VENTAS_GENERALES.Find(venta);
            comp.IMPORTE = total;
            comp.TOTAL = total;
            comp.CLIENTE = txtCliente.Text;
            BaseDatos.GetBaseDatos().SaveChanges();
            MessageBox.Show("Se ha finalizado la venta");
            autoMedicamentos.IsEnabled = false;
            txtCantidad.IsEnabled = false;
            btnAgregar.IsEnabled = false;
            btnFinalizar.IsEnabled = false;
            btnNuevaVenta.IsEnabled = false;
            btnNuevaVenta.IsEnabled = true;
            txtTotal.Text = String.Empty;
            total = 0;
            Limpiar();
            venta = 0;
            VistaRad();
            chbVenta.IsChecked = false;
            chbVenta.IsEnabled = false;
        }

        //Editar

        

        void Actualizar()
        {
            dynamic detalleVen = rgvDetalle.SelectedItem;
            int iddetalle = detalleVen.ID_DETALLE_VENTA;
            if (rgvDetalle.SelectedItem != null)
            {
                var detalleVenta = BaseDatos.GetBaseDatos().DETALLE_VENTAS.Find(iddetalle);

                //Actualizar existencias
                int idme = detalleVen.ID_MEDICAMENTO;
                var medicam = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idme);
                medicam.CANTIDAD = medicam.CANTIDAD + detalleVenta.CANTIDAD;
                BaseDatos.GetBaseDatos().SaveChanges();

                //Actualizamos el total
                total = total - (Decimal.Parse(detalleVenta.SUBTOTAL.ToString()));
                txtTotal.Text = total.ToString();

                //Eliminar el suministro
                BaseDatos.GetBaseDatos().DETALLE_VENTAS.Remove(detalleVenta);
                BaseDatos.GetBaseDatos().SaveChanges();
                VistaRad();
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
                MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el material?", "Farmacia", MessageBoxButton.YesNo);
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
                        int iddetalle = detalle.ID_DETALLE_VENTA;
                        var detalleVenta = BaseDatos.GetBaseDatos().DETALLE_VENTAS.Find(iddetalle);
                        int idm = detalleVenta.MEDICAMENTOID;

                        //Se actualizan las existencias
                        var exi = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                        exi.CANTIDAD = exi.CANTIDAD + detalleVenta.CANTIDAD;

                        //Asigna los valores a los txt
                        var medicamento = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                        txtCantidad.Text = detalleVenta.CANTIDAD.ToString();

                        //Se actualizan los totales
                        total = total - (Decimal.Parse(detalleVenta.SUBTOTAL.ToString()));
                        txtTotal.Text = total.ToString();

                        //autoMedicamentos.TextSearchPath = detalleSuministro.MEDICAMENTOID.ToString();
                        autoMedicamentos.SearchText = medicamento.NOMBRE_MEDI;
                        llenar();
                    }
                }
            }
        }
        //EndEditar

        private void btnNuevaVenta_Click(object sender, RoutedEventArgs e)
        {
            NuevaVenta();
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            FinalizarVenta();
        }

        private void autoMedicamentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            llenar();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            GuardarDetalle();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }

        private void chbVenta_Checked(object sender, RoutedEventArgs e)
        {
            txtCliente.Text = "Medico";
        }

        private void chbVenta_Unchecked(object sender, RoutedEventArgs e)
        {
            txtCliente.Text = "Mostrador";
        }
    }
}
