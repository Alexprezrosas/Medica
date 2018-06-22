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

namespace Medica2.Administracion.Especialidades
{
    /// <summary>
    /// Lógica de interacción para ConsultarCatalogoEspecialidades.xaml
    /// </summary>
    public partial class ConsultarCatalogoEspecialidades : Window
    {

        public ConsultarCatalogoEspecialidades()
        {
            InitializeComponent();

            //RadEspecialidades.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_ESPECIALIDADES.ToList();
            MostrarEspecialidad.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_ESPECIALIDADES.ToList();

        }
        void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, this.MostrarEspecialidad.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }
        private void radGridView_BeginningEdit(object sender, Telerik.Windows.Controls.GridViewBeginningEditRoutedEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "ID_CATALOGO_ESPECIALDIADES")
            {
                ToolTipService.SetToolTip(e.Cell, "La edición de la ID puede provocar una incoherencia en la base de datos");
            }
        }
        private void clubsGrid_PreparingCellForEdit(object sender, GridViewPreparingCellForEditEventArgs e)
        {
            if ((string)e.Column.Header == "NOMBRE_ESPECIALIDAD")
            {
                var tb = e.EditingElement as TextBox;
                tb.TextWrapping = TextWrapping.Wrap;
            }

        }
        private void radGridView_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            CATALOGO_ESPECIALIDADES editedEspecialidades = e.Cell.DataContext as CATALOGO_ESPECIALIDADES;
            string propertyName = e.Cell.Column.UniqueName;
            //MessageBox.Show(string.Format("La propiedad: {0} está editada y el nuevo valor es:  {1}", propertyName, e.NewData));
            BaseDatos.GetBaseDatos().SaveChanges();
        }

        private void MostrarEspecialidad_SelectedCellsChanged(object sender, Telerik.Windows.Controls.GridView.GridViewSelectedCellsChangedEventArgs e)
        {
            BaseDatos.GetBaseDatos().SaveChanges();
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
            }

        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemAgregar)
            {
                this.Close();
                CatalogoEspecialidades nespe = new CatalogoEspecialidades();
                nespe.Show();
            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar?", "Administracion Especialidad", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            int idespec = (MostrarEspecialidad.SelectedItem as CATALOGO_ESPECIALIDADES).ID_CATALOGO_ESPECIALIDAD;
                            if (MostrarEspecialidad.SelectedItem != null)
                            {
                                var cespecialidad = BaseDatos.GetBaseDatos().CATALOGO_ESPECIALIDADES.Find(idespec);
                                BaseDatos.GetBaseDatos().CATALOGO_ESPECIALIDADES.Remove(cespecialidad);
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado correctamente", "Administracion Especialidades");
                            MostrarEspecialidad.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_ESPECIALIDADES.ToList();
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
            }
        }


    }
}
