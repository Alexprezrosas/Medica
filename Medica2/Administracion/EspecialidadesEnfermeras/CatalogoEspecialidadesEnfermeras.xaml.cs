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

namespace Medica2.Administracion.EspecialidadesEnfermeras
{
    /// <summary>
    /// Lógica de interacción para CatalogoEspecialidadesEnfermeras.xaml
    /// </summary>
    public partial class CatalogoEspecialidadesEnfermeras : Window
    {
        public CatalogoEspecialidadesEnfermeras()
        {
            InitializeComponent();

        }
        public void Guardar()
        {
            if (txtNombre.Text == "")
            {
                System.Windows.MessageBox.Show("Inserta el nombre de la especialidad");
            }
            else
            {
                if (txtDescripcion.Text == "")
                {
                    System.Windows.MessageBox.Show("Inserta la Descripcion");
                }
                else
                {

                    DateTime fec = DateTime.Now;

                    CATALOGO_ESPECIALIDADES cespe = new CATALOGO_ESPECIALIDADES
                    {
                        NOMBRE_ESPECIALIDAD = txtNombre.Text,
                        DESCRIPCION = txtDescripcion.Text,
                        FECHA_CREACION = fec

                    };
                    BaseDatos.GetBaseDatos().CATALOGO_ESPECIALIDADES.Add(cespe);
                    BaseDatos.GetBaseDatos().SaveChanges();
                    System.Windows.MessageBox.Show("Registro exitoso. Se ha guardado CORRECTAMENTE");

                    txtNombre.Text = String.Empty;
                    txtDescripcion.Text = String.Empty;

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
            ConsultarCatalogoEspecialidadesEnfermeras cespecialidades = new ConsultarCatalogoEspecialidadesEnfermeras();
            cespecialidades.Show();
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
    }

}


