using AccessoDB;
using Medica2.Administracion.Estudios;
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
namespace Medica2.Administracion.Clasificacion_Estudios
{
    /// <summary>
    /// Lógica de interacción para NuevaClasificacionEstudios.xaml
    /// </summary>
    public partial class NuevaClasificacionEstudios : Window
    {
        private RadAutoCompleteBox autoClasifica;//para recibir valores de autocomplete de nuevo estudio
        public NuevaClasificacionEstudios()
        {
            InitializeComponent();

        }

        //Constructor que inicializa valores para autocomplete nuevo estudio
        public NuevaClasificacionEstudios(RadAutoCompleteBox autoClasifica)
        {
            InitializeComponent();
            this.autoClasifica = autoClasifica;
        }
        //se inicializan los componentes de otra forma solo aprecera una ventana en blanco
        public void Guardar()
        {
            if (txtNombre.Text == "")
            {
                System.Windows.MessageBox.Show("Inserta el nombre de la Clasificacion");
            }
            else
            {

                DateTime fec = DateTime.Now;

                CLASIFICACION_ESTUDIOS cestudios = new CLASIFICACION_ESTUDIOS
                {
                    NOMBRE = txtNombre.Text,
                    FECHA_CREACION = fec

                };
                BaseDatos.GetBaseDatos().CLASIFICACION_ESTUDIOS.Add(cestudios);
                BaseDatos.GetBaseDatos().SaveChanges();
                //BaseDatos.GetBaseDatos().SaveChangesAsync();
                System.Windows.MessageBox.Show("Se ha guardado CORRECTAMENTE");

                txtNombre.Text = String.Empty;
                //antes de cerrar la ventana de edicion para una nueva clasificacion se declara de nueva cuenta el
                //autocomplete para actualizar sus valores
                autoClasifica.ItemsSource = BaseDatos.GetBaseDatos().CLASIFICACION_ESTUDIOS.ToList();
                //--------------
                this.Close();

            }

        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            Guardar();
            // Aqui tampoco va autoClasifica.ItemsSource = BaseDatos.GetBaseDatos().CLASIFICACION_ESTUDIOS.ToList();


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

    }
}
