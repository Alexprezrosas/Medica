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
        DateTime fr = DateTime.Now;
        public RegistrarConsulta()
        {
            InitializeComponent();
            LlenarAucompletes();
        }
        void LlenarAucompletes()
        {
            autoMedico.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                      join e in BaseDatos.GetBaseDatos().MEDICOS
                                      on PERSONA.ID_PERSONA equals e.PERSONAID
                                      select new
                                      {
                                          ID_MEDICO = e.ID_MEDICO,
                                          NOMBRE = PERSONA.NOMBRE,
                                      }).ToList();

            autoPacienteC.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                         join e in BaseDatos.GetBaseDatos().PACIENTES
                                         on PERSONA.ID_PERSONA equals e.PERSONAID
                                         join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                         on e.ID_PACIENTE equals cuenta.PACIENTEID
                                         select new
                                         {
                                             ID_PACIENTE = e.ID_PACIENTE,
                                             NOMBRE = PERSONA.NOMBRE,
                                             CUENTAA = cuenta.TOTAL,
                                             ID_CUENTA = cuenta.ID_CUENTA
                                         }).ToList();


        }

        void Guardar()
        {
            if (checkBoxConsulta.IsChecked == true)
            {
                autoPacienteC.Visibility = Visibility.Hidden;
                buttonRegistrarPaciente.Visibility = Visibility.Hidden;

                if (autoMedico.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un Medico");
                }
                else
                {
                    if (txtPaciente.Text == "")
                    {
                        MessageBox.Show("Ingresa el Nombre del Paciente");
                    }
                    else
                    {
                        if (txtdiagnostico.Text == "")
                        {
                            MessageBox.Show("Selecciona un Diagnostico");
                        }
                        else
                        {
                            if (txtdescripcion.Text == "")
                            {
                                MessageBox.Show("Inserta una Descripcion");
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
                                        MessageBox.Show("Inserta el Costo de la Consulta");
                                    }
                                    else
                                    {
                                        dynamic medico = autoMedico.SelectedItem;
                                        int idmed = medico.ID_MEDICO;

                                        CONSULTA con = new CONSULTA
                                        {

                                            MEDICOID = idmed,
                                            NOM_PACIENTE = txtPaciente.Text,
                                            DIAGNOSTICO = txtdiagnostico.Text,
                                            DESCRIPCION = txtdescripcion.Text,
                                            MEDICAMENTOS = txtmedicamento.Text,
                                            COSTO = Decimal.Parse(txtcostoconsulta.Text),
                                            USUARIOID = 2,
                                            FECHA_CREACION = fr,

                                        };
                                        BaseDatos.GetBaseDatos().CONSULTAS.Add(con);
                                        BaseDatos.GetBaseDatos().SaveChanges();

                                        limpiar();
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
                    txtPaciente.Visibility = Visibility.Visible;
                    buttonRegistrarPaciente.Visibility = Visibility.Visible;



                }
                if (autoPacienteC.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un Paciente");
                }
                else
                {
                    if (autoMedico.SelectedItem == null)
                    {
                        MessageBox.Show("Selecciona un Medico");
                    }
                    else
                    {
                        if (txtdiagnostico.Text == "")
                        {
                            MessageBox.Show("Selecciona un Diagnostico");
                        }
                        else
                        {
                            if (txtdescripcion.Text == "")
                            {
                                MessageBox.Show("Inserta una Descripcion");
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
                                        MessageBox.Show("Inserta el Costo de la Consulta");
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

        void limpiartodo()
        {
            autoMedico.SearchText = String.Empty;
            autoPacienteC.SearchText = String.Empty;
            txtdiagnostico.Text = String.Empty;
            txtdescripcion.Text = String.Empty;
            txtmedicamento.Text = String.Empty;
            txtcostoconsulta.Text = String.Empty;

        }
        void limpiar()
        {

            txtPaciente.Text = String.Empty;
            autoMedico.SearchText = String.Empty;
            txtdiagnostico.Text = String.Empty;
            txtdescripcion.Text = String.Empty;
            txtmedicamento.Text = String.Empty;
            txtcostoconsulta.Text = String.Empty;
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
                txtPaciente.Visibility = Visibility.Visible;
                autoPacienteC.Visibility = Visibility.Hidden;
            }
        }

        private void checkBoxConsulta_Unchecked(object sender, RoutedEventArgs e)
        {
            if (checkBoxConsulta.IsChecked == false)
            {
                txtPaciente.Visibility = Visibility.Hidden;
                autoPacienteC.Visibility = Visibility.Visible;
            }

        }

        private void buttonRegistrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();

            //IngresoPaciente obj = new IngresoPaciente(autoPacienteC);
            //obj.Show();



        }

    }
}
