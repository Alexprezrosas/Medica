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

namespace Medica2.Administracion.Medicos
{
    /// <summary>
    /// Lógica de interacción para MostrarMedicos.xaml
    /// </summary>
    public partial class MostrarMedicos : Window
    {
        public MostrarMedicos()
        {
            InitializeComponent();
            VistaMedicosPersona();

            //Editar
            this.rgMostrarMedico.BeginningEdit += radGridView_BeginningEdit;
            this.rgMostrarMedico.CellEditEnded += radGridView_CellEditEnded;

            //Editar
        }
        public void VistaMedicosPersona()
        {
            rgMostrarMedico.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                           join e in BaseDatos.GetBaseDatos().MEDICOS on
                                           PERSONA.ID_PERSONA equals e.PERSONAID
                                           join emple in BaseDatos.GetBaseDatos().EMPLEADOS
                                           on PERSONA.ID_PERSONA equals emple.PERSONAID
                                           join usu in BaseDatos.GetBaseDatos().USUARIOS
                                           on emple.ID_EMPLEADO equals usu.EMPLEADOID
                                           where PERSONA.ESTADOPERSONA=="Activo"
                                           select new
                                           {
                                               ID_USUARIO=usu.ID_USUARIO,
                                               ID_MEDICO = e.ID_MEDICO,
                                               NOMBRE = PERSONA.NOMBRE,
                                               A_PATERNO = PERSONA.A_PATERNO,
                                               A_MATERNO = PERSONA.A_MATERNO,

                                               FNACIMIENTO = PERSONA.F_NACIMIENTO,
                                               SEXO = PERSONA.SEXO.ToString(),
                                               CALLE = PERSONA.CALLE,
                                               ESTADO = PERSONA.ESTADO1.nombre,
                                               NOMUNI=PERSONA.NOMMUNICIPIO,
                                               NOMLOC=PERSONA.NOMLOCALIDAD,
                                               T_CELULAR = PERSONA.T_CELULAR,
                                               CURP = PERSONA.CURP,
                                               FECHA_CREACION = PERSONA.FECHA_CREACION,
                                               T_CONSULTORIO = e.T_CONSULTORIO,
                                               T_PARTICULAR = e.T_PARTICULAR,
                                               CORREO = e.CORREO,
                                               C_PROFESIONAL = e.C_PROFESIONAL,
                                               CONTRA=usu.CONTRASENA


                                           });

        }

        public void VistaMedicosTodos()
        {
            rgMostrarMedico.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                           join e in BaseDatos.GetBaseDatos().MEDICOS on
                                           PERSONA.ID_PERSONA equals e.PERSONAID
                                           join emple in BaseDatos.GetBaseDatos().EMPLEADOS
                                           on PERSONA.ID_PERSONA equals emple.PERSONAID
                                           join usu in BaseDatos.GetBaseDatos().USUARIOS
                                           on emple.ID_EMPLEADO equals usu.EMPLEADOID

                                           select new
                                           {
                                               ID_MEDICO = e.ID_MEDICO,
                                               ID_USUARIO = usu.ID_USUARIO,
                                               NOMBRE = PERSONA.NOMBRE,
                                               A_PATERNO = PERSONA.A_PATERNO,
                                               A_MATERNO = PERSONA.A_MATERNO,

                                               FNACIMIENTO = PERSONA.F_NACIMIENTO,
                                               SEXO = PERSONA.SEXO.ToString(),
                                               CALLE = PERSONA.CALLE,
                                               ESTADO = PERSONA.ESTADO1.nombre,
                                               NOMUNI = PERSONA.NOMMUNICIPIO,
                                               NOMLOC = PERSONA.NOMLOCALIDAD,
                                               T_CELULAR = PERSONA.T_CELULAR,
                                               CURP = PERSONA.CURP,
                                               FECHA_CREACION = PERSONA.FECHA_CREACION,
                                               T_CONSULTORIO = e.T_CONSULTORIO,
                                               T_PARTICULAR = e.T_PARTICULAR,
                                               CORREO = e.CORREO,
                                               C_PROFESIONAL = e.C_PROFESIONAL,
                                               CONTRA=usu.CONTRASENA

                                           });

        }
        //editar

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

        private void radGridView_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            CATALOGO_CIRUGIAS editedCirugia = e.Cell.DataContext as CATALOGO_CIRUGIAS;
            string propertyName = e.Cell.Column.UniqueName;
            //MessageBox.Show(string.Format("La propiedad: {0} está editada y el nuevo valor es:  {1}", propertyName, e.NewData));
            BaseDatos.GetBaseDatos().SaveChanges();
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
                NuevoMedico nmed = new NuevoMedico();
                nmed.Show();

                rgMostrarMedico.ItemsSource = BaseDatos.GetBaseDatos().MEDICOS.ToList();

            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el medico?", "Administracion Medicos", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            if (rgMostrarMedico.SelectedItem != null)
                            {


                                dynamic med = rgMostrarMedico.SelectedItem;
                                int idmedi = med.ID_USUARIO;

                                var cmedico = BaseDatos.GetBaseDatos().USUARIOS.Find(idmedi);
                                cmedico.EMPLEADO.PERSONA.ESTADOPERSONA = "Inactivo";
                               
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado el Medico", "Administracion Medicos");
                            VistaMedicosPersona();

                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
                else
                {
                    if (sender == itemEditar)
                    {
                        if (rgMostrarMedico.SelectedItem != null)
                        {
                            dynamic objmed = rgMostrarMedico.SelectedItem;
                            int idmedi = objmed.ID_MEDICO;
                            int idus = objmed.ID_USUARIO;
                            var idusu = BaseDatos.GetBaseDatos().USUARIOS.Find(idus);
                            var cmed = BaseDatos.GetBaseDatos().MEDICOS.Find(idmedi);



                            NuevoMedico nmed = new NuevoMedico((Medico)cmed, (USUARIO)idusu, false);
                            nmed.Show();
                            this.Close();
                        }
                    }
                }
                VistaMedicosPersona();

            }

        }

        private void checkBoxmedicos_Checked(object sender, RoutedEventArgs e)
        {
            if(checkBoxmedicos.IsChecked==true)
            {
                VistaMedicosTodos();
            }
        }

        private void checkBoxmedicos_Unchecked(object sender, RoutedEventArgs e)
        {
            if (checkBoxmedicos.IsChecked == false){
                VistaMedicosPersona();
            }
        }
    }
}
