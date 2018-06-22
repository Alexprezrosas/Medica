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
        private RadAutoCompleteBox autoMedi;

        public RegistroMedicamento()
        {
            InitializeComponent();
        }

        public RegistroMedicamento(RadAutoCompleteBox autoMedicamentos)
        {
            InitializeComponent();
            autoMedi = autoMedicamentos;
            btnGuardar.Visibility = Visibility.Hidden;
            btnCompras.Visibility = Visibility.Visible;
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
                            FECHA_CREACION = fechareg
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
                            FECHA_CREACION = fechareg
                        };
                        BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Add(med);
                        BaseDatos.GetBaseDatos().SaveChanges();
                        limpiar();
                        autoMedi.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.ToList();
                        MessageBox.Show("Registro exitoso");
                        this.Close();
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
    }
}
