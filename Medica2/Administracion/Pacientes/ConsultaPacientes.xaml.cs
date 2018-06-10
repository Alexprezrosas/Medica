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

namespace Medica2.Administracion.Pacientes
{
    /// <summary>
    /// Lógica de interacción para ConsultaPacientes.xaml
    /// </summary>
    public partial class ConsultaPacientes : Window
    {
        public ConsultaPacientes()
        {
            InitializeComponent();

            VistaPacientesPersonas();

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
                                            join estado in BaseDatos.GetBaseDatos().ESTADOS
                                            on PERSONA.ESTADO equals estado.id
                                            join muni in BaseDatos.GetBaseDatos().MUNICIPIOS
                                            on PERSONA.MUNICIPIO equals muni.id
                                            select new
                                            {
                                                ID_PACIENTE = e.ID_PACIENTE,
                                                ID_FAMILIAR = f.ID_FAM_RESPOSABLE,
                                                NOMBRE = PERSONA.NOMBRE,
                                                APATERNO = PERSONA.A_PATERNO,
                                                AMATERNO = PERSONA.A_MATERNO,
                                                F_NACIMIENTO = PERSONA.F_NACIMIENTO,
                                                CALLE = PERSONA.CALLE,
                                                ESTADO = estado.nombre,
                                                MUNICIPIOO = muni.nombre,
                                                CURP = PERSONA.CURP,
                                                TIPOPACIENTE = e.TIPO_PACIENTE,
                                                RESPONSABLE = f.PERSONA.NOMBRE,
                                                TELEFONO = f.PERSONA.T_CELULAR,
                                                PARENTESCO = f.PARENTESCO,
                                                CUENTAA = cuenta.TOTAL,
                                                SALDO = cuenta.SALDO
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
                itemEliminar.IsEnabled = true;
                itemEditar.IsEnabled = true;
            }

        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemAgregar)
            {
                IngresoPaciente ip = new IngresoPaciente();
                ip.Show();
                this.Close();

            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el paciente?", "Administracion", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            dynamic idpaci = rgvPacientes.SelectedItem;
                            int idp = idpaci.ID_PACIENTE;

                            if (rgvPacientes.SelectedItem != null)
                            {
                                var paciente = BaseDatos.GetBaseDatos().PACIENTES.Find(idp);
                                BaseDatos.GetBaseDatos().PACIENTES.Remove(paciente);
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado el paciente", "Administracion");
                            VistaPacientesPersonas();

                            ////

                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
                else
                {
                    if (sender == itemEditar)
                    {
                        if (rgvPacientes.SelectedItem != null)
                        {
                            dynamic idpaci = rgvPacientes.SelectedItem;
                            int idp = idpaci.ID_PACIENTE;
                            int idf = idpaci.ID_FAMILIAR;
                            var p = BaseDatos.GetBaseDatos().PACIENTES.Find(idp);
                            var f = BaseDatos.GetBaseDatos().FAM_RESPONSABLES.Find(idf);
                            //IngresoPaciente inpaci = new IngresoPaciente(
                            //    (PACIENTE)p, false);
                            //inpaci.Show();
                            IngresoPaciente inpaci = new IngresoPaciente(
                                (PACIENTE)p, (FAM_RESPONSABLES)f, false);
                            inpaci.Show();
                        }
                    }
                }
            }
        }

        //

    }
}

