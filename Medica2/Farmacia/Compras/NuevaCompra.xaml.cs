using AccessoDB;
using Medica2.Farmacia.Medicamentos;
using Medica2.Farmacia.Proveedores;
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

namespace Medica2.Farmacia.Compras
{
    /// <summary>
    /// Lógica de interacción para NuevaCompra.xaml
    /// </summary>
    public partial class NuevaCompra : Window
    {
        int idcompra;
        Decimal total;
        int idUsuario;
        int idEdiMed;
        public NuevaCompra()
        {
            InitializeComponent();
            llenarAutocompletes();
        }

        public NuevaCompra(int idu, int iduu)
        {
            InitializeComponent();
            llenarAutocompletes();
            idUsuario = idu;
        }

        public NuevaCompra(int idc)
        {
            InitializeComponent();
            llenarAutocompletes();
            //Datos del proveedor
            idcompra = idc;
            var compraedit = BaseDatos.GetBaseDatos().COMPRAS.Find(idcompra);
            autoProveedor.SearchText = compraedit.PROVEEDORE.PERSONA.NOMBRE + " " + compraedit.PROVEEDORE.PERSONA.A_PATERNO + " " + compraedit.PROVEEDORE.PERSONA.A_MATERNO;
            txtTelefono.Text = compraedit.PROVEEDORE.PERSONA.T_CELULAR;
            txtRFC.Text = compraedit.PROVEEDORE.RFC;
            txtFactura.Text = compraedit.NUM_FACTURA.ToString();
            dpFVencimiento.SelectedDate = compraedit.FECHA_VENCIMIENTO;
            dpFCompra.SelectedDate = compraedit.FECHA_COMPRA;
            
            //COmienza lo bueno para editar
            
            VistaGrid();
            Bloquear();
            
            total = Decimal.Parse(compraedit.TOTAL.ToString());
            txtTotal.Text = compraedit.TOTAL.ToString();
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
            autoProveedor.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                         join e in BaseDatos.GetBaseDatos().PROVEEDORES
                                         on PERSONA.ID_PERSONA equals e.PERSONAID
                                         where PERSONA.ESTADOPERSONA == "Activo"
                                         select new
                                         {
                                             ID_PROVEEDOR = e.ID_PROVEEDOR,
                                             NOMBRE = PERSONA.NOMBRE + " " + PERSONA.A_PATERNO + " " + PERSONA.A_MATERNO
                                         });
        }

        void VistaGrid()
        {
            rgvDetalle.ItemsSource = (from COMPRAS in BaseDatos.GetBaseDatos().COMPRAS
                                      join detalle in BaseDatos.GetBaseDatos().DETALLE_COMPRAS
                                      on COMPRAS.ID_COMPRA equals detalle.COMPRAID
                                      join medicamento in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                      on detalle.MEDICAMENTOID equals medicamento.ID_MEDICAMENTO
                                      where COMPRAS.ID_COMPRA == idcompra
                                      select new
                                      {
                                          ID_COMPRA = COMPRAS.ID_COMPRA,
                                          ID_DETALLE_COMPRA = detalle.ID_DETALLE_COMPRA,
                                          ID_MEDICAMENTO = medicamento.ID_MEDICAMENTO,
                                          NOMMEDI = medicamento.NOMBRE_MEDI,
                                          UMEDIDA = medicamento.U_MEDIDA,
                                          CANTIDAD = detalle.CANTIDAD,
                                          COSTO = medicamento.P_COMPRA,
                                          SUBTOTAL = detalle.SUBTOTAL
                                      }).ToList();
        }

        void LimpiarCompra()
        {
            txtFactura.Text = String.Empty;
            autoProveedor.SearchText = String.Empty;
            dpFCompra.Text = String.Empty;
            dpFVencimiento.Text = String.Empty;
            txtRFC.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            
        }

        void LimpiarDetalle()
        {
            autoMedicamentos.SearchText = String.Empty;
            autoMedicamentos.SelectedItem = null;
            txtDescripcion.Text = String.Empty;
            txtUMedida.Text = String.Empty;
            dpCaducidad.Text = "";
            txtCBarras.Text = String.Empty;
            txtCFDI.Text = String.Empty;
            txtCantidad.Text = String.Empty;
            txtCostoUnitario.Text = String.Empty;
            txtPVenta.Text = String.Empty;
            txtPMedicos.Text = String.Empty;
            cbbAlmacen.SelectedIndex = -1;
            txtIVA.Text = String.Empty;
        }

