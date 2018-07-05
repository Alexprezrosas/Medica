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

namespace Medica2.Administracion.Estudios
{
    /// <summary>
    /// Lógica de interacción para EstudiosAplicados.xaml
    /// </summary>
    public partial class EstudiosAplicados : Window
    {

        public EstudiosAplicados()
        {
            InitializeComponent();
            VistaGrid();
            rgvEstudiosAplicados.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        public EstudiosAplicados(int idu)
        {
            InitializeComponent();
            VistaGrid();
            rgvEstudiosAplicados.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
            var usuario = BaseDatos.GetBaseDatos().USUARIOS.Find(idu);
            if (usuario.EMPLEADO.PUESTO == "Administrador")
            {
                GridContextMenu2.Visibility = Visibility.Visible;

            }else
            {
                if (usuario.EMPLEADO.PUESTO == "Recepcionista")
                {
                    itemEditar.Visibility = Visibility.Hidden;
                    itemEditar.Visibility = Visibility.Hidden;
                }
            }
        }

        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvEstudiosAplicados.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        public void VistaGrid()
        {
            rgvEstudiosAplicados.ItemsSource = (from ESTUDIOS in BaseDatos.GetBaseDatos().ESTUDIOS
                                                join med in BaseDatos.GetBaseDatos().MEDICOS
                                                on ESTUDIOS.MEDICOID equals med.ID_MEDICO
                                                join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                                on ESTUDIOS.CUENTAID equals cuenta.ID_CUENTA
                                                join usu in BaseDatos.GetBaseDatos().USUARIOS
                                                on ESTUDIOS.USUARIOID equals usu.ID_USUARIO
                                                select new
                                                {
                                                    ID_PACIEN = cuenta.PACIENTE.ID_PACIENTE,
                                                    ID_ESTUDIO = ESTUDIOS.ID_ESTUDIO,
                                                    ID_MEDICO = med.ID_MEDICO,
                                                    ID_CUENTA = cuenta.ID_CUENTA,
                                                    MEDICOSOL = med.PERSONA.NOMBRE + " " + med.PERSONA.A_PATERNO + " " + med.PERSONA.A_MATERNO,
                                                    PACI = cuenta.PACIENTE.PERSONA.NOMBRE + " " + cuenta.PACIENTE.PERSONA.A_PATERNO + " " + cuenta.PACIENTE.PERSONA.A_MATERNO,
                                                    TOTA = ESTUDIOS.TOTAL,
                                                    CUENTAA = cuenta.TOTAL,
                                                    SALDO = cuenta.SALDO,
                                                    FAPLICACION = ESTUDIOS.FECHA_CREACION,
                                                    USUARIO = usu.EMPLEADO.PERSONA.NOMBRE
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
                MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar los estudios?", "Administracion", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        dynamic estudio = rgvEstudiosAplicados.SelectedItem;
                        int ide = estudio.ID_ESTUDIO;
                        if (rgvEstudiosAplicados.SelectedItem != null)
                        {
                            var estudi = BaseDatos.GetBaseDatos().ESTUDIOS.Find(ide);
                            Decimal total = Decimal.Parse(estudi.TOTAL.ToString());

                            int idc = estudio.ID_CUENTA;
                            var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idc);
                            cuenta.TOTAL = cuenta.TOTAL - total;
                            cuenta.SALDO = cuenta.SALDO - total;
                            BaseDatos.GetBaseDatos().SaveChanges();


                            BaseDatos.GetBaseDatos().ESTUDIOS.Remove(estudi);
                            BaseDatos.GetBaseDatos().SaveChanges();
                        }
                        MessageBox.Show("Se han eliminado los estudios", "Administracion");
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
                    if (rgvEstudiosAplicados.SelectedItem != null)
                    {
                        dynamic estudio = rgvEstudiosAplicados.SelectedItem;
                        int ide = estudio.ID_ESTUDIO;
                        int idme = estudio.ID_MEDICO;
                        int idpac = estudio.ID_PACIEN;
                        int idc = estudio.ID_CUENTA;

                        CargarEstudios ce = new CargarEstudios(ide, idme, idpac, idc);
                        ce.Show();
                        this.Close();

                    }
                }
            }

        }

    }
}
