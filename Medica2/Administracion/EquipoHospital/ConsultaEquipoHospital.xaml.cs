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

namespace Medica2.Administracion.EquipoHospital
{
    /// <summary>
    /// Lógica de interacción para ConsultaEquipoHospital.xaml
    /// </summary>
    public partial class ConsultaEquipoHospital : Window
    {
        public ConsultaEquipoHospital()
        {
            InitializeComponent();
            //RadCatalogoEquipoH.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.ToList();
            LlenarVista();
        }

        void LlenarVista()
        {
            MostrarEquipoH.ItemsSource = (from ctcehq in BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL
                                          where ctcehq.STATUS == "Activo"
                                          select new
                                          {
                                              IDEQH = ctcehq.ID_EQUIPO_HOSPITAL,
                                              NOMBRE = ctcehq.NOM_EQUIPO_HOSPITAL,
                                              DESCRIPCION = ctcehq.DESCRIPCION,
                                              COSTO = ctcehq.COSTO,
                                              FECHA_CREACION = ctcehq.FECHA_CREACION
                                          });
        }
        void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, this.MostrarEquipoH.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        private void clubsGrid_PreparingCellForEdit(object sender, GridViewPreparingCellForEditEventArgs e)
        {
            if ((string)e.Column.Header == "NOM_EQUIPO_HOSPITAL")
            {
                var tb = e.EditingElement as TextBox;
                tb.TextWrapping = TextWrapping.Wrap;
            }

        }
        private void radGridView_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            CATALOGO_EQUIPO_HOSPITAL editedEspecialidades = e.Cell.DataContext as CATALOGO_EQUIPO_HOSPITAL;
            string propertyName = e.Cell.Column.UniqueName;
            //MessageBox.Show(string.Format("La propiedad: {0} está editada y el nuevo valor es:  {1}", propertyName, e.NewData));
            BaseDatos.GetBaseDatos().SaveChanges();
        }
        private void radGridView_BeginningEdit(object sender, Telerik.Windows.Controls.GridViewBeginningEditRoutedEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "ID_CATALOGO_ESPECIALDIADES")
            {
                ToolTipService.SetToolTip(e.Cell, "La edición de la ID puede provocar una incoherencia en la base de datos");
            }
        }

        private void MostrarEquipoH_SelectedCellsChanged(object sender, Telerik.Windows.Controls.GridView.GridViewSelectedCellsChangedEventArgs e)
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
                CatalogoEquipoHospital nequipoh = new CatalogoEquipoHospital();
                nequipoh.Show();


            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el equipo de hospital", "Administracion Equipo de Hospital", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            dynamic ctaeqh = MostrarEquipoH.SelectedItem;
                            int idcatalog = ctaeqh.IDEQH;

                            //int idequipohospital = (MostrarEquipoH.SelectedItem as CATALOGO_EQUIPO_HOSPITAL).ID_EQUIPO_HOSPITAL;
                            if (MostrarEquipoH.SelectedItem != null)
                            {
                                var catequihos = BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.Find(idcatalog);
                                catequihos.STATUS = "Inactivo";
                                //BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.Remove(catequihos);
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado", "Administración EQUIPO HOSPITAL");
                            LlenarVista();
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
                if (sender == itemEditar)
                {
                    if (MostrarEquipoH.SelectedItem != null)
                    {
                        dynamic ctaeqh = MostrarEquipoH.SelectedItem;
                        int idcatalog = ctaeqh.IDEQH;
                        //int idceh = ((CATALOGO_EQUIPO_HOSPITAL)MostrarEquipoH.SelectedItem).ID_EQUIPO_HOSPITAL;
                        //var cuartito = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Find(idcuart);
                        CatalogoEquipoHospital obj = new CatalogoEquipoHospital(idcatalog, false);
                        obj.Show();
                        this.Close();

                    }
                }
            }
        }


    }
}
