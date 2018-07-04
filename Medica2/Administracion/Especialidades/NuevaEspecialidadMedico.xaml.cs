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

namespace Medica2.Administracion.Especialidades
{
    /// <summary>
    /// Lógica de interacción para NuevaEspecialidadMedico.xaml
    /// </summary>
    public partial class NuevaEspecialidadMedico : Window
    {
        int idespci;
        public NuevaEspecialidadMedico()
        {
            InitializeComponent();
        }
        public NuevaEspecialidadMedico(CATALOGO_ESPECIALIDADES especialidad, bool save)
        {
            InitializeComponent();
            idespci = especialidad.ID_CATALOGO_ESPECIALIDAD;
            txtNombre.Text = especialidad.NOMBRE_ESPECIALIDAD;
            txtDescripcion.Text = especialidad.DESCRIPCION;

            btnGuardar.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Visible;

        }
        //MEtodo Guardar un nuevo Cuarto
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
                        FECHA_CREACION = fec,
                        STATUS = "Activo"

                    };
                    BaseDatos.GetBaseDatos().CATALOGO_ESPECIALIDADES.Add(cespe);
                    BaseDatos.GetBaseDatos().SaveChanges();
                    System.Windows.MessageBox.Show("Se ha guardado CORRECTAMENTE");

                    txtNombre.Text = String.Empty;
                    txtDescripcion.Text = String.Empty;

                }
            }
        }

        public void Editar()
        {
            if (txtNombre.Text == "")
            {
                System.Windows.MessageBox.Show("Inserta el nombre de la especialidad");
            }
            else
            {
                if (txtDescripcion.Text == "")
                {
                    System.Windows.MessageBox.Show("Inserta la descripción");
                }
                else
                {
                    DateTime fec = DateTime.Now;

                    var newesp = BaseDatos.GetBaseDatos().CATALOGO_ESPECIALIDADES.Find(idespci);

                    newesp.NOMBRE_ESPECIALIDAD = txtNombre.Text;
                    newesp.DESCRIPCION = txtDescripcion.Text;

                    BaseDatos.GetBaseDatos().SaveChanges();
                    MessageBox.Show("Registro exitoso, actualización Correcta");
                    Limpiar();
                }
            }
        }

        void Limpiar()
        {
            txtDescripcion.Text = "";
            txtNombre.Text = "";
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            Guardar();
            Close();

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //ConsultarCatalogoEspecialidades cespecialidades = new ConsultarCatalogoEspecialidades();
            //cespecialidades.Show();
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

        private void btnEditar_Click_1(object sender, RoutedEventArgs e)
        {
            Editar();
            Close();
        }
    }
}
