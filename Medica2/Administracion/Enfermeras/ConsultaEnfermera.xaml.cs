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
            //MostrarEnfermera.ItemsSource = BaseDatos.GetBaseDatos().ENFERMERAS.Join(PERSONA(n);

            //autoEnfermera.ItemsSource = BaseDatos.GetBaseDatos().ENFERMERAS.ToList();
            VistaEnfermerasPersonas();
            

        }
        
        public void VistaEnfermerasPersonas()
        {
            MostrarEnfermera.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                          join e in BaseDatos.GetBaseDatos().ENFERMERAS
                          on PERSONA.ID_PERSONA equals e.PERSONAID
                          select new
                          {
                              ID_ENFERMERA = e.ID_ENFERMERA,
                              NOMBRE = PERSONA.NOMBRE,
                              APATERNO = PERSONA.A_PATERNO,
                              AMATERNO = PERSONA.A_MATERNO,
                              CPROFESIONAL = e.C_PROFESIONAL
                          });
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

                            int idenf = (MostrarEnfermera.SelectedItem as ENFERMERA).ID_ENFERMERA;
                            
                            ////
                            //int test = int.Parse(MostrarEnfermera.SelectedItem);

                            //MostrarEnfermera.SelectedItem("{ID_ENFERMERA}");
                            //var idd = Convert.ToInt32(dat["ID_ENFERMERA"]);
                            ////
                            if (MostrarEnfermera.SelectedItem != null)
                            {
                                var cmatt = BaseDatos.GetBaseDatos().ENFERMERAS.Find(idenf);
                                BaseDatos.GetBaseDatos().ENFERMERAS.Remove(cmatt);
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado la enfermera", "Administracion");
                            VistaEnfermerasPersonas();
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
            }
        }

        private void MostrarEnfermera_RowActivated(object sender, RowEventArgs e)
        {
            var row = e.Row as GridViewRow;
            ENFERMERA enf = row.Item as ENFERMERA;
            string message = string.Format("Name: {0} \n Established: {1} \nCapacity: {2}", enf.ID_ENFERMERA,
                enf.C_PROFESIONAL,
                enf.FECHA_CREACION);
            MessageBox.Show(message);
            
        }
        
    }
}
