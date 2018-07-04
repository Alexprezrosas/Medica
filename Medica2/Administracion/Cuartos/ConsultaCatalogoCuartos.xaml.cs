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
            llenar_vistaCuartos();
        }

        void llenar_vistaCuartos()
        {
            MostrarCuartos.ItemsSource = (from ctcua in BaseDatos.GetBaseDatos().CATALOGO_CUARTOS
                                          where ctcua.STATUS == "Activo"
                                          select new
                                          {
                                              IDCTCUA = ctcua.ID_CATALOGO_CUARTO,
                                              NOMBRE_CUARTO = ctcua.NOMBRE_CUARTO,
                                              DESCRIPCION = ctcua.DESCRIPCION,
                                              COSTO = ctcua.COSTO,
                                              FECHA_CREACION = ctcua.FECHA_CREACION
                                          });
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
                itemEditar.IsEnabled = true;

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

                            dynamic ctacuar = MostrarCuartos.SelectedItem;
                            int idcatalog = ctacuar.IDCTCUA;

                            {
                                var ccuarto = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Find(idcatalog);
                                ccuarto.STATUS = "Inactivo";
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado el Cuarto", "Administracion Cuartos");
                            llenar_vistaCuartos();
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
                else
                {
                    if (sender == itemEditar)
                    {
                        if (MostrarCuartos.SelectedItem != null)
                        {
                            dynamic ctacuar = MostrarCuartos.SelectedItem;
                            int idcatalog = ctacuar.IDCTCUA;
                            //int idcuart = ((CATALOGO_CUARTOS)MostrarCuartos.SelectedItem).ID_CATALOGO_CUARTO;
                            //var cuartito = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Find(idcuart);


                            NuevoCuarto obj = new NuevoCuarto(idcatalog, false);
                            obj.Show();
                            this.Close();
                        }

                    }
                }
            }
        }

    }
}

