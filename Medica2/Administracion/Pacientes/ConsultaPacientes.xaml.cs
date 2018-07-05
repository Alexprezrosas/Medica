using AccessoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        int idUsuario;
        public ConsultaPacientes()
        {
            InitializeComponent();

            VistaPacientesPersonasActivos();

            rgvPacientes.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        public ConsultaPacientes(int idu)
        {
            InitializeComponent();
            VistaPacientesPersonasActivos();
            rgvPacientes.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
            idUsuario = idu;
            var usuario = BaseDatos.GetBaseDatos().USUARIOS.Find(idu);
            if (usuario.EMPLEADO.PUESTO == "Administrador")
            {
                GridContextMenu2.Visibility = Visibility.Visible;
            }else
            {
                if (usuario.EMPLEADO.PUESTO == "Recepcionista")
                {
                    itemEliminar.Visibility = Visibility.Hidden;
                }
            }
            //// Creamos el timer y le seteamos el intervalo
            //System.Timers.Timer oTimer = new System.Timers.Timer();
            //oTimer.Interval = 5000;

            //oTimer.Elapsed += EventoIntervalo;

            //oTimer.Enabled = true;

            //Console.ReadLine();
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
                                        join cuarto in BaseDatos.GetBaseDatos().CATALOGO_CUARTOS
                                        on e.CUARTOID equals cuarto.ID_CATALOGO_CUARTO

                                        select new
                                        {
                                            ID_PACIENTE = e.ID_PACIENTE,
                                            ID_FAMILIAR = f.ID_FAM_RESPOSABLE,
                                            ID_CUENTA = cuenta.ID_CUENTA,
                                            ID_CAT_CUARTO = cuarto.ID_CATALOGO_CUARTO,
                                            NOMBRE = PERSONA.NOMBRE,
                                            APATERNO = PERSONA.A_PATERNO,
                                            AMATERNO = PERSONA.A_MATERNO,
                                            F_NACIMIENTO = PERSONA.F_NACIMIENTO,
                                            CALLE = PERSONA.CALLE,
                                            ESTADO = estado.nombre,
                                            MUNICIPIO = PERSONA.NOMMUNICIPIO,
                                            CURP = PERSONA.CURP,
                                            TIPOPACIENTE = e.TIPO_PACIENTE,
                                            RESPONSABLE = f.PERSONA.NOMBRE,
                                            TELEFONO = f.PERSONA.T_CELULAR,
                                            PARENTESCO = f.PARENTESCO,
                                            CUENTAA = cuenta.TOTAL,
                                            SALDO = cuenta.SALDO,
                                            CUARTOO = cuarto.NOMBRE_CUARTO
                                        }).ToList();
        }
        public void VistaPacientesPersonasActivos()
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
                                        join cuarto in BaseDatos.GetBaseDatos().CATALOGO_CUARTOS
                                        on e.CUARTOID equals cuarto.ID_CATALOGO_CUARTO
                                        where PERSONA.ESTADOPERSONA == "Activo"
                                        select new
                                        {
                                            ID_PACIENTE = e.ID_PACIENTE,
                                            ID_FAMILIAR = f.ID_FAM_RESPOSABLE,
                                            NOMBRE = PERSONA.NOMBRE,
                                            APATERNO = PERSONA.A_PATERNO,
                                            AMATERNO = PERSONA.A_MATERNO,
                                            F_NACIMIENTO = PERSONA.F_NACIMIENTO,
                                            ID_CAT_CUARTO = cuarto.ID_CATALOGO_CUARTO,
                                            CALLE = PERSONA.CALLE,
                                            ESTADO = estado.nombre,
                                            MUNICIPIO = PERSONA.NOMMUNICIPIO,
                                            CURP = PERSONA.CURP,
                                            TIPOPACIENTE = e.TIPO_PACIENTE,
                                            RESPONSABLE = f.PERSONA.NOMBRE,
                                            TELEFONO = f.PERSONA.T_CELULAR,
                                            PARENTESCO = f.PARENTESCO,
                                            CUENTAA = cuenta.TOTAL,
                                            SALDO = cuenta.SALDO,
                                            CUARTOO = cuarto.NOMBRE_CUARTO
                                        }).ToList();
        }

        //private static void EventoIntervalo(Object source, System.Timers.ElapsedEventArgs e)
        //{
        //    MessageBox.Show("Webitos");
        //}

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
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el paciente?", "Administración", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            dynamic idpaci = rgvPacientes.SelectedItem;
                            int idp = idpaci.ID_PACIENTE;
                            decimal idc = idpaci.SALDO;

                            if (rgvPacientes.SelectedItem != null)
                            {
                                var ceunt = BaseDatos.GetBaseDatos().CUENTAS.Find(idc);
                                if (idpaci.SALDO == 0)
                                {
                                    var paciente = BaseDatos.GetBaseDatos().PACIENTES.Find(idp);

                                    //BaseDatos.GetBaseDatos().PACIENTES.Remove(paciente);
                                    paciente.PERSONA.ESTADOPERSONA = "Inactivo";
                                    BaseDatos.GetBaseDatos().SaveChanges();
                                    MessageBox.Show("Se ha eliminado el paciente", "Administración");
                                    VistaPacientesPersonasActivos();
                                }
                                else
                                {
                                    MessageBox.Show("No se puede ELIMINAR \n La cuenta no ha sido saldada");
                                }


                            }


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
                            int idcuar = idpaci.ID_CAT_CUARTO;
                            var p = BaseDatos.GetBaseDatos().PACIENTES.Find(idp);
                            var f = BaseDatos.GetBaseDatos().FAM_RESPONSABLES.Find(idf);
                            //IngresoPaciente inpaci = new IngresoPaciente(
                            //    (PACIENTE)p, false);
                            //inpaci.Show();
                            IngresoPaciente inpaci = new IngresoPaciente(
                                (PACIENTE)p, (FAM_RESPONSABLES)f, false, idcuar);
                            inpaci.Show();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void checkBoxtodosP_Checked(object sender, RoutedEventArgs e)
        {

            if (checkBoxtodosP.IsChecked == true)
            {
                VistaPacientesPersonas();
            }

        }

        private void checkBoxtodosP_Unchecked(object sender, RoutedEventArgs e)
        {

            if (checkBoxtodosP.IsChecked == false)
            {
                VistaPacientesPersonasActivos();
            }
        }

        //

    }
}

