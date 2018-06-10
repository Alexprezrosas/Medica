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
        DateTime fr = DateTime.Now;
        public CargarCirugia()
        {
            InitializeComponent();
            llenarAutocompletes();
        }

        void llenarAutocompletes()
        {
            autoCirugia.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_CIRUGIAS.ToList();

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
            }else
            {
                if (autoMedico.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona al medico solicitante");
                }else
                {
                    if (autoCirugia.SelectedItem == null)
                    {
                        MessageBox.Show("Selecciona una cirugia");
                    }else
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
