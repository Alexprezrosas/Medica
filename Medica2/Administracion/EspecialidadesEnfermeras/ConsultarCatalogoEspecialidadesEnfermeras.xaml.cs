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
using Telerik.Windows.Controls.GridView.SearchPanel;

namespace Medica2.Administracion.EspecialidadesEnfermeras
{
    /// <summary>
    /// Lógica de interacción para ConsultarCatalogoEspecialidadesEnfermeras.xaml
    /// </summary>
    public partial class ConsultarCatalogoEspecialidadesEnfermeras : Window
    {
        public ConsultarCatalogoEspecialidadesEnfermeras()
        {
            InitializeComponent();
            LlenarVista();
        }
        void LlenarVista()
        {
            MostrarEspecialidad.ItemsSource = (from ctc in BaseDatos.GetBaseDatos().CATALOGO_ESPECIALIDADES
                                               where ctc.STATUS == "Activo"
                                               select new
                                               {
                                                   IDCTE = ctc.ID_CATALOGO_ESPECIALIDAD,
                                                   NOMBRE_ESPECIALIDAD = ctc.NOMBRE_ESPECIALIDAD,
                                                   DESCRIPCION = ctc.DESCRIPCION,
                                                   FECHA_CREACION = ctc.FECHA_CREACION
                                               });
        }
        void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, this.MostrarEspecialidad.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
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
                this.Close();
                CatalogoEspecialidadesEnfermeras newesp = new CatalogoEspecialidadesEnfermeras();
                newesp.Show();

            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar?", "Administracion Especialidad", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            dynamic ctaciru = MostrarEspecialidad.SelectedItem;
                            int idcatalog = ctaciru.IDCTE;

                            //int idespec = (MostrarEspecialidad.SelectedItem as CATALOGO_ESPECIALIDADES).ID_CATALOGO_ESPECIALIDAD;
                            if (MostrarEspecialidad.SelectedItem != null)
                            {
                                var cespecialidad = BaseDatos.GetBaseDatos().CATALOGO_ESPECIALIDADES.Find(idcatalog);
                                cespecialidad.STATUS = "Inactivo";
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }

                            MessageBox.Show("Se ha eliminado correctamente", "Administracion Especialidades");
                            LlenarVista();
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
                else
                {

                    if (sender == itemEditar)
                    {
                        if (MostrarEspecialidad.SelectedItem != null)
                        {
                            dynamic objesp = MostrarEspecialidad.SelectedItem;
                            int idesp = objesp.IDCTE;
                            var especialidad = BaseDatos.GetBaseDatos().CATALOGO_ESPECIALIDADES.Find(idesp);


                            CatalogoEspecialidadesEnfermeras obj = new CatalogoEspecialidadesEnfermeras
                                ((CATALOGO_ESPECIALIDADES)especialidad, false);
                            obj.Show();
                            this.Close();

                        }
                    }
                }
            }
        }

    }
}
