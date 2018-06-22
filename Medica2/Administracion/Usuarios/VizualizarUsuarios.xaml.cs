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
using Telerik.Windows.Controls.GridView;

namespace Medica2.Administracion.Usuarios
{
    /// <summary>
    /// Lógica de interacción para VizualizarUsuarios.xaml
    /// </summary>
    public partial class VizualizarUsuarios : Window
    {
        public VizualizarUsuarios()
        {
            InitializeComponent();

        }

        public void VistaGrid()
        {
            rgvUsuarios.ItemsSource = (from usuario in BaseDatos.GetBaseDatos().USUARIOS
                                       join emple in BaseDatos.GetBaseDatos().EMPLEADOS
                                       on usuario.EMPLEADOID equals emple.ID_EMPLEADO
                                       join person in BaseDatos.GetBaseDatos().PERSONAS
                                       on emple.PERSONAID equals person.ID_PERSONA
                                       where person.ESTADOPERSONA == "Activo"
                                       select new
                                       {
                                           IDUSUARIO = usuario.ID_USUARIO,
                                           IDEMPLEADO = emple.ID_EMPLEADO,
                                           IDPERSONA = person.ID_PERSONA,
                                           NOMBRE = person.NOMBRE,
                                           APATERNO = person.A_PATERNO,
                                           AMATERNO = person.A_MATERNO,
                                           CONTRASENA = usuario.CONTRASENA,
                                           PUESTO = emple.PUESTO
                                       });
        }

        public void VistaGridTodos()
        {
            rgvUsuarios.ItemsSource = (from usuario in BaseDatos.GetBaseDatos().USUARIOS
                                       join emple in BaseDatos.GetBaseDatos().EMPLEADOS
                                       on usuario.EMPLEADOID equals emple.ID_EMPLEADO
                                       join person in BaseDatos.GetBaseDatos().PERSONAS
                                       on emple.PERSONAID equals person.ID_PERSONA
                                       select new
                                       {
                                           IDUSUARIO = usuario.ID_USUARIO,
                                           IDEMPLEADO = emple.ID_EMPLEADO,
                                           IDPERSONA = person.ID_PERSONA,
                                           NOMBRE = person.NOMBRE,
                                           APATERNO = person.A_PATERNO,
                                           AMATERNO = person.A_MATERNO,
                                           CONTRASENA = usuario.CONTRASENA,
                                           PUESTO = emple.PUESTO
                                       });

        }

        private GridViewRow ClickedRow
        {
            get
            {
                return this.GridContextMenu2.GetClickedElement<GridViewRow>();
            }


        }

        private void GridContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            if (ClickedRow != null)
            {
                itemAgregar.IsEnabled = true;
                itemEliminar.IsEnabled = true;
                itemEditar.IsEnabled = true;

            }

        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemAgregar)
            {
                AgregarUsuarios nu = new AgregarUsuarios();
                nu.Show();
                this.Close();
            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el usuario?", "Administracion", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            dynamic usuario = rgvUsuarios.SelectedItem;
                            int idusu = usuario.IDUSUARIO;

                            if (rgvUsuarios.SelectedItem != null)
                            {
                                var usu = BaseDatos.GetBaseDatos().USUARIOS.Find(idusu);
                                usu.EMPLEADO.PERSONA.ESTADOPERSONA = "Inactivo";
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado el usuario", "Administracion");
                            VistaGrid();

                            ////

                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
                else
                {
                    if (sender == itemEditar)
                    {
                        if (rgvUsuarios.SelectedItem != null)
                        {
                            dynamic usuar = rgvUsuarios.SelectedItem;
                            int idusu = usuar.IDUSUARIO;
                            var usuari = BaseDatos.GetBaseDatos().USUARIOS.Find(idusu);

                            AgregarUsuarios au = new AgregarUsuarios((USUARIO)usuari, false);
                            au.Show();
                            this.Close();
                        }
                    }
                }

            }
        }

        private void checkboxenfe_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbUsuarios.IsChecked == true)
            {
                VistaGridTodos();
            }
        }

        private void checkboxenfe_Checked(object sender, RoutedEventArgs e)
        {
            if (cbUsuarios.IsChecked == false)
            {
                VistaGrid();
            }
        }
    }
}
