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

namespace Medica2.Farmacia.Medicamentos
{
    /// <summary>
    /// Lógica de interacción para NuevoMedicamento.xaml
    /// </summary>
    public partial class NuevoMedicamento : Window
    {
        int idmedicamento;
        public NuevoMedicamento()
        {
            InitializeComponent();
            
            Limpiar();
        }

        public NuevoMedicamento(int idmed)
        {
            InitializeComponent();

            idmedicamento = idmed;
            var medicamento = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmedicamento);

            txtNombre.Text = medicamento.NOMBRE_MEDI;
            txtComentario.Text = medicamento.COMENTARIO;
            txtCantidad.Text = medicamento.CANTIDAD.ToString();
            txtCodBarras.Text = medicamento.COD_BARRAS;
            txtPCompra.Text = medicamento.P_COMPRA.ToString();
            txtPMedicos.Text = medicamento.P_MEDICOS.ToString();
            txtPVenta.Text = medicamento.P_VENTA.ToString();
            dpCaducidad.SelectedDate = medicamento.CADUCIDAD;
            txtUMedida.Text = medicamento.U_MEDIDA;
            txtCFDI.Text = medicamento.CFDI.ToString();
            cbbAlmacen.Text = medicamento.ALMACEN;

            btnGuardar.Visibility = Visibility.Hidden;
            btnActualizar.Visibility = Visibility.Visible;

        }

        void GuardarMedicamento()
        {
             if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa un medicamento");
            }else
            {
                if (txtComentario.Text == "")
                {
                    MessageBox.Show("Ingresa una descripción");

                }else
                {
                    if (txtCantidad.Text == "")
                    {
                        MessageBox.Show("Ingresa una cantidad");
                    }else
                    {
                        if (txtCodBarras.Text == "" && txtCodBarras.Text.Length < 13)
                        {
                            MessageBox.Show("Ingresa un código de barras válido");
                        }else
                        {
                            if (txtPCompra.Text == "")
                            {
                                MessageBox.Show("Ingresa el precio de compra");
                            }else
                            {
                                if (txtPVenta.Text == "")
                                {
                                    MessageBox.Show("Ingresa el precio de venta");
                                }else
                                {
                                    if (txtPMedicos.Text == "")
                                    {
                                        MessageBox.Show("Ingresa el precio para médicos");
                                    }else
                                    {
                                        if (txtDescuento.Text == "")
                                        {
                                            MessageBox.Show("Ingresa el descuento");
                                        }else
                                        {
                                            if (txtUMedida.Text == "")
                                            {
                                                MessageBox.Show("Selecciona una unidad de medida");
                                            }else
                                            {
                                                if (txtCFDI.Text == "" && txtCFDI.Text.Length < 8)
                                                {
                                                    MessageBox.Show("Ingresa un CFDI válido");
                                                }else
                                                {
                                                    if (cbbAlmacen.Text == "")
                                                    {
                                                        MessageBox.Show("Selecciona el tipo de almacén");
                                                    }else
                                                    {
                                                        DateTime fec = DateTime.Now;


                                                        CATALOGO_MEDICAMENTOS cm = new CATALOGO_MEDICAMENTOS
                                                        {
                                                            NOMBRE_MEDI = txtNombre.Text,
                                                            CANTIDAD = Int32.Parse(txtCantidad.Text),
                                                            COMENTARIO = txtComentario.Text,
                                                            P_VENTA = Decimal.Parse(txtPVenta.Text),
                                                            P_COMPRA = Decimal.Parse(txtPCompra.Text),
                                                            P_MEDICOS = Decimal.Parse(txtPMedicos.Text),
                                                            DESCUENTO = Decimal.Parse(txtDescuento.Text),
                                                            CADUCIDAD = dpCaducidad.SelectedDate,
                                                            FECHA_CREACION = fec,
                                                            COD_BARRAS = txtCodBarras.Text,
                                                            U_MEDIDA = txtUMedida.Text,
                                                            CFDI = Int32.Parse(txtCFDI.Text),
                                                            ALMACEN = cbbAlmacen.Text
                                                        };
                                                        BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Add(cm);
                                                        BaseDatos.GetBaseDatos().SaveChanges();
                                                        MessageBoxResult result = MessageBox.Show("Se guardó correctamente el medicamento", "Registro exitoso");
                                                        Limpiar();
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

        void EditarMedicamento()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa un medicamento");
            }
            else
            {
                if (txtComentario.Text == "")
                {
                    MessageBox.Show("Ingresa una descripción");

                }
                else
                {
                    if (txtCantidad.Text == "")
                    {
                        MessageBox.Show("Ingresa una cantidad");
                    }
                    else
                    {
                        if (txtCodBarras.Text == "" && txtCodBarras.Text.Length < 13)
                        {
                            MessageBox.Show("Ingresa un código de barras válido");
                        }
                        else
                        {
                            if (txtPCompra.Text == "")
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
                                        MessageBox.Show("Ingresa el precio para médicos");
                                    }
                                    else
                                    {
                                        if (txtDescuento.Text == "")
                                        {
                                            MessageBox.Show("Ingresa el descuento");
                                        }
                                        else
                                        {
                                            if (txtUMedida.Text == "")
                                            {
                                                MessageBox.Show("Selecciona una unidad de medida");
                                            }
                                            else
                                            {
                                                if (txtCFDI.Text == "" && txtCFDI.Text.Length < 8)
                                                {
                                                    MessageBox.Show("Ingresa un CFDI valido");
                                                }
                                                else
                                                {
                                                    DateTime fec = DateTime.Now;
                                                    var medic = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmedicamento);
                                                    medic.NOMBRE_MEDI = txtNombre.Text;
                                                    medic.COMENTARIO = txtComentario.Text;
                                                    medic.COD_BARRAS = txtCodBarras.Text;
                                                    medic.CFDI = Convert.ToInt32(txtCFDI.Text);
                                                    medic.U_MEDIDA = txtUMedida.Text;
                                                    medic.P_COMPRA = Decimal.Parse(txtPCompra.Text);
                                                    medic.P_MEDICOS = Decimal.Parse(txtPMedicos.Text);
                                                    medic.P_VENTA = Decimal.Parse(txtPVenta.Text);
                                                    medic.CANTIDAD = Convert.ToInt32(txtCantidad.Text);
                                                    medic.CADUCIDAD = dpCaducidad.SelectedDate;
                                                    medic.ALMACEN = cbbAlmacen.Text;
                                                    medic.FECHA_MOD = fec;
                                                    
                                                    BaseDatos.GetBaseDatos().SaveChanges();
                                                    MessageBoxResult result = MessageBox.Show("Se actualizó correctamente el medicamento", "Farmacia");
                                                    Limpiar();
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            GuardarMedicamento();
        }

        public void Limpiar()
        {
            txtNombre.Text = String.Empty;
            txtCantidad.Text = String.Empty;
            txtComentario.Text = String.Empty;
            txtPVenta.Text = String.Empty;
            txtPCompra.Text = String.Empty;
            txtPMedicos.Text = String.Empty;
            txtDescuento.Text = String.Empty;
            txtCodBarras.Text = String.Empty;

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

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            EditarMedicamento();
        }
    }
}
