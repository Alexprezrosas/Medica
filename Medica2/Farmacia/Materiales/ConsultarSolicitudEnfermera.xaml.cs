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

namespace Medica2.Farmacia.Materiales
{
    /// <summary>
    /// Lógica de interacción para ConsultarSolicitudEnfermera.xaml
    /// </summary>
    public partial class ConsultarSolicitudEnfermera : Window
    {
        public ConsultarSolicitudEnfermera()
        {
            InitializeComponent();
            VistaGrid();
            rgvConsultaEnfermerasSol.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvConsultaEnfermerasSol.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        void VistaGrid()
        {
            rgvConsultaEnfermerasSol.ItemsSource = (from solmater in BaseDatos.GetBaseDatos().MATERIALES_ENFERMERAS
                                     join enfer in BaseDatos.GetBaseDatos().ENFERMERAS
                                     on solmater.ENFERMERAID equals enfer.ID_ENFERMERA
                                     join us in BaseDatos.GetBaseDatos().USUARIOS
                                     on solmater.USUARIOID equals us.ID_USUARIO
                                     select new
                                     {
                                         ID_MATERIAL = solmater.ID_MATERIAL,
                                         ID_ENFERMERA = solmater.ENFERMERAID,
                                         USUARIO = us.EMPLEADO.PERSONA.NOMBRE,
                                         ENFERME = enfer.PERSONA.NOMBRE,
                                         APATERNO = enfer.PERSONA.A_PATERNO,
                                         AMATERNO = enfer.PERSONA.A_MATERNO,
                                         F_SOLICITUD = solmater.FECHA_CREACION,
                                         TOTAL = solmater.TOTAL
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
                        dynamic sol = rgvConsultaEnfermerasSol.SelectedItem;
                        int ids = sol.ID_MATERIAL;
                        if (rgvConsultaEnfermerasSol.SelectedItem != null)
                        {
                            var solicitud = BaseDatos.GetBaseDatos().MATERIALES_ENFERMERAS.Find(ids);
                            var detsol = BaseDatos.GetBaseDatos().DETALLE_MATER_ENFERMERAS.Find(ids);
                            BaseDatos.GetBaseDatos().MATERIALES_ENFERMERAS.Remove(solicitud);
                            BaseDatos.GetBaseDatos().SaveChanges();
                        }
                        MessageBox.Show("Se ha eliminado la solicitud", "Farmacia");
                        VistaGrid();
                        break;

                    case MessageBoxResult.No:

                        break;
                }
            }
            else
            {
                if (sender == itemEditar)
                {
                    if (rgvConsultaEnfermerasSol.SelectedItem != null)
                    {
                        dynamic idsolc = rgvConsultaEnfermerasSol.SelectedItem;
                        int ids = idsolc.ID_MATERIAL;
                        int idenf = idsolc.ID_ENFERMERA;
                        SolicitudEnfermera pr = new SolicitudEnfermera(ids, idenf);
                        pr.Show();
                        this.Close();

                    }
                }
            }

        }

    }
}
