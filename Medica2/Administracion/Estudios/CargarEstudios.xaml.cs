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

namespace Medica2.Administracion.Estudios
{
    /// <summary>
    /// Lógica de interacción para CargarEstudios.xaml
    /// </summary>
    public partial class CargarEstudios : Window
    {
        Decimal total;
        Decimal total1;
        int ides1;
        int ides2;
        int idcue;
        DateTime fr = DateTime.Now;
        List<CATALOGO_ESTUDIOS> listEstudio = new List<CATALOGO_ESTUDIOS>();
        public CargarEstudios()
        {
            InitializeComponent();
            llenarAutocompletes();
        }

        void llenarAutocompletes()
        {
            autoEstudio.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.ToList();

            autoMedico.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                        join e in BaseDatos.GetBaseDatos().MEDICOS
                                        on PERSONA.ID_PERSONA equals e.PERSONAID
                                        select new
                                        {
                                            ID_MEDICO = e.ID_MEDICO,
                                            NOMBRE = PERSONA.NOMBRE,
                                        }).ToList();

            autoPaciente.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
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

        void llenarVista()
        {
            rgvEstudios.ItemsSource = listEstudio.ToList();
        }

        void limpiar()
        {
            autoEstudio.SearchText = String.Empty;
            txtCosto.Text = String.Empty;
        }

        void limpiartodo()
        {
            autoEstudio.SearchText = String.Empty;
            txtCosto.Text = String.Empty;
            autoMedico.Visibility = Visibility.Hidden;
            autoPaciente.Visibility = Visibility.Hidden;
            txtMedico.Text = String.Empty;
            txtPaciente.Text = String.Empty;
            cbTipoMedico.IsChecked = false;
            listEstudio.Clear();
            llenarVista();
            txtTotal.Text = String.Empty;
        }

        void Guardar()
        {
            if (autoEstudio.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un estudio");
            }else
            {
                if (cbTipoMedico.IsChecked == true)
                {
                    txtMedico.Visibility = Visibility.Hidden;
                    txtPaciente.Visibility = Visibility.Hidden;
                    autoMedico.Visibility = Visibility.Visible;
                    autoPaciente.Visibility = Visibility.Visible;

                    if (autoMedico.SelectedItem == null)
                    {
                        MessageBox.Show("Selecciona un medico");
                    }else
                    {
                        if (autoPaciente.SelectedItem == null)
                        {
                            MessageBox.Show("Selecciona un paciente");
                        }else
                        {
                            int idestudio = ((CATALOGO_ESTUDIOS)autoEstudio.SelectedItem).CATALOGO_ESTUDIO_ID;
                            dynamic paciente = autoPaciente.SelectedItem;
                            dynamic medico = autoMedico.SelectedItem;
                            idcue = paciente.ID_CUENTA;
                            int idmed = medico.ID_MEDICO;
                            ESTUDIO es = new ESTUDIO
                            {
                                CATALOGO_ESTUDIOS_ID = idestudio,
                                USUARIOID = 2,
                                MEDICOID = idmed,
                                CUENTAID = idcue,
                                FECHA_CREACION = fr,
                                TOTAL = Decimal.Parse(txtCosto.Text)
                            };
                            BaseDatos.GetBaseDatos().ESTUDIOS.Add(es);
                            BaseDatos.GetBaseDatos().SaveChanges();
                            ides1 = es.ID_ESTUDIO;

                            total = total + (Decimal.Parse(txtCosto.Text));
                            txtTotal.Text = total.ToString();
                            var est = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(idestudio);
                            listEstudio.Add(est);
                            llenarVista();
                            limpiar();
                        }
                    }
                }else
                {
                    if (cbTipoMedico.IsChecked == false)
                    {
                        txtMedico.Visibility = Visibility.Visible;
                        txtPaciente.Visibility = Visibility.Visible;
                        autoMedico.Visibility = Visibility.Hidden;
                        autoPaciente.Visibility = Visibility.Hidden;
                        int idestudio = ((CATALOGO_ESTUDIOS)autoEstudio.SelectedItem).CATALOGO_ESTUDIO_ID;
                        ESTUDIO es = new ESTUDIO
                        {
                            CATALOGO_ESTUDIOS_ID = idestudio,
                            USUARIOID = 2,
                            MEDICO_SOLICITANTE = txtMedico.Text,
                            PACIENTE_SOLICITANTE = txtPaciente.Text,
                            FECHA_CREACION = fr,
                            TOTAL = Decimal.Parse(txtCosto.Text)
                        };
                        BaseDatos.GetBaseDatos().ESTUDIOS.Add(es);
                        BaseDatos.GetBaseDatos().SaveChanges();
                        ides2 = es.ID_ESTUDIO;

                        total1 = total1 + (Decimal.Parse(txtCosto.Text));
                        txtTotal.Text = total1.ToString();
                        var est = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(idestudio);
                        listEstudio.Add(est);
                        llenarVista();
                        limpiar();

                    }
                }
            }//
        }

        void llenarCosto()
        {
            if (autoEstudio.SelectedItem != null)
            {
                int idest = ((CATALOGO_ESTUDIOS)autoEstudio.SelectedItem).CATALOGO_ESTUDIO_ID;
                var busquedaest = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(idest);
                txtCosto.Text = busquedaest.COSTO.ToString();
                //

            }
        }

        private void btnAgregar_Copy_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            if (cbTipoMedico.IsChecked == true)
            {
                //var estudio = BaseDatos.GetBaseDatos().ESTUDIOS.Find(ides1);
                //estudio.TOTAL = estudio.TOTAL + total;
                //BaseDatos.GetBaseDatos().SaveChanges();

                var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcue);
                cuenta.TOTAL = cuenta.TOTAL + total;
                cuenta.SALDO = cuenta.SALDO + total;
                BaseDatos.GetBaseDatos().SaveChanges();
                MessageBox.Show("Se finalizo el proceso");
                limpiartodo();
            }
            else
            {
                //var estudio = BaseDatos.GetBaseDatos().ESTUDIOS.Find(ides2);
                //estudio.TOTAL = estudio.TOTAL + total1;
                //BaseDatos.GetBaseDatos().SaveChanges();
                MessageBox.Show("Se finalizo el proceso");
                limpiartodo();
            }
        }

        private void cbTipoMedico_Checked(object sender, RoutedEventArgs e)
        {
            if (cbTipoMedico.IsChecked == true)
            {
                txtMedico.Visibility = Visibility.Hidden;
                txtPaciente.Visibility = Visibility.Hidden;
                autoMedico.Visibility = Visibility.Visible;
                autoPaciente.Visibility = Visibility.Visible;
            }
        }

        private void cbTipoMedico_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbTipoMedico.IsChecked == false)
            {
                txtMedico.Visibility = Visibility.Visible;
                txtPaciente.Visibility = Visibility.Visible;
                autoMedico.Visibility = Visibility.Hidden;
                autoPaciente.Visibility = Visibility.Hidden;
            }
        }

        private void autoEstudio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            llenarCosto();
        }
    }
}
