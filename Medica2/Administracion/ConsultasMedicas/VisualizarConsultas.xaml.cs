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
using Telerik.Windows.Controls.GridView;

namespace Medica2.Administracion.ConsultasMedicas
{
    /// <summary>
    /// Lógica de interacción para VisualizarConsultas.xaml
    /// </summary>
    public partial class VisualizarConsultas : Window
    {
        public VisualizarConsultas()
        {
            InitializeComponent();
            Vistaconsultas();
        }

        public void Vistaconsultas()
        {
            rgvVizualizaConsultas.ItemsSource = (from cue in BaseDatos.GetBaseDatos().CUENTAS
                                                 join pac in BaseDatos.GetBaseDatos().PACIENTES
                                                 on cue.PACIENTEID equals pac.ID_PACIENTE
                                                 join con in BaseDatos.GetBaseDatos().CONSULTAS
                                                 on pac.ID_PACIENTE equals con.PACIENTEID
                                                 join med in BaseDatos.GetBaseDatos().MEDICOS
                                                 on con.MEDICOID equals med.ID_MEDICO
                                                 select new
                                                 {
                                                     IDCONSU = con.ID_CONSULTA,
                                                     IDCUEN = cue.ID_CUENTA,
                                                     ID_PAC = pac.ID_PACIENTE,
                                                     ID_MED = med.ID_MEDICO,
                                                     CEDU = med.C_PROFESIONAL,
                                                     MEDICO = med.PERSONA.NOMBRE + " " + med.PERSONA.A_PATERNO + " " + med.PERSONA.A_MATERNO,
                                                     PACIEN = pac.PERSONA.NOMBRE + " " + pac.PERSONA.A_PATERNO + "  " + pac.PERSONA.A_MATERNO,
                                                     COST = con.COSTO,

                                                 });


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
                RegistrarConsulta obj = new RegistrarConsulta();
                obj.Show();
            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar la Consulta?", "Administracion Consultas Médicas", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            int idcon = (rgvVizualizaConsultas.SelectedItem as CONSULTA).ID_CONSULTA;
                            if (rgvVizualizaConsultas.SelectedItem != null)
                            {
                                var conme = BaseDatos.GetBaseDatos().CONSULTAS.Find(idcon);
                                BaseDatos.GetBaseDatos().CONSULTAS.Remove(conme);
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado la Consulta", "Administracion Consultas Médicas");
                            rgvVizualizaConsultas.ItemsSource = BaseDatos.GetBaseDatos().CONSULTAS.ToList();
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
                else
                {
                    if (sender == itemEditar)
                    {
                        if (rgvVizualizaConsultas.SelectedItem != null)
                        {
                            dynamic consu = rgvVizualizaConsultas.SelectedItem;
                            int idco = consu.IDCONSU;
                            var consul = BaseDatos.GetBaseDatos().CONSULTAS.Find(idco);
                            int idcuen = consu.IDCUEN;

                            RegistrarConsulta obj = new RegistrarConsulta((CONSULTA)consul, idcuen, false);
                            obj.Show();
                            this.Close();
                        }

                    }
                }
            }
        }
    }
}
