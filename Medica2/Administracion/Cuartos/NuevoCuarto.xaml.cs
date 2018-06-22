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

namespace Medica2.Administracion.Cuartos
{
    /// <summary>
    /// Lógica de interacción para NuevoCuarto.xaml
    /// </summary>
    public partial class NuevoCuarto : Window
    {
        public NuevoCuarto()
        {
            InitializeComponent();
        }

        //MEtodo Guardar un nuevo Cuarto
        public void Guardar()
        {
            if (txtNombre.Text == "")
            {
                System.Windows.MessageBox.Show("Inserta el nombre del Cuarto");
            }
            else
            {
                if (txtDescripcion.Text == "")
                {
                    System.Windows.MessageBox.Show("Inserta la Descripcion");
                }
                else
                {
                    if (txtCosto.Text == "")
                    {
                        System.Windows.MessageBox.Show("Inserta el Costo");
                    }
                    else
                    {
                        if (txtmaxpersonas.Text == "")
                        {
                            MessageBox.Show("Inserta el numero de personas");
                        }
                        else
                        {

                            DateTime fec = DateTime.Now;

                            CATALOGO_CUARTOS ccuartos = new CATALOGO_CUARTOS
                            {
                                NOMBRE_CUARTO = txtNombre.Text,
                                DESCRIPCION = txtDescripcion.Text,
                                COSTO = Decimal.Parse(txtCosto.Text),
                                MAX_PACIENTES = int.Parse(txtmaxpersonas.Text),
                                FECHA_CREACION = fec,
                                ESTADO="Libre",

                            };
                            BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Add(ccuartos);
                            BaseDatos.GetBaseDatos().SaveChanges();
                            System.Windows.MessageBox.Show("Registro Exitoso, se guardo CORRECTAMENTE");

                            txtNombre.Text = String.Empty;
                            txtDescripcion.Text = String.Empty;
                            txtCosto.Text = String.Empty;

                            this.Close();
                        }

                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            Guardar();
            Close();

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ConsultaCatalogoCuartos ccuarto = new ConsultaCatalogoCuartos();
            ccuarto.Show();
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

            if (ascci >= 44 && ascci <= 57) e.Handled = false;

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

        private void validarDecimal(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else if (e.Key == Key.Decimal)
                e.Handled = false;
            else
                e.Handled = true;
        }

    }
}
