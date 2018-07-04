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

namespace Medica2.Administracion.HonorarioMedicos
{
    /// <summary>
    /// Lógica de interacción para VizualizarHonorariosCargados.xaml
    /// </summary>
    public partial class VizualizarHonorariosCargados : Window
    {
        public VizualizarHonorariosCargados()
        {
            InitializeComponent();
            VistaHonorarios();
        }
        public void VistaHonorarios()
        {
            rgvVHonorariosc.ItemsSource = (from hono in BaseDatos.GetBaseDatos().HONORARIOS_MEDICOS
                                           join med in BaseDatos.GetBaseDatos().MEDICOS
                                           on hono.MEDICOID equals med.ID_MEDICO
                                           join paci in BaseDatos.GetBaseDatos().PACIENTES
                                           on hono.PACIENTEID equals paci.ID_PACIENTE
                                           join usu in BaseDatos.GetBaseDatos().USUARIOS
                                           on hono.USUARIOID equals usu.ID_USUARIO
                                           join cuen in BaseDatos.GetBaseDatos().CUENTAS
                                           on paci.ID_PACIENTE equals cuen.PACIENTEID
                                           where cuen.PACIENTE.PERSONA.ESTADOPERSONA == "Activo"
                                           select new
                                           {
                                               IDCUEN = cuen.ID_CUENTA,
                                               ID_HONORARIO = hono.ID_HONORARIO_MEDICO,
                                               IDMEDICO = med.ID_MEDICO,
                                               IDPACIENTE = paci.ID_PACIENTE,
                                               IDUSUA = usu.ID_USUARIO,
                                               HONO = hono.HONORIARIO,
                                               NOMMED = med.PERSONA.NOMBRE + " " + med.PERSONA.A_PATERNO + " " + med.PERSONA.A_MATERNO,
                                               NOMPACI = paci.PERSONA.NOMBRE + " " + paci.PERSONA.A_PATERNO + " " + paci.PERSONA.A_MATERNO,
                                               NOMUSU = usu.EMPLEADO.PERSONA.NOMBRE + " " + usu.EMPLEADO.PERSONA.A_PATERNO,
                                               FECHA = hono.FECHA_CREACION

                                           });
        }
        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvVHonorariosc.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
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
                CargarHonorarioMedico chm = new CargarHonorarioMedico();
                chm.Show();
                this.Close();

            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el Honorario del Médico?", "Administración", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            dynamic idhm = rgvVHonorariosc.SelectedItem;
                            int idhono = idhm.ID_HONORARIO;

                            if (rgvVHonorariosc.SelectedItem != null)
                            {
                                var cenfer = BaseDatos.GetBaseDatos().HONORARIOS_MEDICOS.Find(idhono);
                                BaseDatos.GetBaseDatos().HONORARIOS_MEDICOS.Remove(cenfer);
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado el Honorario del Médico", "Administración");
                            VistaHonorarios();

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
                        if (rgvVHonorariosc.SelectedItem != null)
                        {
                            dynamic idhonora = rgvVHonorariosc.SelectedItem;
                            int idhno = idhonora.ID_HONORARIO;
                            int idc = idhonora.IDCUEN;

                            var h = BaseDatos.GetBaseDatos().HONORARIOS_MEDICOS.Find(idhno);

                            CargarHonorarioMedico pr = new CargarHonorarioMedico(h, idc, false);
                            pr.Show();
                            this.Close();

                        }
                    }
                }
            }
        }


    }
}
