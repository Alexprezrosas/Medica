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
        int idhono;
        int idpaciente;
        int idcue;
        int idmed;
        public CargarHonorarioMedico()
        {
            InitializeComponent();
            CargarAutocompletes();
        }

        public CargarHonorarioMedico(HONORARIOS_MEDICOS h, int idc, bool save)
        {
            InitializeComponent();
            CargarAutocompletes();

            idhono = h.ID_HONORARIO_MEDICO;
            idpaciente = h.PACIENTEID;
            idcue = idc;
            idmed = h.MEDICOID;



            var paci = BaseDatos.GetBaseDatos().PACIENTES.Find(h.PACIENTEID);
            var med = BaseDatos.GetBaseDatos().MEDICOS.Find(h.MEDICOID);

            automedico.SearchText = med.PERSONA.NOMBRE + " " + med.PERSONA.A_PATERNO + " " + med.PERSONA.A_MATERNO;
            autoPaciente.SearchText = paci.PERSONA.NOMBRE + " " + paci.PERSONA.A_PATERNO + " " + paci.PERSONA.A_MATERNO;
            txtHonorario.Text = h.HONORIARIO.ToString();

            btnEditar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Hidden;
            autoPaciente.IsEnabled = false;
            automedico.IsEnabled = false;


        }
        void CargarAutocompletes()
        {


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
                                            APATERNO = PERSONA.A_PATERNO,
                                            CUENTAA = cuenta.TOTAL,
                                            ID_CUENTA = cuenta.ID_CUENTA
                                        }).ToList();

            automedico.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                      join e in BaseDatos.GetBaseDatos().MEDICOS
                                      on PERSONA.ID_PERSONA equals e.PERSONAID
                                      where e.PERSONA.ESTADOPERSONA == "Activo"
                                      select new
                                      {
                                          ID_MEDICO = e.ID_MEDICO,
                                          NOMBRE = PERSONA.NOMBRE + " " + PERSONA.A_PATERNO + " " + PERSONA.A_MATERNO,
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
                    MessageBox.Show("Selecciona un Médico");

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
        void Editar()
        {



            if (txtHonorario.Text == "")
            {
                MessageBox.Show("Ingresa el Honorario");
            }
            else
            {
                var h = BaseDatos.GetBaseDatos().HONORARIOS_MEDICOS.Find(idhono);
                var cuent = BaseDatos.GetBaseDatos().CUENTAS.Find(idcue);
                int idcu = cuent.ID_CUENTA;
                cuent.TOTAL = cuent.TOTAL - h.HONORIARIO;
                cuent.SALDO = cuent.SALDO - h.HONORIARIO;
                BaseDatos.GetBaseDatos().SaveChanges();
                //...........................................................................................    

                h.PACIENTEID = idpaciente;
                h.MEDICOID = idmed;
                h.HONORIARIO = Convert.ToDecimal(txtHonorario.Text);
                BaseDatos.GetBaseDatos().SaveChanges();


                cuent.TOTAL = cuent.TOTAL + Convert.ToDecimal(txtHonorario.Text);
                cuent.SALDO = cuent.SALDO + Convert.ToDecimal(txtHonorario.Text);
                BaseDatos.GetBaseDatos().SaveChanges();
                MessageBox.Show("Registro exitoso, se actualizo correctamente");

                VizualizarHonorariosCargados obj = new VizualizarHonorariosCargados();
                obj.Show();
                this.Close();
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

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }
    }
}