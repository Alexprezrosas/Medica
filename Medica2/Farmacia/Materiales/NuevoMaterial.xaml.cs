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
using System.Windows.Forms;
using System.Globalization;

namespace Medica2.Farmacia.Materiales
{
    /// <summary>
    /// Lógica de interacción para NuevoMaterial.xaml
    /// </summary>
    public partial class NuevoMaterial : Window
    {
        

        public NuevoMaterial()
        {
            InitializeComponent();        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == "")
            {
                System.Windows.MessageBox.Show("Ingrese un nombre");
            }
            else
            {
                if (txtComentario.Text == "")
                {
                    System.Windows.MessageBox.Show("Ingrese un comentario");
                }else
                {
                    if (txtCodBarras.Text == "")
                    {
                        System.Windows.MessageBox.Show("Ingrese el codigo de barras");
                    }else
                    {
                        if (txtCantidad.Text == "")
                        {
                            System.Windows.MessageBox.Show("Ingrese la cantidad");
                        }else
                        {
                            if (txtCosto.Text == "")
                            {
                                System.Windows.MessageBox.Show("Ingrese el costo");
                            }else
                            {
                                DateTime fec = DateTime.Now;

                                CATALOGO_MATERIALES cmat = new CATALOGO_MATERIALES
                                {
                                    NOMBRE = txtNombre.Text,
                                    CANTIDAD = Int32.Parse(txtCantidad.Text),
                                    COMENTARIO = txtComentario.Text,
                                    COSTO = Decimal.Parse(txtCosto.Text),
                                    FECHA_CREACION = fec,
                                    COD_BARRAS = Int32.Parse(txtCodBarras.Text)
                                };

                                BaseDatos.GetBaseDatos().CATALOGO_MATERIALES.Add(cmat);
                                BaseDatos.GetBaseDatos().SaveChanges();
                                System.Windows.MessageBox.Show("Se ha guardado el material");

                                txtNombre.Text = String.Empty;
                                txtComentario.Text = String.Empty;
                                txtCosto.Text = String.Empty;
                                txtCodBarras.Text = String.Empty;
                                txtCantidad.Text = String.Empty;
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
    }
}
