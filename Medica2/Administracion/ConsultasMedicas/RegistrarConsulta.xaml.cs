using AccessoDB;
using Medica2.Administracion.Pacientes;
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

namespace Medica2.Administracion.ConsultasMedicas
{
    /// <summary>
    /// Lógica de interacción para RegistrarConsulta.xaml
    /// </summary>
    public partial class RegistrarConsulta : Window
    {
        int idconsul;
        int idcuen;
        int idmed, idpacie;

        DateTime fr = DateTime.Now;
        public RegistrarConsulta()
        {
            InitializeComponent();
            LlenarAucompletes();
        }

        public RegistrarConsulta(CONSULTA consul, int idcu, bool save)
        {


            var paci = BaseDatos.GetBaseDatos().PACIENTES.Find(consul.PACIENTEID);

            InitializeComponent();
            LlenarAucompletes();

            checkBoxConsulta.IsEnabled = false;
            idmed = Convert.ToInt32(consul.MEDICOID);
            idpacie = Convert.ToInt32(consul.PACIENTEID);
            idcuen = idcu;

            idconsul = consul.ID_CONSULTA;
            fechaconsulta.SelectedDate = consul.FECHA_CREACION;
            autoMedico.SearchText = consul.Medico.PERSONA.NOMBRE + " " + consul.Medico.PERSONA.A_PATERNO + " " + consul.Medico.PERSONA.A_MATERNO;
            txtCedula.Text = consul.Medico.C_PROFESIONAL;
            autoPacienteC.SearchText = paci.PERSONA.NOMBRE + " " + paci.PERSONA.A_PATERNO + " " + paci.PERSONA.A_MATERNO;
            txtPeso.Text = consul.PESO.ToString();
            txtPresion.Text = consul.P_ARTERIAL.ToString();
            txtTemperatura.Text = consul.TEMPERATURA.ToString();
            txtglucosa.Text = consul.GLUCOSA.ToString();
            txtAlergias.Text = consul.ALERGIAS;
            txtdiagnostico.Text = consul.DIAGNOSTICO;
            txtdescripcion.Text = consul.DESCRIPCION;
            txtmedicamento.Text = consul.MEDICAMENTOS;
            txtcostoconsulta.Text = consul.COSTO.ToString();

            fechaconsulta.IsEnabled = false;
            btnnGuardar.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Visible;
            btnRegistrarPaciente.Visibility = Visibility.Hidden;
            autoMedico.IsEnabled = false;
            autoPacienteC.IsEnabled = false;
            txtPacienteAmbu.IsEnabled = false;
            txtPacienteAmbu.Visibility = Visibility.Hidden;
            autoPacienteC.Visibility = Visibility.Visible;
            txtCedula.IsEnabled = false;



        }
        void LlenarAucompletes()
        {
            autoMedico.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                      join e in BaseDatos.GetBaseDatos().MEDICOS
                                      on PERSONA.ID_PERSONA equals e.PERSONAID
                                      select new
                                      {
                                          ID_MEDICO = e.ID_MEDICO,
                                          NOMBRE = PERSONA.NOMBRE + " " + PERSONA.A_PATERNO + " " + PERSONA.A_MATERNO,
                                      }).ToList();

