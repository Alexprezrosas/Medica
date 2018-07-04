using AccessoDB;
using Medica2.Administracion.Clasificacion_Estudios;
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

namespace Medica2.Administracion.Estudios
{
    /// <summary>
    /// Lógica de interacción para NuevoEstudio.xaml
    /// </summary>
    public partial class NuevoEstudio : Window
    {
        int idestudi;
        int idclasi;
        public NuevoEstudio()
        {

            InitializeComponent();
            AutoClasifica.ItemsSource = BaseDatos.GetBaseDatos().CLASIFICACION_ESTUDIOS.ToList();

        }

        public NuevoEstudio(CATALOGO_ESTUDIOS ces, CLASIFICACION_ESTUDIOS claes, bool save)
        {

            InitializeComponent();
            AutoClasifica.ItemsSource = BaseDatos.GetBaseDatos().CLASIFICACION_ESTUDIOS.ToList();

            idestudi = ces.CATALOGO_ESTUDIO_ID;
            idclasi = claes.CLASIFICACIONID;

            txtNombre.Text = ces.NOMBRE;
            txtDescripcion.Text = ces.DESCRIPCION;
            txtCosto.Text = ces.COSTO.ToString();
            AutoClasifica.SearchText = claes.NOMBRE;

            btnEditar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Hidden;

        }
        public void Guardar()
        {
            //AutoClasifica.ItemsSource = BaseDatos.GetBaseDatos().CLASIFICACION_ESTUDIOS.ToList();
            if (txtNombre.Text == "")
            {
                System.Windows.MessageBox.Show("Ingrese un nombre");
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
                        System.Windows.MessageBox.Show("Ingrese el costo");
                    }
                    else
                    {
                        if (AutoClasifica.SelectedItem == null)
                        {
                            MessageBox.Show("Selecciona una Clasificacion");
                        }
                        else
                        {
                            DateTime fec = DateTime.Now;

                            int idClasifica = ((CLASIFICACION_ESTUDIOS)AutoClasifica.SelectedItem).CLASIFICACIONID;
                            CATALOGO_ESTUDIOS cestudio = new CATALOGO_ESTUDIOS
                            {

                                NOMBRE = txtNombre.Text,
                                DESCRIPCION = txtDescripcion.Text,
                                COSTO = Decimal.Parse(txtCosto.Text),
                                FECHA_CREACION = fec,
                                CLASIFICACIONID = idClasifica,
                                STATUS = "Activo"

                            };
                            BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Add(cestudio);
                            BaseDatos.GetBaseDatos().SaveChanges();
                            //Mensaje
                            MessageBoxResult result = MessageBox.Show("Registro exitoso");
                            Limpiar();
                            this.Close();
                        }

                    }
                }
            }
        }
        public void Editar()
        {
            //AutoClasifica.ItemsSource = BaseDatos.GetBaseDatos().CLASIFICACION_ESTUDIOS.ToList();
            if (txtNombre.Text == "")
            {
                System.Windows.MessageBox.Show("Ingrese un nombre");
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
                        System.Windows.MessageBox.Show("Ingrese el costo");
                    }
                    else
                    {
                        if (AutoClasifica.SelectedItem == null)
                        {
                            MessageBox.Show("Selecciona una Clasificación");
                        }
                        else
                        {
                            DateTime fec = DateTime.Now;
                            dynamic autoc = AutoClasifica.SelectedItem;
                            idclasi = autoc.CLASIFICACIONID;
                            //var clasi = BaseDatos.GetBaseDatos().CLASIFICACION_ESTUDIOS.Find(idclas);


                            var cestudioe = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(idestudi);

                            cestudioe.NOMBRE = txtNombre.Text;
                            cestudioe.DESCRIPCION = txtDescripcion.Text;
                            cestudioe.COSTO = Decimal.Parse(txtCosto.Text);
                            cestudioe.CLASIFICACIONID = idclasi;

                            BaseDatos.GetBaseDatos().SaveChanges();

                            //Mensaje
                            MessageBoxResult result = MessageBox.Show("Registro exitoso, se actualizo correctamente ");
                            Limpiar();
                            this.Close();
                        }

                    }
                }
            }
        }
        void Limpiar()
        {
            //Limpiar los textBox
            txtNombre.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCosto.Text = String.Empty;
            AutoClasifica.SearchText = string.Empty;
            //Limpiar autocomplete

        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
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

            if (ascci >= 46 && ascci <= 57) e.Handled = false;

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

        private void btnnuevaclasificacion_Click(object sender, RoutedEventArgs e)
        {
            //se crea un objeto de la venta Nuevaclasificacion y se le pasa el valor del AutoComplete
            NuevaClasificacionEstudios obj = new NuevaClasificacionEstudios(AutoClasifica);
            obj.Show();


        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }
    }

}
