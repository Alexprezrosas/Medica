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

namespace Medica2.Enfermeria.Suministros
{
    /// <summary>
    /// Lógica de interacción para VisualizarSuministros.xaml
    /// </summary>
    public partial class VisualizarSuministros : Window
    {
        int idUsuario;
        public VisualizarSuministros()
        {
            InitializeComponent();
            VistaSuministros();
            rgvSuministros.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        public VisualizarSuministros(int idu)
        {
            InitializeComponent();
            VistaSuministros();
            rgvSuministros.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
            idUsuario = idu;
        }

        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvSuministros.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        void VistaSuministros()
        {
            rgvSuministros.ItemsSource = (from sumi in BaseDatos.GetBaseDatos().SUMINISTROS_MEDICAMENTOS
                                      join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                      on sumi.CUENTAID equals cuenta.ID_CUENTA
                                      join us in BaseDatos.GetBaseDatos().USUARIOS
                                      on sumi.USUARIOID equals us.ID_USUARIO
                                      join paci in BaseDatos.GetBaseDatos().PACIENTES
                                      on cuenta.PACIENTEID equals paci.ID_PACIENTE
                                      join cuarto in BaseDatos.GetBaseDatos().CATALOGO_CUARTOS
                                      on paci.CUARTOID equals cuarto.ID_CATALOGO_CUARTO
                                      select new
                                      {
                                          ID_SUMINISTRO = sumi.ID_SUMINISTRO_MEDICAMENTO,
                                          ID_CUENTA = cuenta.ID_CUENTA,
                                          ID_USUARIO = us.ID_USUARIO,
                                          ID_PACIENTE = paci.ID_PACIENTE,
                                          CUARTO = cuarto.NOMBRE_CUARTO,
                                          PACI = paci.PERSONA.NOMBRE + " " + paci.PERSONA.A_PATERNO + " " +paci.PERSONA.A_MATERNO,
                                          NOMUSUARIO = us.EMPLEADO.PERSONA.NOMBRE + " " + us.EMPLEADO.PERSONA.A_PATERNO + " " + us.EMPLEADO.PERSONA.A_MATERNO,
                                          TOTAL = sumi.TOTAL,
                                          FECHA = sumi.FECHA_CREACION
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
                MessageBoxResult result = MessageBox.Show("¿Está seguro de eliminar la compra?", "Farmacia", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (rgvSuministros.SelectedItem != null)
                        {
                            dynamic suministro = rgvSuministros.SelectedItem;
                            int ids = suministro.ID_SUMINISTRO;
                            int idc = suministro.ID_CUENTA;
                            var sumin = BaseDatos.GetBaseDatos().SUMINISTROS_MEDICAMENTOS.Find(ids);
                            var cuen = BaseDatos.GetBaseDatos().CUENTAS.Find(idc);
                            cuen.TOTAL = cuen.TOTAL - sumin.TOTAL;
                            cuen.SALDO = cuen.SALDO - sumin.TOTAL;
                            BaseDatos.GetBaseDatos().SaveChanges();
                            BaseDatos.GetBaseDatos().SUMINISTROS_MEDICAMENTOS.Remove(sumin);
                            BaseDatos.GetBaseDatos().SaveChanges();
                            MessageBox.Show("Se ha eliminado el suministro", "Enfermeria");
                            VistaSuministros();
                        }
                        break;

                    case MessageBoxResult.No:

                        break;
                }
            }
            else
            {
                if (sender == itemEditar)
                {
                    if (rgvSuministros.SelectedItem != null)
                    {
                        dynamic suministro = rgvSuministros.SelectedItem;
                        int ids = suministro.ID_SUMINISTRO;
                        int idp = suministro.ID_PACIENTE;
                        String cua = suministro.CUARTO;
                        Decimal tota = suministro.TOTAL;
                        int idc = suministro.ID_CUENTA;
                        NuevoSuministro nc = new NuevoSuministro(ids, idp, cua, tota, idc, idUsuario);
                        nc.Show();
                        this.Close();
                    }
                }
            }

        }

    }
}

