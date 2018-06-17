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

namespace Medica2.Farmacia.Compras
{
    /// <summary>
    /// Lógica de interacción para ConsultaCompras.xaml
    /// </summary>
    public partial class ConsultaCompras : Window
    {
        public ConsultaCompras()
        {
            InitializeComponent();
            VistaVentas();
            rgvCompras.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvCompras.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        void VistaVentas()
        {
            rgvCompras.ItemsSource = (from COMPRAS in BaseDatos.GetBaseDatos().COMPRAS
                                     join e in BaseDatos.GetBaseDatos().USUARIOS
                                     on COMPRAS.USUARIOID equals e.ID_USUARIO
                                     join c in BaseDatos.GetBaseDatos().EMPLEADOS
                                     on e.EMPLEADOID equals c.ID_EMPLEADO
                                     join f in BaseDatos.GetBaseDatos().PERSONAS
                                     on c.PERSONAID equals f.ID_PERSONA
                                     join p in BaseDatos.GetBaseDatos().PROVEEDORES
                                     on COMPRAS.PROVEEDORID equals p.ID_PROVEEDOR
                                     select new
                                     {
                                         ID_COMPRA = COMPRAS.ID_COMPRA,
                                         FACTURA = COMPRAS.NUM_FACTURA,
                                         F_COMPRA = COMPRAS.FECHA_COMPRA,
                                         F_VENCIMIENTO = COMPRAS.FECHA_VENCIMIENTO,
                                         PROVEEDOR = p.PERSONA.NOMBRE,
                                         NOMUSUARIO = f.NOMBRE,
                                         TOTAL = COMPRAS.TOTAL
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
                MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar la compra?", "Farmacia", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        dynamic ven = rgvCompras.SelectedItem;
                        int idc = ven.ID_COMPRA;
                        if (rgvCompras.SelectedItem != null)
                        {
                            var compra = BaseDatos.GetBaseDatos().COMPRAS.Find(idc);
                            BaseDatos.GetBaseDatos().COMPRAS.Remove(compra);
                            BaseDatos.GetBaseDatos().SaveChanges();
                        }
                        MessageBox.Show("Se ha eliminado la compra", "Farmacia");
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
                    if (rgvCompras.SelectedItem != null)
                    {
                        dynamic idvent = rgvCompras.SelectedItem;
                        int idc = idvent.ID_COMPRA;
                        NuevaCompra nc = new NuevaCompra(idc);
                        nc.Show();
                        this.Close();
                    }
                }
            }

        }

    }
}
