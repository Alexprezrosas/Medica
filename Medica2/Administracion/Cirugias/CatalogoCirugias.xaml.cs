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

namespace Medica2.Administracion.Cirugias
{
    /// <summary>
    /// Lógica de interacción para CatalogoCirugias.xaml
    /// </summary>
    public partial class CatalogoCirugias : Window
    {
        int idCirugia;
        public CatalogoCirugias()
        {
            InitializeComponent();

        }

        public CatalogoCirugias(int idciru, bool save)
        {
            InitializeComponent();
            idCirugia = idciru;
            var cirugita = BaseDatos.GetBaseDatos().CATALOGO_CIRUGIAS.Find(idCirugia);

            txtNombre.Text = cirugita.NOMBRE_CIRUGIA;
            txtDescripcion.Text = cirugita.DESCRIPCION;
            txtCosto.Text = cirugita.COSTO.ToString();

            btnEditar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Hidden;


        }
        private void guardar()
        {
            if (txtNombre.Text == "")
            {
                System.Windows.MessageBox.Show("Ingrese el nombre de la cirugía");
            }
            else
            {
                if (txtDescripcion.Text == "")
                {
                    System.Windows.MessageBox.Show("Ingrese una Descripción");
                }
                else
                {
                    if (txtCosto.Text == "")
                    {
                        System.Windows.MessageBox.Show("Ingrese el costo de la cirugía");
                    }
                    else
                    {
                        DateTime fec = DateTime.Now;

                        CATALOGO_CIRUGIAS cciru = new CATALOGO_CIRUGIAS
                        {

                            NOMBRE_CIRUGIA = txtNombre.Text,
                            DESCRIPCION = txtDescripcion.Text,
                            COSTO = Decimal.Parse(txtCosto.Text),
                            FECHA_CREACION = fec,
                            ESTATUS = "Activo"

                        };

                        BaseDatos.GetBaseDatos().CATALOGO_CIRUGIAS.Add(cciru);
                        BaseDatos.GetBaseDatos().SaveChanges();
                        System.Windows.MessageBox.Show("Registro exitoso, se ha guardado correctamente");

                        txtNombre.Text = String.Empty;
                        txtDescripcion.Text = String.Empty;
                        txtCosto.Text = String.Empty;

                    }
                }
            }
        }

        private void Editar()
        {
            if (txtNombre.Text == "")
            {
                System.Windows.MessageBox.Show("Ingresa el nombre de la cirugía");
            }
            else
            {
                if (txtDescripcion.Text == "")
                {
                    System.Windows.MessageBox.Show("Ingrese una descripción");
                }
                else
                {
                    if (txtCosto.Text == "")
                    {
                        System.Windows.MessageBox.Show("Ingrese el costo de la cirugía");
                    }
                    else
                    {
                        var cirug = BaseDatos.GetBaseDatos().CATALOGO_CIRUGIAS.Find(idCirugia);
                        cirug.NOMBRE_CIRUGIA = txtNombre.Text;
                        cirug.DESCRIPCION = txtDescripcion.Text;
                        cirug.COSTO = Decimal.Parse(txtCosto.Text);

                        BaseDatos.GetBaseDatos().SaveChanges();
                        System.Windows.MessageBox.Show("Registro exitoso, se actualizo correctamente");
                        Limpiar();

                    }
                }
            }
        }
        void Limpiar()
        {
            txtNombre.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCosto.Text = String.Empty;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            guardar();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }
    }
}
