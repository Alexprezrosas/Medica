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
    /// Lógica de interacción para ConsultarSolicitudDoctor.xaml
    /// </summary>
    public partial class ConsultarSolicitudDoctor : Window
    {
        public ConsultarSolicitudDoctor()
        {
            InitializeComponent();
            VistaGrid();
            rgvConsultaDoctoresSol.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvConsultaDoctoresSol.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        void VistaGrid()
        {
            rgvConsultaDoctoresSol.ItemsSource = (from solmater in BaseDatos.GetBaseDatos().MATERIALES_DOCTORES
                                                    join med in BaseDatos.GetBaseDatos().MEDICOS
                                                    on solmater.DOCTORID equals med.ID_MEDICO
                                                    join us in BaseDatos.GetBaseDatos().USUARIOS
                                                    on solmater.USUARIOID equals us.ID_USUARIO
                                                    select new
                                                    {
                                                        ID_MATERIAL = solmater.ID_MATERIAL,
                                                        ID_MEDICO = solmater.DOCTORID,
                                                        USUARIO = us.EMPLEADO.PERSONA.NOMBRE,
                                                        MEDIC = med.PERSONA.NOMBRE,
                                                        APATERNO = med.PERSONA.A_PATERNO,
                                                        AMATERNO = med.PERSONA.A_MATERNO,
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
                        dynamic sol = rgvConsultaDoctoresSol.SelectedItem;
                        int ids = sol.ID_MATERIAL;
                        if (rgvConsultaDoctoresSol.SelectedItem != null)
                        {
                            var solicitud = BaseDatos.GetBaseDatos().MATERIALES_DOCTORES.Find(ids);
                            var detsol = BaseDatos.GetBaseDatos().MATERIALES_DOCTORES.Find(ids);
                            BaseDatos.GetBaseDatos().MATERIALES_DOCTORES.Remove(solicitud);
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
                    if (rgvConsultaDoctoresSol.SelectedItem != null)
                    {
                        dynamic idsolc = rgvConsultaDoctoresSol.SelectedItem;
                        int ids = idsolc.ID_MATERIAL;
                        int idme = idsolc.ID_MEDICO;
                        SolicitudDoctor pr = new SolicitudDoctor(ids, idme);
                        pr.Show();
                        this.Close();

                    }
                }
            }

        }

    }
}
