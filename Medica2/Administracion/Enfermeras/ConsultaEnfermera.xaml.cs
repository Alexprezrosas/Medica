using AccessoDB;
using System;
using System.Collections;
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

namespace Medica2.Administracion.Enfermeras
{
    /// <summary>
    /// Lógica de interacción para ConsultaEnfermera.xaml
    /// </summary>
    public partial class ConsultaEnfermera : Window
    {
        
        public ConsultaEnfermera()
        {
            InitializeComponent();
            
            VistaEnfermerasPersonas();

        }

        public void VistaEnfermerasPersonas()
        {
            MostrarEnfermera.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                                  join e in BaseDatos.GetBaseDatos().ENFERMERAS
                                                  on PERSONA.ID_PERSONA equals e.PERSONAID
                                                  join emple in BaseDatos.GetBaseDatos().EMPLEADOS
                                                  on PERSONA.ID_PERSONA equals emple.PERSONAID
                                                  join usu in BaseDatos.GetBaseDatos().USUARIOS
                                                  on emple.ID_EMPLEADO equals usu.EMPLEADOID
                                                  where PERSONA.ESTADOPERSONA=="Activo"
                                                  select new
                                                  {
                                                      ID_ENFERMERA = e.ID_ENFERMERA,
                                                      ID_USUARIO = usu.ID_USUARIO,
                                                      NOMBRE = PERSONA.NOMBRE,
                                                      APATERNO = PERSONA.A_PATERNO,
                                                      AMATERNO = PERSONA.A_MATERNO,
                                                      CPROFESIONAL = e.C_PROFESIONAL,
                                                      CALLE = PERSONA.CALLE,
                                                      ESTADO = PERSONA.ESTADO1.nombre,
                                                      NOMUNI = PERSONA.NOMMUNICIPIO,
                                                      NOMLOC = PERSONA.NOMLOCALIDAD,
                                                      T_CELULAR = PERSONA.T_CELULAR,
                                                      CURP = PERSONA.CURP,
                                                      FECHA_CREACION = PERSONA.FECHA_CREACION,
                                                      CONTRA=usu.CONTRASENA,
                                                      PUESTO = emple.PUESTO,
                                                      CONTRASE = usu.CONTRASENA
                                                  }).ToList();
        }

        public void VistaEnfermerasTodas()
        {
            MostrarEnfermera.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                            join e in BaseDatos.GetBaseDatos().ENFERMERAS
                                            on PERSONA.ID_PERSONA equals e.PERSONAID
                                            join emple in BaseDatos.GetBaseDatos().EMPLEADOS
                                            on PERSONA.ID_PERSONA equals emple.PERSONAID
                                            join usu in BaseDatos.GetBaseDatos().USUARIOS
                                            on emple.ID_EMPLEADO equals usu.EMPLEADOID
                                            select new
                                            {
                                                ID_ENFERMERA = e.ID_ENFERMERA,
                                                ID_USUARIO = usu.ID_USUARIO,
                                                NOMBRE = PERSONA.NOMBRE,
                                                APATERNO = PERSONA.A_PATERNO,
                                                AMATERNO = PERSONA.A_MATERNO,
                                                CPROFESIONAL = e.C_PROFESIONAL,
                                                CALLE = PERSONA.CALLE,
                                                ESTADO = PERSONA.ESTADO1.nombre,
                                                NOMUNI = PERSONA.NOMMUNICIPIO,
                                                NOMLOC = PERSONA.NOMLOCALIDAD,
                                                T_CELULAR = PERSONA.T_CELULAR,
                                                CURP = PERSONA.CURP,
                                                FECHA_CREACION = PERSONA.FECHA_CREACION,
                                                CONTRA=usu.CONTRASENA
                                            }).ToList();
        }

        private void MostrarEnfermeras_SelectedCellsChanged(object sender, Telerik.Windows.Controls.GridView.GridViewSelectedCellsChangedEventArgs e)
        {
            BaseDatos.GetBaseDatos().SaveChanges();
        }

        //
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
                NuevaEnfermera nmat = new NuevaEnfermera();
                nmat.Show();
                MostrarEnfermera.ItemsSource = BaseDatos.GetBaseDatos().ENFERMERAS.ToList();

            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar la enfermera?", "Administracion", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            dynamic idenfermera = MostrarEnfermera.SelectedItem;
                            int idenf = idenfermera.ID_ENFERMERA;
                            
                            if (MostrarEnfermera.SelectedItem != null)
                            {
                                var cenfer = BaseDatos.GetBaseDatos().ENFERMERAS.Find(idenf);
                                cenfer.PERSONA.ESTADOPERSONA = "Inactivo";
                              
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado la enfermera", "Administracion");
                            VistaEnfermerasPersonas();

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
                            if (MostrarEnfermera.SelectedItem != null)
                            {
                                dynamic objmed = MostrarEnfermera.SelectedItem;
                                int idenfe = objmed.ID_ENFERMERA;
                                int idus = objmed.ID_USUARIO;

                                var cenfe = BaseDatos.GetBaseDatos().ENFERMERAS.Find(idenfe);
                                var idusu = BaseDatos.GetBaseDatos().USUARIOS.Find(idus);

                                NuevaEnfermera nmed = new NuevaEnfermera((ENFERMERA)cenfe, (USUARIO)idusu, false);
                                nmed.Show();
                                this.Close();
                            }
                        }
                 }
                
            }
        }

        private void checkboxenfe_Checked(object sender, RoutedEventArgs e)
        {
            if (checkboxenfe.IsChecked == true)
            {
                VistaEnfermerasTodas();
            }

        }

        private void checkboxenfe_Unchecked(object sender, RoutedEventArgs e)
        {
            if (checkboxenfe.IsChecked == false)
            {
                VistaEnfermerasPersonas();
            }
        }
    }
}
