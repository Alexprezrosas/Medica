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

namespace Medica2.Farmacia.Devoluciones
{
    /// <summary>
    /// Lógica de interacción para DevolucionPacientes.xaml
    /// </summary>
    public partial class DevolucionPacientes : Window
    {
        int idUsuario;
        public DevolucionPacientes()
        {
            InitializeComponent();
            VistaPacientesPersonas();

            rgvPacientes.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        public DevolucionPacientes(int idu)
        {
            InitializeComponent();
            VistaPacientesPersonas();
            idUsuario = idu;
            rgvPacientes.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvPacientes.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        public void VistaPacientesPersonas()
        {
            rgvPacientes.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                        join e in BaseDatos.GetBaseDatos().PACIENTES
                                        on PERSONA.ID_PERSONA equals e.PERSONAID
                                        join f in BaseDatos.GetBaseDatos().FAM_RESPONSABLES
                                        on e.ID_PACIENTE equals f.PACIENTEID
                                        join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                        on e.ID_PACIENTE equals cuenta.PACIENTEID
                                        join cuarto in BaseDatos.GetBaseDatos().CATALOGO_CUARTOS
                                        on e.CUARTOID equals cuarto.ID_CATALOGO_CUARTO
                                        select new
                                        {
                                            ID_PACIENTE = e.ID_PACIENTE,
                                            ID_FAMILIAR = f.ID_FAM_RESPOSABLE,
                                            ID_CUARTO = cuarto.ID_CATALOGO_CUARTO,
                                            ID_CUENTA = cuenta.ID_CUENTA,
                                            CUARTO = cuarto.NOMBRE_CUARTO,
                                            NOMBRE = PERSONA.NOMBRE,
                                            APATERNO = PERSONA.A_PATERNO,
                                            AMATERNO = PERSONA.A_MATERNO,
                                            F_NACIMIENTO = PERSONA.F_NACIMIENTO,
                                            TIPOPACIENTE = e.TIPO_PACIENTE,
                                            RESPONSABLE = f.PERSONA.NOMBRE,
                                            TELEFONO = f.PERSONA.T_CELULAR,
                                            CUENTAA = cuenta.TOTAL
                                        }).ToList();
        }

        /////////////////////

        private void MostrarPacientes_SelectedCellsChanged(object sender, Telerik.Windows.Controls.GridView.GridViewSelectedCellsChangedEventArgs e)
        {
            BaseDatos.GetBaseDatos().SaveChanges();
        }

        //
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
            }

        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemAgregar)
            {
                if (rgvPacientes.SelectedItem != null)
                {
                    dynamic pac = rgvPacientes.SelectedItem;
                    int idpac = pac.ID_PACIENTE;
                    String idcur = pac.CUARTO;
                    int idcuen = pac.ID_CUENTA;
                    AplicarDevolucion ns = new AplicarDevolucion(idpac, idcur, idcuen, idUsuario);
                    ns.Show();
                    this.Close();
                }
            }
        }

        //

    }
}
