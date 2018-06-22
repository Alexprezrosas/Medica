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
using Telerik.WinControls.UI;
using Telerik.Windows.Controls;


namespace Medica2.Administracion.Permisos
{
    /// <summary>
    /// Lógica de interacción para RegistroPermisosUsuarios.xaml
    /// </summary>
    public partial class RegistroPermisosUsuarios : Window
    {
        private Telerik.Windows.Controls.RadAutoCompleteBox autoPermiso;

        public RegistroPermisosUsuarios()
        {
            InitializeComponent();


        }
        public RegistroPermisosUsuarios(Telerik.Windows.Controls.RadAutoCompleteBox autoPermiso)
        {
            InitializeComponent();
            this.autoPermiso = autoPermiso;
        }

        void Limpiar()
        {
            txtnombrep.Text = String.Empty;
            txtdescripcion.Text = String.Empty;
            txtmodulos.Text = String.Empty;
            txtrol.Text = String.Empty;
        }
        void Guardar()
        {
            if (txtnombrep.Text == "")
            {
                MessageBox.Show("Ingresa en nombre del Permiso");
            }
            else
            {
                if (txtdescripcion.Text == "")
                {
                    MessageBox.Show("Ingresa una Descripcion");
                }
                else
                {
                    if (txtmodulos.Text == "")
                    {
                        MessageBox.Show("Ingresa el nombre de los Modulos");
                    }
                    else
                    {
                        if (txtrol.Text == "")
                        {
                            MessageBox.Show("Ingresa el Rol");
                        }
                        else
                        {
                            PERMISO permi = new PERMISO
                            {
                                NOM_PERMISO = txtnombrep.Text,
                                DESCIPCION = txtdescripcion.Text,
                                MODULOS = txtmodulos.Text,
                                ROL = txtrol.Text,
                            };
                            BaseDatos.GetBaseDatos().PERMISOS.Add(permi);
                            BaseDatos.GetBaseDatos().SaveChanges();

                            autoPermiso.ItemsSource = BaseDatos.GetBaseDatos().PERMISOS.ToList();

                            Limpiar();
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click_1(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
