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

namespace Medica2.Administracion.Depositos
{
    /// <summary>
    /// Lógica de interacción para ConsultarDepositosAplicados.xaml
    /// </summary>
    public partial class ConsultarDepositosAplicados : Window
    {
        public ConsultarDepositosAplicados()
        {
            InitializeComponent();
            VistaGrid();
        }

        public ConsultarDepositosAplicados(int idu)
        {
            InitializeComponent();
            VistaGrid();
            var usuario = BaseDatos.GetBaseDatos().USUARIOS.Find(idu);
            if (usuario.EMPLEADO.PUESTO == "Administrador")
            {
                GridContextMenu2.Visibility = Visibility.Visible;
            }else
            {
                if (usuario.EMPLEADO.PUESTO == "Recepcionista")
                {
                    itemEditar.Visibility = Visibility.Hidden;
                    itemEliminar.Visibility = Visibility.Hidden;
                }
            }
        }

        public void VistaGrid()
        {
            rgvDepositosAplicados.ItemsSource = (from depo in BaseDatos.GetBaseDatos().DEPOSITOS
                                                 join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                                 on depo.CUENTAID equals cuenta.ID_CUENTA
                                                 join paci in BaseDatos.GetBaseDatos().PACIENTES
                                                 on cuenta.PACIENTEID equals paci.ID_PACIENTE
                                                 join usuario in BaseDatos.GetBaseDatos().USUARIOS
                                                 on depo.USUARIOID equals usuario.ID_USUARIO
                                                 select new
                                                 {
                                                     ID_PACIENTE = paci.ID_PACIENTE,
                                                     ID_CUENTA = cuenta.ID_CUENTA,
                                                     ID_DEPOSITO = depo.ID_DEPOSITO,
                                                     PACIENTENOM = paci.PERSONA.NOMBRE,
                                                     PPATERNO = paci.PERSONA.A_PATERNO,
                                                     PMATERNO = paci.PERSONA.A_MATERNO,
                                                     CONCEPTO = depo.CONCEPTO,
                                                     MONTO = depo.MONTO,
                                                     CUENTAA = cuenta.TOTAL,
                                                     SALDO = cuenta.SALDO,
                                                     USUA = usuario.EMPLEADO.PERSONA.NOMBRE,
                                                     FAPLICACION = depo.FECHA_CREACION
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
                RegistrarDeposito rd = new RegistrarDeposito();
                rd.Show();
                this.Close();

            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el deposito?", "Administracion", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            dynamic paciente = rgvDepositosAplicados.SelectedItem;
                            int idp = paciente.ID_PACIENTE;
                            int idcuenta = paciente.ID_CUENTA;
                            int iddepo = paciente.ID_DEPOSITO;

                            if (rgvDepositosAplicados.SelectedItem != null)
                            {
                                var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuenta);
                                var deposito = BaseDatos.GetBaseDatos().DEPOSITOS.Find(iddepo);

                                cuenta.TOTAL = cuenta.TOTAL - deposito.MONTO;
                                cuenta.SALDO = cuenta.SALDO - deposito.MONTO;
                                BaseDatos.GetBaseDatos().SaveChanges();

                                BaseDatos.GetBaseDatos().DEPOSITOS.Remove(deposito);
                                BaseDatos.GetBaseDatos().SaveChanges();
                                MessageBox.Show("El Deposito se ha eliminado correctamente");
                                VistaGrid();
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
                        if (rgvDepositosAplicados.SelectedItem != null)
                        {
                            dynamic paciente = rgvDepositosAplicados.SelectedItem;
                            int idp = paciente.ID_PACIENTE;
                            int iddepo = paciente.ID_DEPOSITO;
                            int idcuent = paciente.ID_CUENTA;

                            RegistrarDeposito obj = new RegistrarDeposito(idp, iddepo, idcuent);
                            obj.Show();
                            this.Close();
                        }
                    }
                }
            }
        }


    }
}
