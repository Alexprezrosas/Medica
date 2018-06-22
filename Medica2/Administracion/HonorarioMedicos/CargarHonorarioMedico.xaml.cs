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

namespace Medica2.Administracion.HonorarioMedicos
{
    /// <summary>
    /// Lógica de interacción para CargarHonorarioMedico.xaml
    /// </summary>
    public partial class CargarHonorarioMedico : Window
    {
        public CargarHonorarioMedico()
        {
            InitializeComponent();
            CargarAutocompletes();
        }
        void CargarAutocompletes()
        {


            autoPaciente.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                        join e in BaseDatos.GetBaseDatos().PACIENTES
                                        on PERSONA.ID_PERSONA equals e.PERSONAID
                                        join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                        on e.ID_PACIENTE equals cuenta.PACIENTEID
                                        select new
                                        {
                                            ID_PACIENTE = e.ID_PACIENTE,
                                            NOMBRE = PERSONA.NOMBRE,
                                            APATERNO = PERSONA.A_PATERNO,
                                            CUENTAA = cuenta.TOTAL,
                                            ID_CUENTA = cuenta.ID_CUENTA
                                        }).ToList();

            automedico.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                      join e in BaseDatos.GetBaseDatos().MEDICOS
                                      on PERSONA.ID_PERSONA equals e.PERSONAID
                                      select new
                                      {
                                          ID_MEDICO = e.ID_MEDICO,
                                          NOMBRE = PERSONA.NOMBRE,
                                      }).ToList();


        }
        void Limpiar()
        {
            autoPaciente.SearchText = String.Empty;
            automedico.SearchText = String.Empty;
            txtHonorario.Text = String.Empty;

        }
        void Guardar()
        {
            if (autoPaciente.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un Paciente");
            }
            else
            {
                if (automedico.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un Medico");

                }
                else
                {
                    if (txtHonorario.Text == "")
                    {
                        MessageBox.Show("Ingresa el Honorario");
                    }
                    else
                    {
                        DateTime fech = DateTime.Now;
                        dynamic paciente = autoPaciente.SelectedItem;
                        dynamic medico = automedico.SelectedItem;

                        int idpaciente = paciente.ID_PACIENTE;
                        int idmedico = medico.ID_MEDICO;
                        int idc = paciente.ID_CUENTA;
                        var cue = BaseDatos.GetBaseDatos().CUENTAS.Find(idc);

                        HONORARIOS_MEDICOS hm = new HONORARIOS_MEDICOS
                        {
                            PACIENTEID = idpaciente,
                            MEDICOID = idmedico,
                            HONORIARIO = Decimal.Parse(txtHonorario.Text),
                            USUARIOID = 2,
                            FECHA_CREACION = fech,

                        };
                        BaseDatos.GetBaseDatos().HONORARIOS_MEDICOS.Add(hm);
                        BaseDatos.GetBaseDatos().SaveChanges();

                        var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idc);
                        cuenta.TOTAL = cuenta.TOTAL + Decimal.Parse(txtHonorario.Text);
                        cuenta.SALDO = cuenta.SALDO + Decimal.Parse(txtHonorario.Text);

                        BaseDatos.GetBaseDatos().SaveChanges();
                        MessageBox.Show("Honorario Cargado");
                        Limpiar();

                    }
                }
            }
        }

        private void validarDecimal(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57 || ascci == 46)

                e.Handled = false;

            else e.Handled = true;


        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            Guardar();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}