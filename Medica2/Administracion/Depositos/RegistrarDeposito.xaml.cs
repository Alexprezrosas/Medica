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

namespace Medica2.Administracion.Depositos
{
    /// <summary>
    /// Lógica de interacción para RegistrarDeposito.xaml
    /// </summary>
    public partial class RegistrarDeposito : Window
    {
        public RegistrarDeposito()
        {
            InitializeComponent();
            vistaPaciente();
        }

        void vistaPaciente()
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
                                            CUENTAA = cuenta.TOTAL,
                                            ID_CUENTA = cuenta.ID_CUENTA
                                        }).ToList();
        }

        void Limpiar()
        {
            autoPaciente.SearchText = String.Empty;
            txtMonto.Text = String.Empty;
            txtConcepto.Text = String.Empty;
        }

        void Guardar()
        {
            if (autoPaciente.SelectedItem == null)
            {
                MessageBox.Show("Selecciona a un paciente");
            }else
            {
                if (txtMonto.Text == "")
                {
                    MessageBox.Show("Ingresa el monto");
                }else
                {
                    if (txtConcepto.Text == "")
                    {
                        MessageBox.Show("Ingresa el concepto");
                    }else
                    {
                        dynamic paciente = autoPaciente.SelectedItem;
                        int idc = paciente.ID_CUENTA;
                        var cue = BaseDatos.GetBaseDatos().CUENTAS.Find(idc);

                        if (Decimal.Parse(txtMonto.Text) <= cue.SALDO)
                        {
                            DEPOSITO d = new DEPOSITO
                            {
                                MONTO = Decimal.Parse(txtMonto.Text),
                                CONCEPTO = txtConcepto.Text,
                                USUARIOID = 2,
                                CUENTAID = idc
                            };

                            BaseDatos.GetBaseDatos().DEPOSITOS.Add(d);
                            BaseDatos.GetBaseDatos().SaveChanges();


                            cue.SALDO = ((cue.SALDO) - (Decimal.Parse(txtMonto.Text)));
                            BaseDatos.GetBaseDatos().SaveChanges();
                            MessageBox.Show("Registro exitoso");
                            Limpiar();
                        }else
                        {
                            MessageBox.Show("El monto no pede ser mayor al saldo, Saldo: "+ cue.SALDO);
                        }
                    }
                }
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

        private void validarDecimal(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57 || ascci == 46)

                e.Handled = false;

            else e.Handled = true;
            ///

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
