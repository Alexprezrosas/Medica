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

namespace Medica2.Farmacia.Ventas
{
    /// <summary>
    /// Lógica de interacción para ConsultaVentas.xaml
    /// </summary>
    public partial class ConsultaVentas : Window
    {
        public ConsultaVentas()
        {
            InitializeComponent();
            VistaVentas();
            rgvVentas.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvVentas.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        void VistaVentas()
        {
            rgvVentas.ItemsSource = (from VENTAS_GENERALES in BaseDatos.GetBaseDatos().VENTAS_GENERALES
                                            join e in BaseDatos.GetBaseDatos().USUARIOS
                                            on VENTAS_GENERALES.USUARIOID equals e.ID_USUARIO
                                            join c in BaseDatos.GetBaseDatos().EMPLEADOS
                                            on e.EMPLEADOID equals c.ID_EMPLEADO
                                            join f in BaseDatos.GetBaseDatos().PERSONAS
                                            on c.PERSONAID equals f.ID_PERSONA
                                            select new
                                            {
                                                ID_VENTA = VENTAS_GENERALES.ID_VENTA_GENERAL,
                                                USUARIO = e.ID_USUARIO,
                                                NOMUSUARIO = f.NOMBRE,
                                                F_VENTA = VENTAS_GENERALES.FECHA_CREACION,
                                                CLIENTE = VENTAS_GENERALES.CLIENTE,
                                                TOTAL = VENTAS_GENERALES.TOTAL
                                            }).ToList();
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
                itemEliminar.IsEnabled = true;
                itemEditar.IsEnabled = true;
            }

        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar la venta?", "Farmacia", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            dynamic ven = rgvVentas.SelectedItem;
                            int idv = ven.ID_VENTA;
                            if (rgvVentas.SelectedItem != null)
                            {
                                var venta = BaseDatos.GetBaseDatos().VENTAS_GENERALES.Find(idv);
                            var detven = BaseDatos.GetBaseDatos().DETALLE_VENTAS.Find(idv);
                                BaseDatos.GetBaseDatos().VENTAS_GENERALES.Remove(venta);
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado la venta", "Farmacia");
                            VistaVentas();
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
            else
            {
                if (sender == itemEditar)
                {
                    if (rgvVentas.SelectedItem != null)
                    {
                        dynamic idvent = rgvVentas.SelectedItem;
                        int idv = idvent.ID_VENTA;
                        RegistrarVenta pr = new RegistrarVenta(idv);
                        pr.Show();
                        this.Close();

                    }
                }
            }

        }

    }
}
