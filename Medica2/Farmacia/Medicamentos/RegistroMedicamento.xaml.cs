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
using Telerik.Windows.Controls;

namespace Medica2.Farmacia.Medicamentos
{
    /// <summary>
    /// Lógica de interacción para RegistroMedicamento.xaml
    /// </summary>
    public partial class RegistroMedicamento : Window
    {
        DateTime fechareg = DateTime.Now;
        private RadAutoCompleteBox autoMedicamentos;

        public RegistroMedicamento()
        {
            InitializeComponent();
        }

        public RegistroMedicamento(RadAutoCompleteBox autoMedicamento)
        {
            InitializeComponent();
            autoMedicamentos = autoMedicamento;
            btnGuardar.Visibility = Visibility.Hidden;
            btnCompras.Visibility = Visibility.Visible;
        }

        public RegistroMedicamento(RadAutoCompleteBox autoMedicamento, int m)
        {
            InitializeComponent();
            autoMedicamentos = autoMedicamento;
            lblPVenta.Visibility = Visibility.Visible;
            lblPMedicos.Visibility = Visibility.Visible;
            txtPVenta.Visibility = Visibility.Visible;
            txtPMedicos.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Hidden;
            btnConversion.Visibility = Visibility.Visible;
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

        private void validarDecimal(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else if (e.Key == Key.Decimal)
                e.Handled = false;
            else
                e.Handled = true;
        }

        void limpiar()
        {
            txtNombre.Text = String.Empty;
            txtComentario.Text = String.Empty;
            txtUMedida.Text = String.Empty;
            cbbAlmacen.SelectedIndex = -1;
        }

        void Guardar()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa un nombre");
            }else
            {
                if (txtComentario.Text == "")
                {
                    MessageBox.Show("Ingresa una descripción");
                }else
                {
                    if (cbbAlmacen.Text == "")
                    {
                        MessageBox.Show("Selecciona un tipo de almacén");
                    }else
                    {
                        CATALOGO_MEDICAMENTOS med = new CATALOGO_MEDICAMENTOS()
                        {
                            NOMBRE_MEDI = txtNombre.Text,
                            COMENTARIO = txtComentario.Text,
                            ALMACEN = cbbAlmacen.Text,
                            CANTIDAD = 0,
                            U_MEDIDA = txtUMedida.Text,
                            FECHA_CREACION = fechareg,
                            STATUS = "Activo"
                        };
                        BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Add(med);
                        BaseDatos.GetBaseDatos().SaveChanges();
                        limpiar();
                        MessageBox.Show("Registro exitoso");
                    }
                }
            }
        }

        void GuardarCompras()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa un nombre");
            }
            else
            {
                if (txtComentario.Text == "")
                {
                    MessageBox.Show("Ingresa una descripción");
                }
                else
                {
                    if (cbbAlmacen.Text == "")
                    {
                        MessageBox.Show("Selecciona un tipo de almacén");
                    }
                    else
                    {
                        CATALOGO_MEDICAMENTOS med = new CATALOGO_MEDICAMENTOS()
                        {
                            NOMBRE_MEDI = txtNombre.Text,
                            COMENTARIO = txtComentario.Text,
                            ALMACEN = cbbAlmacen.Text,
                            CANTIDAD = 0,
                            U_MEDIDA = txtUMedida.Text,
                            FECHA_CREACION = fechareg,
                            STATUS = "Activo"
                        };
                        BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Add(med);
                        BaseDatos.GetBaseDatos().SaveChanges();
                        limpiar();
                        autoMedicamentos.ItemsSource = (from medi in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                                        where medi.STATUS == "Activo"
                                                        select new
                                                        {
                                                            ID_MEDICAMENTO = medi.ID_MEDICAMENTO,
                                                            NOMBRE = medi.NOMBRE_MEDI + " " + medi.COMENTARIO + " " + medi.U_MEDIDA
                                                        });
                        MessageBox.Show("Registro exitoso");
                        this.Close();
                    }
                }
            }
        }

        void GuardarConversion()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa un nombre");
            }
            else
            {
                if (txtComentario.Text == "")
                {
                    MessageBox.Show("Ingresa una descripción");
                }
                else
                {
                    if (cbbAlmacen.Text == "")
                    {
                        MessageBox.Show("Selecciona un tipo de almacén");
                    }
                    else
                    {
                        if (txtPVenta.Text == "")
                        {
                            MessageBox.Show("Ingresa el precio de venta");
                        }else
                        {
                            if (txtPMedicos.Text == "")
                            {
                                MessageBox.Show("Ingresa el precio pra médicos");
                            }else
                            {
                                CATALOGO_MEDICAMENTOS med = new CATALOGO_MEDICAMENTOS()
                                {
                                    NOMBRE_MEDI = txtNombre.Text,
                                    COMENTARIO = txtComentario.Text,
                                    ALMACEN = cbbAlmacen.Text,
                                    CANTIDAD = 0,
                                    U_MEDIDA = txtUMedida.Text,
                                    FECHA_CREACION = fechareg,
                                    STATUS = "Activo",
                                    P_VENTA = Decimal.Parse(txtPVenta.Text),
                                    P_MEDICOS = Decimal.Parse(txtPMedicos.Text)
                                };
                                BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Add(med);
                                BaseDatos.GetBaseDatos().SaveChanges();
                                limpiar();
                                autoMedicamentos.ItemsSource = (from medi in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                                                where medi.STATUS == "Activo"
                                                                select new
                                                                {
                                                                    ID_MEDICAMENTO = medi.ID_MEDICAMENTO,
                                                                    NOMBRE = medi.NOMBRE_MEDI + " " + medi.COMENTARIO + " " + medi.U_MEDIDA
                                                                });
                                MessageBox.Show("Registro exitoso");
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCompras_Click(object sender, RoutedEventArgs e)
        {
            GuardarCompras();
        }

        private void btnConversion_Click(object sender, RoutedEventArgs e)
        {
            GuardarConversion();
        }
    }
}