        void Bloquear()
        {
            txtFactura.IsEnabled = false;
            dpFCompra.IsEnabled = false;
            dpFVencimiento.IsEnabled = false;
            autoProveedor.IsEnabled = false;
            btnGuardar.IsEnabled = false;
            btnNuevoProveedor.IsEnabled = false;
            txtTelefono.IsEnabled = false;
            txtRFC.IsEnabled = false;
            HabilitarDetalle();
        }

        void BloquearDetalle()
        {
            autoMedicamentos.IsEnabled = false;
            txtDescripcion.IsEnabled = false;
            txtUMedida.IsEnabled = false;
            dpCaducidad.IsEnabled = false;
            txtCBarras.IsEnabled = false;
            txtCFDI.IsEnabled = false;
            txtPVenta.IsEnabled = false;
            txtCostoUnitario.IsEnabled = false;
            txtPMedicos.IsEnabled = false;
            cbbAlmacen.IsEnabled = false;
            txtCantidad.IsEnabled = false;
            btnAgregar.IsEnabled = false;
            btnNuevoMedic.IsEnabled = false;
            btnFinalizar.IsEnabled = false;
            txtIVA.IsEnabled = false;
        }

        void HabilitarCompra()
        {
            txtFactura.IsEnabled = true;
            dpFCompra.IsEnabled = true;
            dpFVencimiento.IsEnabled = true;
            autoProveedor.IsEnabled = true;
            btnGuardar.IsEnabled = true;
            btnNuevoProveedor.IsEnabled = true;
            txtTelefono.IsEnabled = true;
            txtRFC.IsEnabled = true;
            BloquearDetalle();
        }

        void HabilitarDetalle()
        {
            autoMedicamentos.IsEnabled = true;
            txtDescripcion.IsEnabled = true;
            txtUMedida.IsEnabled = true;
            dpCaducidad.IsEnabled = true;
            txtCBarras.IsEnabled = true;
            txtCFDI.IsEnabled = true;
            txtPVenta.IsEnabled = true;
            txtCostoUnitario.IsEnabled = true;
            txtPMedicos.IsEnabled = true;
            cbbAlmacen.IsEnabled = true;
            txtCantidad.IsEnabled = true;
            btnAgregar.IsEnabled = true;
            btnNuevoMedic.IsEnabled = true;
            txtIVA.IsEnabled = true;
        }

        public bool ConsultaFactura(int fac, int prov)
        {
            var factura = (from COMPRA in BaseDatos.GetBaseDatos().COMPRAS
                           where COMPRA.NUM_FACTURA == fac && COMPRA.PROVEEDORID == prov
                           select COMPRA).Count();
            if (factura == 0)
                return false;
            else
                return true;

        }

        void GuardarCompra()
        {
            if (txtFactura.Text == "")
            {
                MessageBox.Show("Ingresa el número de factura");
            }
            else
            {
                if (autoProveedor.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un proveedor");
                }else
                {
                    dynamic idp = autoProveedor.SelectedItem;
                    int prove = idp.ID_PROVEEDOR;
                    if (!ConsultaFactura(int.Parse(txtFactura.Text), prove))
                    {
                        if (dpFCompra.SelectedDate == null)
                        {
                            MessageBox.Show("Selecciona la fecha de compra");
                        }else
                        {
                            if (dpFVencimiento.SelectedDate == null)
                            {
                                MessageBox.Show("Selecciona la fecha de vencimiento");
                            }else
                            {
                                COMPRA c = new COMPRA()
                                {
                                    NUM_FACTURA = Int32.Parse(txtFactura.Text),
                                    FECHA_COMPRA = dpFCompra.SelectedDate,
                                    FECHA_VENCIMIENTO = dpFVencimiento.SelectedDate,
                                    PROVEEDORID = prove,
                                    USUARIOID = idUsuario
                                };
                                BaseDatos.GetBaseDatos().COMPRAS.Add(c);
                                BaseDatos.GetBaseDatos().SaveChanges();
                                idcompra = c.ID_COMPRA;
                                Bloquear();
                            }
                        }
                    }else
                    {
                        MessageBox.Show("EL número de factura con el proveedor ya existe");
                    }
                }
            }
        }

