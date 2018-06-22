using AccessoDB;
using Medica2.Administracion.Empleados;
using Medica2.Administracion.Permisos;
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

namespace Medica2.Administracion.Usuarios
{
    /// <summary>
    /// Lógica de interacción para AgregarUsuarios.xaml
    /// </summary>
    public partial class AgregarUsuarios : Window
    {
        public AgregarUsuarios()
        {
            InitializeComponent();
            LlenarAutocomlete();

        }

        public AgregarUsuarios(USUARIO idu, bool fals )
        {
            InitializeComponent();
            LlenarAutocomlete();



        }

        void LlenarAutocomlete()
        {


            autoempleado.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                        join e in BaseDatos.GetBaseDatos().EMPLEADOS
                                        on PERSONA.ID_PERSONA equals e.PERSONAID
                                        where PERSONA.ESTADOPERSONA=="Activo"

                                        select new
                                        {
                                            ID_PERSONA = PERSONA.ID_PERSONA,
                                            ID_EMPLEADO = e.ID_EMPLEADO,
                                            NOMBRE = PERSONA.NOMBRE+" "+PERSONA.A_PATERNO+" "+PERSONA.A_PATERNO,


                                        }).ToList();

            autoPermiso.ItemsSource = BaseDatos.GetBaseDatos().PERMISOS.ToList();
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

        private void txtNombre_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
                e.Handled = false;
            else if (e.Key == Key.Decimal)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void validarNumLetras(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 46)

                e.Handled = false;

            else e.Handled = true;
            ///

        }

        void Limpiar()
        {
            autoempleado.SearchText = String.Empty;
            txtcontraseña.Text = "";
            autoPermiso.SearchText = String.Empty;

        }

        void Guardar()
        {
            if (autoempleado.SelectedItem == null)
            {
                MessageBox.Show("Seleccion un Empleado");
            }
            else
            {
                if (txtcontraseña.Text == "")
                {
                    MessageBox.Show("Ingresa la Contraseña");
                }
                else
                {
                    if (autoPermiso.SelectedItem == null)
                    {
                        MessageBox.Show("Ingrsa el Permiso");
                    }
                    else
                    {
                        DateTime fregistro = DateTime.Now;


                        dynamic emple = autoempleado.SelectedItem;
                        int idemple = emple.ID_EMPLEADO;
                        int idperm = ((PERMISO)autoPermiso.SelectedItem).ID_PERMISO;

                        USUARIO usu = new USUARIO
                        {
                            EMPLEADOID = idemple,
                            CONTRASENA = txtcontraseña.Text,
                            PERMISOSID = idperm,

                            FECHA_CREACION = fregistro
                        };
                        BaseDatos.GetBaseDatos().USUARIOS.Add(usu);
                        BaseDatos.GetBaseDatos().SaveChanges();

                        Limpiar();
                        this.Close();

                    }
                }

            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            RegistroEmpleados emp = new RegistroEmpleados(autoempleado);
            emp.Show();

        }

        private void btnRegistrar_Permiso_Click(object sender, RoutedEventArgs e)
        {
            RegistroPermisosUsuarios rpu = new RegistroPermisosUsuarios(autoPermiso);
            rpu.Show();

        }

        private void btncancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnguardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }
    }
}
