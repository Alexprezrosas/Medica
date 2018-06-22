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
using Telerik.Windows.Controls;

namespace Medica2.Administracion.Empleados
{
    /// <summary>
    /// Lógica de interacción para RegistroEmpleados.xaml
    /// </summary>
    public partial class RegistroEmpleados : Window
    {
        private RadAutoCompleteBox autoempleado;

        public RegistroEmpleados()
        {
            InitializeComponent();

            FillEstados();
        }

        public RegistroEmpleados(RadAutoCompleteBox autoempleado)
        {

            InitializeComponent();
            FillEstados();
            this.autoempleado = autoempleado;
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

        private void txtNombre_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
                e.Handled = false;
            else if (e.Key == Key.Decimal)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void validarNumLetras(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 46)

                e.Handled = false;

            else e.Handled = true;
            ///

        }

        private void dpFecha_Nacimiento_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? date = picker.SelectedDate;

            if (date == null)
            {
                this.Title = "No se ha seleccionado una fecha";
            }
        }
        public void FillEstados()
        {

            List<ESTADO> lst = BaseDatos.GetBaseDatos().ESTADOS.ToList();
            comboBoxEstado.ItemsSource = lst;
        }

        void Limpiar()
        {
            txtNombre.Text = String.Empty;
            txtPaterno.Text = String.Empty;
            txtMaterno.Text = String.Empty;
            txtCalle.Text = String.Empty;
            txtCurp.Text = String.Empty;
            cbbSexo.SelectedIndex = -1;
            comboBoxEstado.SelectedIndex = -1;
            txtCelular.Text = String.Empty;
            txtpuesto.Text = String.Empty;
            dpFecha_Nacimiento.Text = String.Empty;
        }
        void Guradar()
        {
            if (txtNombre.Text == String.Empty)
            {
                MessageBox.Show("Ingresa el nombre del Empleado");
            }
            else
            {
                if (txtPaterno.Text == String.Empty && txtMaterno.Text == String.Empty)
                {
                    MessageBox.Show("Ingresa los apellidos del Empleado");
                }
                else
                {
                    if (dpFecha_Nacimiento.SelectedDate == null)
                    {
                        MessageBox.Show("Selecciona la fecha de nacimiento del Empleado");
                    }
                    else
                    {
                        if (cbbSexo.Text == "")
                        {
                            MessageBox.Show("Selecciona el sexo");
                        }
                        else
                        {
                            if (txtCalle.Text == "")
                            {
                                MessageBox.Show("Ingresa la calle");
                            }
                            else
                            {
                                if (comboBoxEstado.Text == "")
                                {
                                    MessageBox.Show("Selecciona un estado");
                                }
                                else
                                {
                                    if (txtMaterno.Text == "")
                                    {
                                        MessageBox.Show("Selecciona un municipio");
                                    }
                                    else
                                    {
                                        if (txtNombre.Text == "")
                                        {
                                            MessageBox.Show("Selecciona una localidad");
                                        }
                                        else
                                        {
                                            if (txtCurp.Text == "" && txtCurp.Text.Length < 19)
                                            {
                                                MessageBox.Show("Ingresa una CURP valida");
                                            }
                                            else
                                            {
                                                if (txtCelular.Text == "")
                                                {
                                                    MessageBox.Show("Ingresa el numero Celular");
                                                }
                                                else
                                                {
                                                    if (txtpuesto.Text == "")
                                                    {
                                                        MessageBox.Show("ingresa ell puesto");
                                                    }
                                                    else
                                                    {
                                                        DateTime fregistro = DateTime.Now;

                                                        PERSONA person = new PERSONA
                                                        {
                                                            NOMBRE = txtNombre.Text,
                                                            A_PATERNO = txtPaterno.Text,
                                                            A_MATERNO = txtMaterno.Text,
                                                            F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate,
                                                            SEXO = cbbSexo.Text,
                                                            CALLE = txtCalle.Text,
                                                            ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                            CURP = txtCurp.Text,

                                                            T_CELULAR = txtCelular.Text,

                                                            FECHA_CREACION = fregistro
                                                        };

                                                        BaseDatos.GetBaseDatos().PERSONAS.Add(person);
                                                        BaseDatos.GetBaseDatos().SaveChanges();

                                                        EMPLEADO emple = new EMPLEADO
                                                        {
                                                            PERSONAID = person.ID_PERSONA,
                                                            PUESTO = txtpuesto.Text,
                                                            FECHA_CREACION = fregistro
                                                        };
                                                        BaseDatos.GetBaseDatos().EMPLEADOS.Add(emple);
                                                        BaseDatos.GetBaseDatos().SaveChanges();

                                                        autoempleado.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                                                                    join e in BaseDatos.GetBaseDatos().EMPLEADOS
                                                                                    on PERSONA.ID_PERSONA equals e.PERSONAID
                                                                                    select new
                                                                                    {
                                                                                        ID_PERSONA = PERSONA.ID_PERSONA,
                                                                                        NOMBRE = PERSONA.NOMBRE,
                                                                                    }).ToList();

                                                        Limpiar();
                                                        this.Close();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guradar();
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