            autoPacienteC.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                         join e in BaseDatos.GetBaseDatos().PACIENTES
                                         on PERSONA.ID_PERSONA equals e.PERSONAID
                                         join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                         on e.ID_PACIENTE equals cuenta.PACIENTEID
                                         select new
                                         {
                                             ID_PACIENTE = e.ID_PACIENTE,
                                             NOMBRE = PERSONA.NOMBRE + " " + PERSONA.A_PATERNO + " " + PERSONA.A_MATERNO,
                                             CUENTAA = cuenta.TOTAL,
                                             ID_CUENTA = cuenta.ID_CUENTA
                                         }).ToList();


        }

        void Guardar()
        {
            if (checkBoxConsulta.IsChecked == true)
            {
                autoPacienteC.Visibility = Visibility.Hidden;
                btnRegistrarPaciente.Visibility = Visibility.Hidden;

                if (autoMedico.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un Médico");
                }
                else
                {
                    if (txtPacienteAmbu.Text == "")
                    {
                        MessageBox.Show("Ingresa el nombre del Paciente");
                    }
                    else
                    {
                        if (txtdiagnostico.Text == "")
                        {
                            MessageBox.Show("Selecciona un Diagnóstico");
                        }
                        else
                        {
                            if (txtdescripcion.Text == "")
                            {
                                MessageBox.Show("Inserta una Descripción");
                            }
                            else
                            {
                                if (txtmedicamento.Text == "")
                                {
                                    MessageBox.Show("Inserta un Médicamento");
                                }
                                else
                                {
                                    if (txtcostoconsulta.Text == "")
                                    {
                                        MessageBox.Show("Inserta el Costo de la Consulta");
                                    }
                                    else
                                    {
                                        dynamic medico = autoMedico.SelectedItem;
                                        int idmed = medico.ID_MEDICO;

                                        CONSULTA con = new CONSULTA
                                        {

                                            MEDICOID = idmed,
                                            NOM_PACIENTE = txtPacienteAmbu.Text,
                                            DIAGNOSTICO = txtdiagnostico.Text,
                                            DESCRIPCION = txtdescripcion.Text,
                                            MEDICAMENTOS = txtmedicamento.Text,
                                            ALERGIAS = txtAlergias.Text,
                                            PESO = Convert.ToDecimal(txtPeso.Text),
                                            GLUCOSA = Convert.ToDecimal(txtglucosa.Text),
                                            TEMPERATURA = Convert.ToDecimal(txtTemperatura.Text),
                                            P_ARTERIAL = Convert.ToDecimal(txtPresion.Text),
                                            COSTO = Decimal.Parse(txtcostoconsulta.Text),
                                            USUARIOID = 2,
                                            FECHA_CREACION = fr,

                                        };
                                        BaseDatos.GetBaseDatos().CONSULTAS.Add(con);
                                        BaseDatos.GetBaseDatos().SaveChanges();

                                        limpiar();
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                if (checkBoxConsulta.IsChecked == false)
                {
                    txtPacienteAmbu.Visibility = Visibility.Visible;
                    btnRegistrarPaciente.Visibility = Visibility.Visible;

                }
                if (autoPacienteC.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un Paciente");
                }
                else
                {
                    if (autoMedico.SelectedItem == null)
                    {
                        MessageBox.Show("Selecciona un Médico");
                    }
                    else
                    {
                        if (txtdiagnostico.Text == "")
                        {
                            MessageBox.Show("Selecciona un Diagnóstico");
                        }
                        else
                        {
                            if (txtdescripcion.Text == "")
                            {
                                MessageBox.Show("Inserta una Descripción");
                            }
                            else
                            {
                                if (txtmedicamento.Text == "")
                                {
                                    MessageBox.Show("Inserta un Medicamento");
                                }
                                else
                                {
                                    if (txtcostoconsulta.Text == "")
                                    {
                                        MessageBox.Show("Inserta el costo de la Consulta");
                                    }
                                    else
                                    {


                                        dynamic paciente = autoPacienteC.SelectedItem;
                                        dynamic medico = autoMedico.SelectedItem;

                                        int idmed = medico.ID_MEDICO;
                                        int idpac = paciente.ID_PACIENTE;


                                        CONSULTA con = new CONSULTA
                                        {

                                            MEDICOID = idmed,
                                            PACIENTEID = idpac,
                                            DIAGNOSTICO = txtdiagnostico.Text,
                                            DESCRIPCION = txtdescripcion.Text,
                                            MEDICAMENTOS = txtmedicamento.Text,
                                            ALERGIAS = txtAlergias.Text,
                                            PESO = Convert.ToDecimal(txtPeso.Text),
                                            GLUCOSA = Convert.ToDecimal(txtglucosa.Text),
                                            TEMPERATURA = Convert.ToDecimal(txtTemperatura.Text),
                                            P_ARTERIAL = Convert.ToDecimal(txtPresion.Text),
                                            USUARIOID = 2,
                                            COSTO = Decimal.Parse(txtcostoconsulta.Text),
                                            FECHA_CREACION = fr,

                                        };
                                        BaseDatos.GetBaseDatos().CONSULTAS.Add(con);
                                        BaseDatos.GetBaseDatos().SaveChanges();

                                        int idcuent = paciente.ID_CUENTA;
                                        var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuent);

                                        cuenta.TOTAL = cuenta.TOTAL + Decimal.Parse(txtcostoconsulta.Text);
                                        cuenta.SALDO = cuenta.SALDO + Decimal.Parse(txtcostoconsulta.Text);
                                        BaseDatos.GetBaseDatos().SaveChanges();
                                        limpiartodo();

                                    }

                                }

                            }

                        }

                    }
                }
            }



        }

        void Editar()
        {
            if (checkBoxConsulta.IsChecked == false)
            {
                autoPacienteC.Visibility = Visibility.Hidden;
                btnRegistrarPaciente.Visibility = Visibility.Hidden;

                if (txtdiagnostico.Text == "")
                {
                    MessageBox.Show("Selecciona un Diagnóstico");
                }
                else
                {
                    if (txtdescripcion.Text == "")
                    {
                        MessageBox.Show("Inserta una Descripción");
                    }
                    else
                    {
                        if (txtmedicamento.Text == "")
                        {
                            MessageBox.Show("Inserta un Médicamento");
                        }
                        else
                        {
                            if (txtcostoconsulta.Text == "")
                            {
                                MessageBox.Show("Inserta el costo de la Consulta");
                            }
                            else
                            {
                                if (txtPeso.Text == "")
                                {
                                    MessageBox.Show("Ingresa el Peso del Paciente");
                                }
                                else
                                {
                                    if (txtglucosa.Text == "")
                                    {
                                        MessageBox.Show("Ingresa la glucosa del Paciente");

                                    }
                                    else
                                    {
                                        if (txtTemperatura.Text == "")
                                        {
                                            MessageBox.Show("Ingresa la Temperatura del Paciente");
                                        }
                                        else
                                        {
                                            if (txtPresion.Text == "")
                                            {
                                                MessageBox.Show("Ingresa la presión del Paceinte");
                                            }
                                            else
                                            {
                                                DateTime fec = DateTime.Now;

                                                var consultaHos = BaseDatos.GetBaseDatos().CONSULTAS.Find(idconsul);

                                                var quitardecuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuen);
                                                quitardecuenta.SALDO = quitardecuenta.SALDO - consultaHos.COSTO;
                                                quitardecuenta.TOTAL = quitardecuenta.TOTAL - consultaHos.COSTO;
                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                consultaHos.MEDICOID = idmed;
                                                consultaHos.PACIENTEID = idpacie;
                                                consultaHos.DIAGNOSTICO = txtdiagnostico.Text;
                                                consultaHos.DESCRIPCION = txtdescripcion.Text;
                                                consultaHos.MEDICAMENTOS = txtmedicamento.Text;
                                                consultaHos.ALERGIAS = txtAlergias.Text;
                                                consultaHos.USUARIOID = 2;
                                                consultaHos.COSTO = Decimal.Parse(txtcostoconsulta.Text);
                                                consultaHos.PESO = Convert.ToDecimal(txtPeso.Text);
                                                consultaHos.GLUCOSA = Convert.ToDecimal(txtglucosa.Text);
                                                consultaHos.P_ARTERIAL = Convert.ToDecimal(txtPresion.Text);
                                                consultaHos.TEMPERATURA = Convert.ToDecimal(txtTemperatura.Text);
                                                consultaHos.FECHA_MOD = fec;

                                                BaseDatos.GetBaseDatos().SaveChanges();


                                                var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuen);

                                                cuenta.TOTAL = cuenta.TOTAL + Decimal.Parse(txtcostoconsulta.Text);
                                                cuenta.SALDO = cuenta.SALDO + Decimal.Parse(txtcostoconsulta.Text);
                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                limpiartodo();
                                                this.Close();
                                                VisualizarConsultas obj = new VisualizarConsultas();
                                                obj.Show();
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }

                }
            }
            else
            {
                if (checkBoxConsulta.IsChecked == true)
                {
                    txtPacienteAmbu.Visibility = Visibility.Visible;
                    btnRegistrarPaciente.Visibility = Visibility.Visible;
                }
                if (autoPacienteC.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un Paciente");
                }
                else
                {
                    if (autoMedico.SelectedItem == null)
                    {
                        MessageBox.Show("Selecciona un Médico");
                    }
                    else
                    {
                        if (txtdiagnostico.Text == "")
                        {
                            MessageBox.Show("Selecciona un Diagnóstico");
                        }
                        else
                        {
                            if (txtdescripcion.Text == "")
                            {
                                MessageBox.Show("Inserta una Descripción");
                            }
                            else
                            {
                                if (txtmedicamento.Text == "")
                                {
                                    MessageBox.Show("Inserta un Medicamento");
                                }
                                else
                                {
                                    if (txtcostoconsulta.Text == "")
                                    {
                                        MessageBox.Show("Inserta el costo de la Consulta");
                                    }
                                    else
                                    {
                                        var consultaAm = BaseDatos.GetBaseDatos().CONSULTAS.Find(idconsul);
                                        DateTime fec = DateTime.Now;
                                        dynamic medico = autoMedico.SelectedItem;
                                        int idmed = medico.ID_MEDICO;

                                        consultaAm.MEDICOID = idmed;
                                        consultaAm.NOM_PACIENTE = txtPacienteAmbu.Text;
                                        consultaAm.DIAGNOSTICO = txtdiagnostico.Text;
                                        consultaAm.DESCRIPCION = txtdescripcion.Text;
                                        consultaAm.MEDICAMENTOS = txtmedicamento.Text;
                                        consultaAm.ALERGIAS = txtAlergias.Text;
                                        consultaAm.COSTO = Decimal.Parse(txtcostoconsulta.Text);
                                        consultaAm.PESO = Convert.ToDecimal(txtPeso.Text);
                                        consultaAm.GLUCOSA = Convert.ToDecimal(txtglucosa.Text);
                                        consultaAm.P_ARTERIAL = Convert.ToDecimal(txtPresion.Text);
                                        consultaAm.TEMPERATURA = Convert.ToDecimal(txtTemperatura.Text);
                                        consultaAm.USUARIOID = 2;
                                        consultaAm.FECHA_MOD = fec;

                                        BaseDatos.GetBaseDatos().SaveChanges();



                                        limpiar();



                                    }

                                }

                            }

                        }

                    }
                }
            }



        }

        void limpiartodo()
        {
            autoMedico.SearchText = String.Empty;
            autoPacienteC.SearchText = String.Empty;
            txtdiagnostico.Text = String.Empty;
            txtdescripcion.Text = String.Empty;
            txtmedicamento.Text = String.Empty;
            txtAlergias.Text = String.Empty;
            txtPresion.Text = String.Empty;
            txtglucosa.Text = String.Empty;
            txtPresion.Text = String.Empty;
            txtPeso.Text = String.Empty;
            txtCedula.Text = String.Empty;
            txtcostoconsulta.Text = String.Empty;
            txtTemperatura.Text = String.Empty;

        }
        void limpiar()
        {
            txtCedula.Text = String.Empty;
            txtPacienteAmbu.Text = String.Empty;
            autoMedico.SearchText = String.Empty;
            txtdiagnostico.Text = String.Empty;
            txtdescripcion.Text = String.Empty;
            txtmedicamento.Text = String.Empty;
            txtcostoconsulta.Text = String.Empty;
            txtAlergias.Text = String.Empty;
            txtPresion.Text = String.Empty;
            txtglucosa.Text = String.Empty;
            txtPresion.Text = String.Empty;
            txtPeso.Text = String.Empty;
            txtTemperatura.Text = String.Empty;
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void checkBoxConsulta_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxConsulta.IsChecked == true)
            {
                txtPacienteAmbu.Visibility = Visibility.Visible;
                autoPacienteC.Visibility = Visibility.Hidden;
            }
        }

        private void checkBoxConsulta_Unchecked(object sender, RoutedEventArgs e)
        {
            if (checkBoxConsulta.IsChecked == false)
            {
                txtPacienteAmbu.Visibility = Visibility.Hidden;
                autoPacienteC.Visibility = Visibility.Visible;
            }

        }

        private void buttonRegistrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();

            //IngresoPaciente obj = new IngresoPaciente(autoPacienteC);
            //obj.Show();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }

        private void autoMedico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (autoMedico.SelectedItem != null)
            {
                dynamic medi = autoMedico.SelectedItem;
                int idmedi = medi.ID_MEDICO;

                var medico = BaseDatos.GetBaseDatos().MEDICOS.Find(idmedi);

                txtCedula.Text = medico.C_PROFESIONAL;
            }
        }

        private void validarLetras(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        private void validarNumeros(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;

        }
    }
}
