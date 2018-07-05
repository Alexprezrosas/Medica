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

namespace Medica2.Administracion.Cirugias
{
    /// <summary>
    /// Lógica de interacción para CargarCirugia.xaml
    /// </summary>
    public partial class CargarCirugia : Window
    {
        int idper, idmedi, idcirug, idcuenta;
        int idUsuario;
        DateTime fr = DateTime.Now;

        public CargarCirugia()
        {
            InitializeComponent();
            llenarAutocompletes();
        }

        public CargarCirugia(int idu)
        {
            InitializeComponent();
            llenarAutocompletes();
            idUsuario = idu;
        }

        public CargarCirugia(int idp, int idmed, int idciru, int idcuent)
        {
            InitializeComponent();
            llenarAutocompletes();

            idper = idp;
            idmedi = idmed;
            idcirug = idciru;
            idcuenta = idcuent;

            var paciente = BaseDatos.GetBaseDatos().PACIENTES.Find(idper);
            var medico = BaseDatos.GetBaseDatos().MEDICOS.Find(idmedi);
            var cirugia = BaseDatos.GetBaseDatos().CIRUGIAS.Find(idcirug);
            var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuent);

            cuenta.TOTAL = cuenta.TOTAL - cirugia.TOTAL;
            cuenta.SALDO = cuenta.SALDO - cirugia.TOTAL;
            BaseDatos.GetBaseDatos().SaveChanges();

            autoPaciente.SearchText = paciente.PERSONA.NOMBRE + " " + paciente.PERSONA.A_PATERNO + " " + paciente.PERSONA.A_MATERNO;
            autoMedico.SearchText = medico.PERSONA.NOMBRE + " " + medico.PERSONA.A_PATERNO + " " + medico.PERSONA.A_MATERNO;
            autoCirugia.SearchText = cirugia.CATALOGO_CIRUGIAS.NOMBRE_CIRUGIA;
            txtCosto.Text = cirugia.TOTAL.ToString();
            llenarAutocompletes();
            btnFinalizar.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Visible;

            autoPaciente.IsEnabled = false;
            autoMedico.IsEnabled = false;

        }

        void llenarAutocompletes()
        {
            autoCirugia.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_CIRUGIAS.ToList();

            autoMedico.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                      join e in BaseDatos.GetBaseDatos().MEDICOS
                                      on PERSONA.ID_PERSONA equals e.PERSONAID
                                      where e.PERSONA.ESTADOPERSONA == "Activo"
                                      select new
                                      {
                                          ID_MEDICO = e.ID_MEDICO,
                                          NOMBRE = PERSONA.NOMBRE + " " + PERSONA.A_PATERNO + " " + PERSONA.A_MATERNO,
                                      }).ToList();

            autoPaciente.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                        join e in BaseDatos.GetBaseDatos().PACIENTES
                                        on PERSONA.ID_PERSONA equals e.PERSONAID
                                        join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                        on e.ID_PACIENTE equals cuenta.PACIENTEID
                                        where PERSONA.ESTADOPERSONA == "Activo"
                                        select new
                                        {
                                            ID_PACIENTE = e.ID_PACIENTE,
                                            NOMBRE = PERSONA.NOMBRE + " " + PERSONA.A_PATERNO + " " + PERSONA.A_MATERNO,
                                            CUENTAA = cuenta.TOTAL,
                                            ID_CUENTA = cuenta.ID_CUENTA
                                        }).ToList();
        }

        void Editar()
        {


            autoPaciente.IsEnabled = false;
            autoMedico.IsEnabled = false;

            if (autoCirugia.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una cirugía");
            }
            else
            {

                int cirugia = ((CATALOGO_CIRUGIAS)autoCirugia.SelectedItem).ID_CATALOGO_CIRUGIA;



                var cgia = BaseDatos.GetBaseDatos().CIRUGIAS.Find(idcirug);
                cgia.CATALOGO_CIRUGIAID = cirugia;
                cgia.TOTAL = Decimal.Parse(txtCosto.Text);
                cgia.MEDICOID = idmedi;
                cgia.USUARIOID = 2;
                //cgia.CUENTAID = idcuenta;
                BaseDatos.GetBaseDatos().SaveChanges();

                var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuenta);
                cuenta.TOTAL = ((cuenta.TOTAL) + (Decimal.Parse(txtCosto.Text)));
                cuenta.SALDO = ((cuenta.SALDO) + (Decimal.Parse(txtCosto.Text)));
                BaseDatos.GetBaseDatos().SaveChanges();
                MessageBox.Show("Actualización exitosa");

                ConsultarCirugiasAplicadas obj = new ConsultarCirugiasAplicadas();
                obj.Show();
                Close();
            }


        }


        void limpiar()
        {
            autoCirugia.SearchText = String.Empty;
            autoMedico.SearchText = String.Empty;
            autoPaciente.SearchText = String.Empty;
            txtCosto.Text = String.Empty;
        }

        void llenarCosto()
        {
            if (autoCirugia.SelectedItem != null)
            {
                int idciru = ((CATALOGO_CIRUGIAS)autoCirugia.SelectedItem).ID_CATALOGO_CIRUGIA;
                var busquedaest = BaseDatos.GetBaseDatos().CATALOGO_CIRUGIAS.Find(idciru);
                txtCosto.Text = busquedaest.COSTO.ToString();
                //
            }
        }

        void Guardar()
        {
            if (autoPaciente.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un paciente");
            }
            else
            {
                if (autoMedico.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona al médico solicitante");
                }
                else
                {
                    if (autoCirugia.SelectedItem == null)
                    {
                        MessageBox.Show("Selecciona una cirugía");
                    }
                    else
                    {
                        dynamic medico = autoMedico.SelectedItem;
                        dynamic paciente = autoPaciente.SelectedItem;
                        dynamic cirugia = autoCirugia.SelectedItem;
                        int idcuenta = paciente.ID_CUENTA;
                        CIRUGIA c = new CIRUGIA
                        {
                            MEDICOID = medico.ID_MEDICO,
                            DESCRIPCION = cirugia.DESCRIPCION,
                            CATALOGO_CIRUGIAID = cirugia.ID_CATALOGO_CIRUGIA,
                            CUENTAID = paciente.ID_CUENTA,
                            TOTAL = cirugia.COSTO,
                            USUARIOID = idUsuario,
                            FECHA_CREACION = fr
                        };
                        BaseDatos.GetBaseDatos().CIRUGIAS.Add(c);
                        BaseDatos.GetBaseDatos().SaveChanges();

                        var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuenta);
                        cuenta.TOTAL = ((cuenta.TOTAL) + (Decimal.Parse(txtCosto.Text)));
                        cuenta.SALDO = ((cuenta.SALDO) + (Decimal.Parse(txtCosto.Text)));
                        BaseDatos.GetBaseDatos().SaveChanges();
                        MessageBox.Show("Registro exitoso");
                        limpiar();
                    }
                }
            }
        }

        private void autoCirugia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            llenarCosto();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
