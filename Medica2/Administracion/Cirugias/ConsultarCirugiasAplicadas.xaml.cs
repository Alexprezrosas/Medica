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

namespace Medica2.Administracion.Cirugias
{
    /// <summary>
    /// Lógica de interacción para ConsultarCirugiasAplicadas.xaml
    /// </summary>
    public partial class ConsultarCirugiasAplicadas : Window
    {
        public ConsultarCirugiasAplicadas()
        {
            InitializeComponent();
            VistaCirugiasAplicadas();
        }

        public void VistaCirugiasAplicadas()
        {
            rgvCirugiasAplicadas.ItemsSource = (from ciru in BaseDatos.GetBaseDatos().CIRUGIAS
                                                join medi in BaseDatos.GetBaseDatos().MEDICOS
                                                on ciru.MEDICOID equals medi.ID_MEDICO
                                                join catciru in BaseDatos.GetBaseDatos().CATALOGO_CIRUGIAS
                                                on ciru.CATALOGO_CIRUGIAID equals catciru.ID_CATALOGO_CIRUGIA
                                                join cue in BaseDatos.GetBaseDatos().CUENTAS
                                                on ciru.CUENTAID equals cue.ID_CUENTA
                                                join usu in BaseDatos.GetBaseDatos().USUARIOS
                                                on ciru.USUARIOID equals usu.ID_USUARIO
                                                join paci in BaseDatos.GetBaseDatos().PACIENTES
                                                on cue.PACIENTEID equals paci.ID_PACIENTE
                                                where paci.PERSONA.ESTADOPERSONA == "Activo"
                                                select new
                                                {
                                                    ID_PACIENTE = paci.ID_PACIENTE,
                                                    ID_CUENTA = cue.ID_CUENTA,
                                                    ID_CIRUGIA = ciru.ID_CIRUGIA,
                                                    ID_MEDICO = medi.ID_MEDICO,
                                                    ID_CAT_CIRUGIA = catciru.ID_CATALOGO_CIRUGIA,

                                                    MEDICOSOL = medi.PERSONA.NOMBRE + " " + medi.PERSONA.A_PATERNO + " " + medi.PERSONA.A_MATERNO,
                                                    PACIENTENOM = paci.PERSONA.NOMBRE + " " + paci.PERSONA.A_PATERNO + " " + paci.PERSONA.A_MATERNO,
                                                    CIRUGIANOM = catciru.NOMBRE_CIRUGIA,
                                                    COSTO = ciru.TOTAL,
                                                    CUENTAA = cue.TOTAL,
                                                    SALDO = cue.SALDO,
                                                    FAPLICACION = ciru.FECHA_CREACION,
                                                    USU = usu.EMPLEADO.PERSONA.NOMBRE
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
                itemAgregar.IsEnabled = true;
                itemEliminar.IsEnabled = true;
                itemEditar.IsEnabled = true;
            }

        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemAgregar)
            {
                CargarCirugia cargargaciru = new CargarCirugia();
                cargargaciru.Show();
                this.Close();

            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar la Cirugua?", "Administracion", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            dynamic idpaci = rgvCirugiasAplicadas.SelectedItem;
                            int idp = idpaci.ID_PACIENTE;
                            int idcuenta = idpaci.ID_CUENTA;
                            int idciru = idpaci.ID_CIRUGIA;

                            if (rgvCirugiasAplicadas.SelectedItem != null)
                            {
                                var ceunt = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuenta);
                                var ciru = BaseDatos.GetBaseDatos().CIRUGIAS.Find(idciru);

                                ceunt.TOTAL = ceunt.TOTAL - ciru.TOTAL;
                                ceunt.SALDO = ceunt.SALDO - ciru.TOTAL;
                                BaseDatos.GetBaseDatos().SaveChanges();

                                BaseDatos.GetBaseDatos().CIRUGIAS.Remove(ciru);
                                BaseDatos.GetBaseDatos().SaveChanges();
                                MessageBox.Show("Cirugia Eliminada Corectamente");
                                VistaCirugiasAplicadas();
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
                        if (rgvCirugiasAplicadas.SelectedItem != null)
                        {
                            dynamic idpaci = rgvCirugiasAplicadas.SelectedItem;
                            int idp = idpaci.ID_PACIENTE;
                            int idmed = idpaci.ID_MEDICO;
                            int idciru = idpaci.ID_CIRUGIA;
                            int idcuent = idpaci.ID_CUENTA;

                            CargarCirugia obj = new CargarCirugia(idp, idmed, idciru, idcuent);
                            obj.Show();
                            this.Close();
                        }
                    }
                }
            }
        }


    }
}
