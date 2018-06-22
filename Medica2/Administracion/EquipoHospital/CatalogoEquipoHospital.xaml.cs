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

namespace Medica2.Administracion.EquipoHospital
{
    /// <summary>
    /// Lógica de interacción para CatalogoEquipoHospital.xaml
    /// </summary>
    public partial class CatalogoEquipoHospital : Window
    {
        public CatalogoEquipoHospital()
        {
            InitializeComponent();

            //FormCatalogoEqiopoH.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.ToList();

        }
        //MEtodo Guardar Equipo hospital
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

                        DateTime fec = DateTime.Now;

                        CATALOGO_EQUIPO_HOSPITAL c_e_h = new CATALOGO_EQUIPO_HOSPITAL
                        {
                            NOM_EQUIPO_HOSPITAL = txtNombre.Text,
                            DESCRIPCION = txtDescripcion.Text,
                            COSTO = Decimal.Parse(txtCosto.Text),
                            FECHA_CREACION = fec,

                        };
                        BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.Add(c_e_h);
                        BaseDatos.GetBaseDatos().SaveChanges();
                        System.Windows.MessageBox.Show("Se ha guardado CORRECTAMENTE");

                        txtNombre.Text = String.Empty;
                        txtDescripcion.Text = String.Empty;
                        txtCosto.Text = String.Empty;

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
            ConsultaCatalogoEquipoHospital cequipoh = new ConsultaCatalogoEquipoHospital();
            cequipoh.Show();
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
    }
}
