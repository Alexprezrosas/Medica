using AccessoDB;
using Medica2.Administracion.Cirugias;
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

namespace Medica2.Administracion
{
    /// <summary>
    /// Lógica de interacción para ConsultaCatalogCirugias.xaml
    /// </summary>
    public partial class ConsultaCatalogCirugias : Window
    {

        public ConsultaCatalogCirugias()
        {
            InitializeComponent();
            llenar_vistaCirugias();
        }
        void llenar_vistaCirugias()
        {
            MostraCirugias.ItemsSource = (from ctc in BaseDatos.GetBaseDatos().CATALOGO_CIRUGIAS
                                          where ctc.ESTATUS == "Activo"
                                          select new
                                          {
                                              IDCTC = ctc.ID_CATALOGO_CIRUGIA,
                                              NOMBRE_CIRUGIA = ctc.NOMBRE_CIRUGIA,
                                              DESCRIPCION = ctc.DESCRIPCION,
                                              COSTO = ctc.COSTO,
                                              FECHA_CREACION = ctc.FECHA_CREACION
                                          });
        }
        void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, this.MostraCirugias.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
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
                CatalogoCirugias nmat = new CatalogoCirugias();
                nmat.Show();


            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar?", "Administración Cirugías", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            dynamic ctaciru = MostraCirugias.SelectedItem;
                            int idcatalog = ctaciru.IDCTC;

                            //int idcirugia = (MostraCirugias.SelectedItem as CATALOGO_CIRUGIAS).ID_CATALOGO_CIRUGIA;

                            if (MostraCirugias.SelectedItem != null)
                            {
                                var ccirugi = BaseDatos.GetBaseDatos().CATALOGO_CIRUGIAS.Find(idcatalog);
                                //BaseDatos.GetBaseDatos().CATALOGO_CIRUGIAS.Remove(ccirugi);
                                ccirugi.ESTATUS = "Inactivo";

                                BaseDatos.GetBaseDatos().SaveChanges();

                            }

                            MessageBox.Show("Se ha eliminado correctamente", "Administración Cirugías");
                            llenar_vistaCirugias();
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
                else
                {
                    if (sender == itemEditar)
                    {
                        if (MostraCirugias.SelectedItem != null)
                        {
                            dynamic ctaciru = MostraCirugias.SelectedItem;
                            int idcatalog = ctaciru.IDCTC;

                            CatalogoCirugias obj = new CatalogoCirugias(idcatalog, false);
                            obj.Show();
                            this.Close();
                        }
                    }
                }

            }
        }

    }
}
