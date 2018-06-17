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

namespace Medica2.Administracion.EquipoHospital
{
    /// <summary>
    /// Lógica de interacción para ConsultaCatalogoEquipoHospital.xaml
    /// </summary>
    public partial class ConsultaCatalogoEquipoHospital : Window
    {
        
        public ConsultaCatalogoEquipoHospital()
        {
            InitializeComponent();

            VistaGrid();
            rgvConsultaEquipoHospital.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvConsultaEquipoHospital.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        void VistaGrid()
        {
            rgvConsultaEquipoHospital.ItemsSource = (from EQUIPOH in BaseDatos.GetBaseDatos().EQUIPO_HOSPITAL
                                                     join med in BaseDatos.GetBaseDatos().MEDICOS
                                                     on EQUIPOH.MEDICOID equals med.ID_MEDICO
                                                     join cuent in BaseDatos.GetBaseDatos().CUENTAS
                                                     on EQUIPOH.CUENTAID equals cuent.ID_CUENTA
                                                     join usu in BaseDatos.GetBaseDatos().USUARIOS
                                                     on EQUIPOH.USUARIOID equals usu.ID_USUARIO
                                                     select new
                                                     {
                                                         ID_EQUIPO_H = EQUIPOH.ID_EQUIPO_HOSPITAL,
                                                         ID_MEDICO = med.ID_MEDICO,
                                                         IDCEUNTA = cuent.ID_CUENTA,
                                                         ID_PACIENTE = cuent.PACIENTE.ID_PACIENTE,
                                                         NOMMEDICO = med.PERSONA.NOMBRE + " " + med.PERSONA.A_PATERNO + " " + med.PERSONA.A_MATERNO,
                                                         NOMUSU = usu.EMPLEADO.PERSONA.NOMBRE,
                                                         FECHA = EQUIPOH.FECHA_CREACION,
                                                         TOTA = EQUIPOH.TOTAL,
                                                         TOTALCUENTA = cuent.TOTAL,
                                                         SALD = cuent.SALDO,
                                                         PACIEN = cuent.PACIENTE.PERSONA.NOMBRE + " " + cuent.PACIENTE.PERSONA.A_PATERNO + " " + cuent.PACIENTE.PERSONA.A_MATERNO

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
                itemEliminar.IsEnabled = true;
                itemEditar.IsEnabled = true;
            }

        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {

            if (sender == itemEliminar)
            {
                MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el equipo hospital?", "Administracion", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        dynamic equipohsp = rgvConsultaEquipoHospital.SelectedItem;
                        int ids = equipohsp.ID_EQUIPO_H;
                        if (rgvConsultaEquipoHospital.SelectedItem != null)
                        {
                            var equip = BaseDatos.GetBaseDatos().EQUIPO_HOSPITAL.Find(ids);
                            Decimal total = Decimal.Parse(equip.TOTAL.ToString());

                            int idc = equipohsp.IDCEUNTA;
                            var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idc);
                            cuenta.TOTAL = cuenta.TOTAL - total;
                            cuenta.SALDO = cuenta.SALDO - total;
                            BaseDatos.GetBaseDatos().SaveChanges();


                            BaseDatos.GetBaseDatos().EQUIPO_HOSPITAL.Remove(equip);
                            BaseDatos.GetBaseDatos().SaveChanges();
                        }
                        MessageBox.Show("Se ha eliminado el Equipo Hospital", "Administracion");
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
                    if (rgvConsultaEquipoHospital.SelectedItem != null)
                    {
                        dynamic iddetaeqh = rgvConsultaEquipoHospital.SelectedItem;
                        int idequi = iddetaeqh.ID_EQUIPO_H;
                        int idme = iddetaeqh.ID_MEDICO;
                        int pac = iddetaeqh.ID_PACIENTE;
                        int idc = iddetaeqh.IDCEUNTA;

                        CargarEquipoHospital pr = new CargarEquipoHospital(idequi, idme, pac, idc);
                        pr.Show();
                        this.Close();

                    }
                }
            }

        }

    }
}
