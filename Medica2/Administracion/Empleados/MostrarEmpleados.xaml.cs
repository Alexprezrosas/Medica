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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Medica2.Administracion.Empleados
{
    /// <summary>
    /// Lógica de interacción para MostrarEmpleados.xaml
    /// </summary>
    public partial class MostrarEmpleados : Window
    {
        int idUsuario;
        public MostrarEmpleados()
        {
            InitializeComponent();
            VistaEmpleadoPersonaActivo();
        }

        public MostrarEmpleados(int idu)
        {
            InitializeComponent();
            VistaEmpleadoPersonaActivo();
            idUsuario = idu;
            var usuario = BaseDatos.GetBaseDatos().USUARIOS.Find(idu);
            if (usuario.EMPLEADO.PUESTO == "Administrador")
            {
                GridContextMenu2.Visibility = Visibility.Visible;
            }else
            {
                if (usuario.EMPLEADO.PUESTO == "Recepcionista")
                {
                    itemEditar.Visibility = Visibility.Hidden;
                    itemEliminar.Visibility = Visibility.Hidden;
                }
            }
        }

        public void VistaEmpleadoPersonaActivo()
        {
            rgMostrarEmpleados.ItemsSource = (from Usuario in BaseDatos.GetBaseDatos().USUARIOS
                                              join emple in BaseDatos.GetBaseDatos().EMPLEADOS
                                              on Usuario.EMPLEADOID equals emple.ID_EMPLEADO
                                              join person in BaseDatos.GetBaseDatos().PERSONAS
                                              on emple.PERSONAID equals person.ID_PERSONA
                                              where person.ESTADOPERSONA == "Activo"
                                              select new
                                              {
                                                  ID_USUARIO = Usuario.ID_USUARIO,
                                                  ID_EMPLEADO = emple.ID_EMPLEADO,
                                                  NOMBRE = person.NOMBRE,
                                                  A_PATERNO = person.A_PATERNO,
                                                  A_MATERNO = person.A_MATERNO,
                                                  FNACIMIENTO = person.F_NACIMIENTO,
                                                  SEXO = person.SEXO.ToString(),
                                                  CALLE = person.CALLE,
                                                  ESTADO = person.ESTADO1.nombre,
                                                  NOMUNI = person.NOMMUNICIPIO,
                                                  NOMLOC = person.NOMLOCALIDAD,
                                                  T_CELULAR = person.T_CELULAR,
                                                  CURP = person.CURP,
                                                  FECHA_CREACION = person.FECHA_CREACION,
                                                  CONTRA = Usuario.CONTRASENA,
                                                  PUESTO = emple.PUESTO,
                                                  ESTADOP = person.ESTADOPERSONA


                                              });

        }
        public void VistaEmpleadoPersonaTodos()
        {
            rgMostrarEmpleados.ItemsSource = (from Usuario in BaseDatos.GetBaseDatos().USUARIOS
                                              join emple in BaseDatos.GetBaseDatos().EMPLEADOS
                                              on Usuario.EMPLEADOID equals emple.ID_EMPLEADO
                                              join person in BaseDatos.GetBaseDatos().PERSONAS
                                              on emple.PERSONAID equals person.ID_PERSONA
                                              select new
                                              {
                                                  ID_USUARIO = Usuario.ID_USUARIO,
                                                  ID_EMPLEADO = emple.ID_EMPLEADO,
                                                  NOMBRE = person.NOMBRE,
                                                  A_PATERNO = person.A_PATERNO,
                                                  A_MATERNO = person.A_MATERNO,
                                                  FNACIMIENTO = person.F_NACIMIENTO,
                                                  SEXO = person.SEXO.ToString(),
                                                  CALLE = person.CALLE,
                                                  ESTADO = person.ESTADO1.nombre,
                                                  NOMUNI = person.NOMMUNICIPIO,
                                                  NOMLOC = person.NOMLOCALIDAD,
                                                  T_CELULAR = person.T_CELULAR,
                                                  CURP = person.CURP,
                                                  FECHA_CREACION = person.FECHA_CREACION,
                                                  CONTRA = Usuario.CONTRASENA,
                                                  PUESTO = emple.PUESTO,
                                                  ESTADOP = person.ESTADOPERSONA


                                              });

        }
        private void radGridView_BeginningEdit(object sender, Telerik.Windows.Controls.GridViewBeginningEditRoutedEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "ID_MEDICO")
            {
                ToolTipService.SetToolTip(e.Cell, "La edición de la ID puede provocar una incoherencia en la base de datos");
            }
        }

        private void clubsGrid_PreparingCellForEdit(object sender, GridViewPreparingCellForEditEventArgs e)
        {
            if ((string)e.Column.Header == "PERSONAID")
            {
                var tb = e.EditingElement as TextBox;
                tb.TextWrapping = TextWrapping.Wrap;
            }
        }

        private void MostrarCirugias_SelectedCellsChanged(object sender, Telerik.Windows.Controls.GridView.GridViewSelectedCellsChangedEventArgs e)
        {
            BaseDatos.GetBaseDatos().SaveChanges();
        }
        //editar

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
                this.Close();
                RegistroEmpleados obj = new RegistroEmpleados();
                obj.Show();

                rgMostrarEmpleados.ItemsSource = BaseDatos.GetBaseDatos().EMPLEADOS.ToList();

            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el Empleado?", "Administracion Empleados", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            if (rgMostrarEmpleados.SelectedItem != null)
                            {


                                dynamic emple = rgMostrarEmpleados.SelectedItem;
                                int idemple = emple.ID_USUARIO;

                                var usuario = BaseDatos.GetBaseDatos().USUARIOS.Find(idemple);
                                usuario.EMPLEADO.PERSONA.ESTADOPERSONA = "Inactivo";

                                BaseDatos.GetBaseDatos().SaveChanges();
                                MessageBox.Show("Se ha eliminado el Empleado", "Administracion Empleados");
                                VistaEmpleadoPersonaActivo();
                            }


                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
                else
                {
                    if (sender == itemEditar)
                    {
                        if (rgMostrarEmpleados.SelectedItem != null)
                        {
                            dynamic objemple = rgMostrarEmpleados.SelectedItem;
                            int idemp = objemple.ID_EMPLEADO;
                            int idus = objemple.ID_USUARIO;
                            var idusu = BaseDatos.GetBaseDatos().USUARIOS.Find(idus);
                            var cemple = BaseDatos.GetBaseDatos().EMPLEADOS.Find(idemp);

                            RegistroEmpleados nempl = new RegistroEmpleados((EMPLEADO)cemple, (USUARIO)idusu, false);
                            nempl.Show();
                            this.Close();
                        }
                    }
                }
                VistaEmpleadoPersonaActivo();

            }

        }

        private void checkBoxmedicos_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxempleados.IsChecked == true)
            {
                VistaEmpleadoPersonaTodos();
            }
        }

        private void checkBoxmedicos_Unchecked(object sender, RoutedEventArgs e)
        {
            if (checkBoxempleados.IsChecked == false)
            {
                VistaEmpleadoPersonaActivo();
            }
        }
    }
}
