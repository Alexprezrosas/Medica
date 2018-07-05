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
    /// Lógica de interacción para ConsultarDevoluciones.xaml
    /// </summary>
    public partial class ConsultarDevoluciones : Window
    {
        public ConsultarDevoluciones()
        {
            InitializeComponent();
            VistaPacientesPersonas();

            rgvDevoluciones.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }


        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvDevoluciones.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        public void VistaPacientesPersonas()
        {
            rgvDevoluciones.ItemsSource = (from dev in BaseDatos.GetBaseDatos().DEVOLUCIONES
                                        join med in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                        on dev.MEDICMANETOID equals med.ID_MEDICAMENTO
                                        join us in BaseDatos.GetBaseDatos().USUARIOS
                                        on dev.USUARIOID equals us.ID_USUARIO
                                        join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                        on dev.CUENTAID equals cuenta.ID_CUENTA
                                        join paci in BaseDatos.GetBaseDatos().PACIENTES
                                        on cuenta.PACIENTEID equals paci.ID_PACIENTE
                                        join cuarto in BaseDatos.GetBaseDatos().CATALOGO_CUARTOS
                                        on paci.CUARTOID equals cuarto.ID_CATALOGO_CUARTO
                                        select new
                                        {
                                            ID_PACIENTE = paci.ID_PACIENTE,
                                            ID_CUARTO = cuarto.ID_CATALOGO_CUARTO,
                                            ID_CUENTA = cuenta.ID_CUENTA,
                                            ID_MEDICAMENTO = med.ID_MEDICAMENTO,
                                            ID_DEVOLUCION = dev.ID_DEVOLUCION,
                                            MEDICAMENTO = med.NOMBRE_MEDI + " " + med.COMENTARIO + " " + med.U_MEDIDA,
                                            CANTIDAD = dev.CANTIDAD,
                                            CUARTO = cuarto.NOMBRE_CUARTO,
                                            PACIENTE = paci.PERSONA.NOMBRE + " " + paci.PERSONA.A_PATERNO + " " + paci.PERSONA.A_MATERNO,
                                            USUARIO = us.EMPLEADO.PERSONA.NOMBRE + " " + us.EMPLEADO.PERSONA.A_PATERNO + " " + us.EMPLEADO.PERSONA.A_MATERNO,
                                            FECHA = dev.FECHA_CREACION,
                                            CUENTAA = cuenta.TOTAL
                                        }).ToList();
        }

        /////////////////////

        private void MostrarPacientes_SelectedCellsChanged(object sender, Telerik.Windows.Controls.GridView.GridViewSelectedCellsChangedEventArgs e)
        {
            BaseDatos.GetBaseDatos().SaveChanges();
        }

        //
        

        //

    }
}