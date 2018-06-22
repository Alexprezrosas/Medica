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

namespace Medica2.Administracion.Cuartos
{
    /// <summary>
    /// Lógica de interacción para ConsultaCatalogoCuartos.xaml
    /// </summary>
    public partial class ConsultaCatalogoCuartos : Window
    {
        
        public ConsultaCatalogoCuartos()
        {
            InitializeComponent();

            //RadConsultarCatalogoCuartos.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.ToList();
            MostrarCuartos.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.ToList();

        }
        void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, this.MostrarCuartos.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }
        private void clubsGrid_PreparingCellForEdit(object sender, GridViewPreparingCellForEditEventArgs e)
        {
            if ((string)e.Column.Header == "NOMBRE_CUARTO")
            {
                var tb = e.EditingElement as TextBox;
                tb.TextWrapping = TextWrapping.Wrap;
            }

        }
        private void radGridView_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            CATALOGO_CUARTOS editedEspecialidades = e.Cell.DataContext as CATALOGO_CUARTOS;
            string propertyName = e.Cell.Column.UniqueName;
            //MessageBox.Show(string.Format("La propiedad: {0} está editada y el nuevo valor es:  {1}", propertyName, e.NewData));
            BaseDatos.GetBaseDatos().SaveChanges();
        }


        private void MostrarCuartos_SelectedCellsChanged(object sender, Telerik.Windows.Controls.GridView.GridViewSelectedCellsChangedEventArgs e)
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
                NuevoCuarto ncuarto = new NuevoCuarto();
                ncuarto.Show();


            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el Caurto?", "Administracion Cuartos", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            int idcuarto = (MostrarCuartos.SelectedItem as CATALOGO_CUARTOS).ID_CATALOGO_CUARTO;
                            if (MostrarCuartos.SelectedItem != null)
                            {
                                var ccuarto = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Find(idcuarto);
                                BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Remove(ccuarto);
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado el Cuarto", "Administracion Cuartos");
                            MostrarCuartos.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.ToList();
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
            }
        }

    }
}