        void GuardarDetalleCompra()
        {
            if (autoMedicamentos.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un medicamento");
            }
            else
            {
                if (txtDescripcion.Text == "")
                {
                    MessageBox.Show("Ingresa una descripción");
                }
                else
                {
                    if (txtUMedida.Text == "")
                    {
                        MessageBox.Show("Ingresa la unidad de medida");
                    }
                    else
                    {
                        if (dpCaducidad.SelectedDate == null)
                        {
                            MessageBox.Show("Selecciona la fecha de caducidad");
                        }
                        else
                        {
                            if (txtCBarras.Text == "")
                            {
                                MessageBox.Show("Ingresa el código de barras");
                            }
                            else
                            {
                                if (txtCFDI.Text == "")
                                {
                                    MessageBox.Show("Ingresa el CFDI");
                                }
                                else
                                {
                                    if (txtCostoUnitario.Text == "")
                                    {
                                        MessageBox.Show("Ingresa el precio de compra");
                                    }
                                    else
                                    {
                                        if (txtPVenta.Text == "")
                                        {
                                            MessageBox.Show("Ingresa el precio de venta");
                                        }
                                        else
                                        {
                                            if (txtPMedicos.Text == "")
                                            {
                                                MessageBox.Show("Ingresa el precio para medicos");
                                            }
                                            else
                                            {
                                                if (cbbAlmacen.Text == "")
                                                {
                                                    MessageBox.Show("Selecciona el tipo de almacen");
                                                }
                                                else
                                                {
                                                    if (txtCantidad.Text == "")
                                                    {
                                                        MessageBox.Show("Ingresa la cantidad comprada");
                                                    }
                                                    else
                                                    {
                                                        if (txtIVA.Text == "")
                                                        {
                                                            MessageBox.Show("Ingresa el porcentaje del IVA");
                                                        }else
                                                        {
                                                            dynamic medica = autoMedicamentos.SelectedItem;
                                                            int idm = medica.ID_MEDICAMENTO;
                                                            var medic = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                                                            DETALLE_COMPRAS dc = new DETALLE_COMPRAS()
                                                            {
                                                                COMPRAID = idcompra,
                                                                MEDICAMENTOID = idm,
                                                                NOMEDI = medic.NOMBRE_MEDI,
                                                                CANTIDAD = int.Parse(txtCantidad.Text),
                                                                COSTO_UNITARIO = Decimal.Parse(txtCostoUnitario.Text),
                                                                U_MEDIDA = txtUMedida.Text,
                                                                CFDI = int.Parse(txtCFDI.Text),
                                                                ALMACEN = cbbAlmacen.Text,
                                                                SUBTOTAL = (Decimal.Parse(txtCantidad.Text) * Decimal.Parse(txtCostoUnitario.Text))
                                                            };
                                                            //Se guarda el medicamento en compra
                                                            BaseDatos.GetBaseDatos().DETALLE_COMPRAS.Add(dc);
                                                            BaseDatos.GetBaseDatos().SaveChanges();
                                                            //Almacenamos los subtotales
                                                            total = total + (Decimal.Parse(txtCantidad.Text) * Decimal.Parse(txtCostoUnitario.Text));
                                                            txtTotal.Text = total.ToString();
                                                            //actualizamos las existencias
                                                            //var exis = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idm);
                                                            medic.CANTIDAD = medic.CANTIDAD + int.Parse(txtCantidad.Text);
                                                            medic.ALMACEN = cbbAlmacen.Text;
                                                            medic.CADUCIDAD = dpCaducidad.SelectedDate;
                                                            medic.COD_BARRAS = txtCBarras.Text;
                                                            medic.CFDI = int.Parse(txtCFDI.Text);
                                                            medic.P_COMPRA = Decimal.Parse(txtCostoUnitario.Text);
                                                            medic.P_VENTA = Decimal.Parse(txtPVenta.Text);
                                                            medic.P_MEDICOS = Decimal.Parse(txtPMedicos.Text);
                                                            medic.U_MEDIDA = txtUMedida.Text;
                                                            medic.IVA = Decimal.Parse(txtIVA.Text);
                                                            BaseDatos.GetBaseDatos().SaveChanges();
                                                            //Se limpian las casillas
                                                            LimpiarDetalle();
                                                            //Se actualiza la datagrid
                                                            VistaGrid();
                                                            btnFinalizar.IsEnabled = true;
                                                        }
                                                    }   
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        void Finalizar()
        {
            var comp = BaseDatos.GetBaseDatos().COMPRAS.Find(idcompra);
            comp.IMPORTE = total;
            comp.TOTAL = total;
            BaseDatos.GetBaseDatos().SaveChanges();
            MessageBox.Show("Se finalizó la compra");
            HabilitarCompra();
            idcompra = 0;
            VistaGrid();
            total = 0;
            txtTotal.Text = String.Empty;
            LimpiarCompra();
        }

        void Eliminar()
        {
            dynamic detalleVen = rgvDetalle.SelectedItem;
            int iddetalle = detalleVen.ID_DETALLE_COMPRA;
            if (rgvDetalle.SelectedItem != null)
            {
                var detalleCompra = BaseDatos.GetBaseDatos().DETALLE_COMPRAS.Find(iddetalle);

                //Actualizar existencias
                int idme = detalleVen.ID_MEDICAMENTO;
                var medicam = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idme);
                medicam.CANTIDAD = medicam.CANTIDAD + detalleCompra.CANTIDAD;
                BaseDatos.GetBaseDatos().SaveChanges();

                //Actualizamos el total
                total = total - (Decimal.Parse(detalleCompra.SUBTOTAL.ToString()));
                txtTotal.Text = total.ToString();

                //Eliminar el suministro
                BaseDatos.GetBaseDatos().DETALLE_COMPRAS.Remove(detalleCompra);
                BaseDatos.GetBaseDatos().SaveChanges();
                VistaGrid();
            }
        }

        void EditarDetalleCompra()
        {
            if (txtDescripcion.Text == "")
                {
                    MessageBox.Show("Ingresa una descripción");
                }
                else
                {
                    if (txtUMedida.Text == "")
                    {
                        MessageBox.Show("Ingresa la unidad de medida");
                    }
                    else
                    {
                        if (dpCaducidad.SelectedDate == null)
                        {
                            MessageBox.Show("Selecciona la fecha de caducidad");
                        }
                        else
                        {
                            if (txtCBarras.Text == "")
                            {
                                MessageBox.Show("Ingresa el código de barras");
                            }
                            else
                            {
                                if (txtCFDI.Text == "")
                                {
                                    MessageBox.Show("Ingresa el CFDI");
                                }
                                else
                                {
                                    if (txtCostoUnitario.Text == "")
                                    {
                                        MessageBox.Show("Ingresa el precio de compra");
                                    }
                                    else
                                    {
                                        if (txtPVenta.Text == "")
                                        {
                                            MessageBox.Show("Ingresa el precio de venta");
                                        }
                                        else
                                        {
                                            if (txtPMedicos.Text == "")
                                            {
                                                MessageBox.Show("Ingresa el precio para medicos");
                                            }
                                            else
                                            {
                                                if (cbbAlmacen.Text == "")
                                                {
                                                    MessageBox.Show("Selecciona el tipo de almacén");
                                                }
                                                else
                                                {
                                                    if (txtCantidad.Text == "")
                                                    {
                                                        MessageBox.Show("Ingresa la cantidad comprada");
                                                    }
                                                    else
                                                    {
                                                        dynamic detalle = rgvDetalle.SelectedItem;
                                                        int iddetalle = detalle.ID_DETALLE_COMPRA;
                                                        var detalleCompra = BaseDatos.GetBaseDatos().DETALLE_COMPRAS.Find(iddetalle);

                                                        //Actualizamos el detalle medicamento
                                                        detalleCompra.MEDICAMENTOID = idEdiMed;
                                                        detalleCompra.CANTIDAD = Int32.Parse(txtCantidad.Text);
                                                        detalleCompra.COSTO_UNITARIO = Decimal.Parse(txtCostoUnitario.Text);
                                                        detalleCompra.SUBTOTAL = Int32.Parse(txtCantidad.Text) * Decimal.Parse(txtCostoUnitario.Text);
                                                        BaseDatos.GetBaseDatos().SaveChanges();

                                                        //Actualizamos las existencias
                                                        var me = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idEdiMed);
                                                        me.CANTIDAD = me.CANTIDAD + (Int32.Parse(txtCantidad.Text));

                                                        //Actualizamos el total
                                                        total = total + (Int32.Parse(txtCantidad.Text) * (Decimal.Parse(txtCostoUnitario.Text)));
                                                        txtTotal.Text = total.ToString();

                                                        //Se actualizan los botones 
                                                        btnEditar.Visibility = Visibility.Hidden;
                                                        btnAgregar.Visibility = Visibility.Visible;
                                                        btnFinalizar.IsEnabled = true;
                                                        VistaGrid();
                                                        LimpiarDetalle();
                                                    autoMedicamentos.IsEnabled = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        
                    }
                }
            }
        }

        void llenar()
        {
            if (autoMedicamentos.SelectedItem != null)
            {
                dynamic medica = autoMedicamentos.SelectedItem;
                int idmedi = medica.ID_MEDICAMENTO;
                var busquedamed = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmedi);
                txtUMedida.Text = Convert.ToString(busquedamed.U_MEDIDA);
                txtDescripcion.Text = busquedamed.COMENTARIO.ToString();
                dpCaducidad.SelectedDate = busquedamed.CADUCIDAD;
                txtCBarras.Text = busquedamed.COD_BARRAS;
                txtCFDI.Text = busquedamed.CFDI.ToString();
                txtUMedida.Text = busquedamed.U_MEDIDA.ToString();
                txtCostoUnitario.Text = busquedamed.P_COMPRA.ToString();
                txtPVenta.Text = busquedamed.P_VENTA.ToString();
                txtPMedicos.Text = busquedamed.P_MEDICOS.ToString();
                cbbAlmacen.Text = busquedamed.ALMACEN;
                txtIVA.Text = busquedamed.IVA.ToString();
                //

            }
        }

        void llenarProveedor()
        {
            if (autoProveedor.SelectedItem != null)
            {
                dynamic prov = autoProveedor.SelectedItem;
                int idProv = prov.ID_PROVEEDOR;
                var proveedor = BaseDatos.GetBaseDatos().PROVEEDORES.Find(idProv);
                txtRFC.Text = proveedor.RFC.ToString();
                txtTelefono.Text = proveedor.PERSONA.T_CELULAR;
            }
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

        private void autoMedicamentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            llenar();
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
                        Eliminar();
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
                        int iddetalle = detalle.ID_DETALLE_COMPRA;
                        var detalleCompra = BaseDatos.GetBaseDatos().DETALLE_COMPRAS.Find(iddetalle);
                        idEdiMed = detalleCompra.MEDICAMENTOID;

                        //Se actualizan las existencias
                        var exi = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idEdiMed);
                        exi.CANTIDAD = exi.CANTIDAD - detalleCompra.CANTIDAD;

                        //Asigna los valores a los txt
                        var medicamento = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idEdiMed);
                        txtCantidad.Text = detalleCompra.CANTIDAD.ToString();
                        txtUMedida.Text = Convert.ToString(medicamento.U_MEDIDA);
                        txtDescripcion.Text = medicamento.COMENTARIO.ToString();
                        dpCaducidad.SelectedDate = medicamento.CADUCIDAD;
                        txtCBarras.Text = medicamento.COD_BARRAS;
                        txtCFDI.Text = medicamento.CFDI.ToString();
                        txtUMedida.Text = medicamento.U_MEDIDA.ToString();
                        txtCostoUnitario.Text = medicamento.P_COMPRA.ToString();
                        txtPVenta.Text = medicamento.P_VENTA.ToString();
                        txtPMedicos.Text = medicamento.P_MEDICOS.ToString();
                        cbbAlmacen.Text = medicamento.ALMACEN;
                        txtIVA.Text = medicamento.IVA.ToString();

                        //Se actualizan los totales
                        total = total - (Decimal.Parse(detalleCompra.SUBTOTAL.ToString()));
                        txtTotal.Text = total.ToString();

                        //autoMedicamentos.TextSearchPath = detalleSuministro.MEDICAMENTOID.ToString();
                        //autoMedicamentos.DisplayMemberPath = medicamento.NOMBRE_MEDI;
                        autoMedicamentos.SearchText = medicamento.NOMBRE_MEDI + " " + medicamento.COMENTARIO + " " + medicamento.U_MEDIDA;
                        autoMedicamentos.IsEnabled = false;
                        //llenar();
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            GuardarCompra();
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            Finalizar();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarDetalleCompra();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            GuardarDetalleCompra();
        }

        private void btnNuevoProveedor_Click(object sender, RoutedEventArgs e)
        {
            RegistroProveedor np = new RegistroProveedor(autoProveedor);
            np.Show();
        }

        private void autoProveedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            llenarProveedor();
        }

        private void btnNuevoMedic_Click(object sender, RoutedEventArgs e)
        {
            RegistroMedicamento rm = new RegistroMedicamento(autoMedicamentos);
            rm.Show();
        }
    }
}
