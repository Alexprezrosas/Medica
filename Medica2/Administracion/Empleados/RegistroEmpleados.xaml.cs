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
        DateTime FechaRegistro = DateTime.Now;
        int idemple;
        int idusu;

        public RegistroEmpleados()
        {
            InitializeComponent();

            FillEstados();
        }
        public RegistroEmpleados(EMPLEADO empl, USUARIO usu, bool save)
        {

            idemple = empl.ID_EMPLEADO;
            idusu = usu.ID_USUARIO;

            InitializeComponent();
            FillEstados();
            txtNombre.Text = empl.PERSONA.NOMBRE;
            txtPaterno.Text = empl.PERSONA.A_PATERNO;
            txtMaterno.Text = empl.PERSONA.A_MATERNO;
            dpFecha_Nacimiento.SelectedDate = empl.PERSONA.F_NACIMIENTO;
            cbbSexo.Text = empl.PERSONA.SEXO;
            txtCalle.Text = empl.PERSONA.CALLE;
            int idestado = comboBoxEstado.Items.IndexOf(empl.PERSONA.ESTADO1);
            txtMunicipio.Text = empl.PERSONA.NOMMUNICIPIO;
            txtLocalidad.Text = empl.PERSONA.NOMLOCALIDAD;
            comboBoxEstado.SelectedIndex = idestado;
            txtCelular.Text = empl.PERSONA.T_CELULAR;
            txtCurp.Text = empl.PERSONA.CURP;
            cbbpuestos.Text = usu.EMPLEADO.PUESTO;
            psContrasena.Password = usu.CONTRASENA;
            cbbActivoInactivo.Text = empl.PERSONA.ESTADOPERSONA;

            lblActivo.Visibility = Visibility.Visible;
            cbbActivoInactivo.Visibility = Visibility.Visible;
            btnEditar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Hidden;
            btnGuardar.IsEnabled = false;
            btnEditar.IsEnabled = true;

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
            cbbSexo.Text = "";
            comboBoxEstado.Text = "";
            txtMunicipio.Text = String.Empty;
            txtLocalidad.Text = String.Empty;
            txtCelular.Text = String.Empty;
            cbbpuestos.Text = String.Empty;
            dpFecha_Nacimiento.Text = String.Empty;
            cbbpuestos.Text = String.Empty;
            psContrasena.Password = String.Empty;
            cbbActivoInactivo.Text = "";
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
                                    if (txtMunicipio.Text == "")
                                    {
                                        MessageBox.Show("Selecciona un municipio");
                                    }
                                    else
                                    {
                                        if (txtLocalidad.Text == "")
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
                                                    if (cbbpuestos.Text == "")
                                                    {
                                                        MessageBox.Show("ingresa un puesto");
                                                    }
                                                    else
                                                    {
                                                        if (psContrasena.Password == "")
                                                        {
                                                            MessageBox.Show("Ingresa una Contraseña");
                                                        }
                                                        else
                                                        {
                                                            PERSONA person = new PERSONA
                                                            {
                                                                NOMBRE = txtNombre.Text,
                                                                A_PATERNO = txtPaterno.Text,
                                                                A_MATERNO = txtMaterno.Text,
                                                                F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate,
                                                                SEXO = cbbSexo.Text,
                                                                CALLE = txtCalle.Text,
                                                                ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                                NOMMUNICIPIO = txtMunicipio.Text,
                                                                NOMLOCALIDAD = txtLocalidad.Text,
                                                                CURP = txtCurp.Text,
                                                                T_CELULAR = txtCelular.Text,
                                                                ESTADOPERSONA = "Activo",
                                                                FECHA_CREACION = FechaRegistro
                                                            };
                                                            BaseDatos.GetBaseDatos().PERSONAS.Add(person);
                                                            BaseDatos.GetBaseDatos().SaveChanges();

                                                            EMPLEADO em = new EMPLEADO
                                                            {
                                                                PERSONAID = person.ID_PERSONA,
                                                                PUESTO = cbbpuestos.Text,
                                                                FECHA_CREACION = FechaRegistro
                                                            };

                                                            BaseDatos.GetBaseDatos().EMPLEADOS.Add(em);
                                                            BaseDatos.GetBaseDatos().SaveChanges();

                                                            USUARIO us = new USUARIO
                                                            {
                                                                EMPLEADOID = em.ID_EMPLEADO,
                                                                CONTRASENA = psContrasena.Password,
                                                                FECHA_CREACION = FechaRegistro,
                                                                PERMISOSID = 1
                                                            };

                                                            BaseDatos.GetBaseDatos().USUARIOS.Add(us);
                                                            BaseDatos.GetBaseDatos().SaveChanges();
                                                            //Mensaje
                                                            MessageBoxResult result = MessageBox.Show("Registro exitoso");

                                                            //autoempleado.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                                            //                            join e in BaseDatos.GetBaseDatos().EMPLEADOS
                                                            //                            on PERSONA.ID_PERSONA equals e.PERSONAID
                                                            //                            select new
                                                            //                            {
                                                            //                                ID_PERSONA = PERSONA.ID_PERSONA,
                                                            //                                NOMBRE = PERSONA.NOMBRE,
                                                            //                            }).ToList();

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
        }

        void Editar()
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
                                    if (txtMunicipio.Text == "")
                                    {
                                        MessageBox.Show("Selecciona un municipio");
                                    }
                                    else
                                    {
                                        if (txtLocalidad.Text == "")
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
                                                    if (cbbpuestos.Text == "")
                                                    {
                                                        MessageBox.Show("ingresa un puesto");
                                                    }
                                                    else
                                                    {
                                                        if (psContrasena.Password == "")
                                                        {
                                                            MessageBox.Show("Ingresa una Contraseña");
                                                        }
                                                        else
                                                        {
                                                            if (cbbActivoInactivo.Text == "")
                                                            {
                                                                MessageBox.Show("Selecciona el estatus de la persona \n Activo o Inactivo");
                                                            }
                                                            else
                                                            {
                                                                DateTime FechaModificacion = DateTime.Now;
                                                                var emplea = BaseDatos.GetBaseDatos().EMPLEADOS.Find(idemple);

                                                                emplea.PERSONA.NOMBRE = txtNombre.Text;
                                                                emplea.PERSONA.A_PATERNO = txtPaterno.Text;
                                                                emplea.PERSONA.A_MATERNO = txtMaterno.Text;
                                                                emplea.PERSONA.F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate;
                                                                emplea.PERSONA.SEXO = cbbSexo.Text;
                                                                emplea.PERSONA.CALLE = txtCalle.Text;
                                                                emplea.PERSONA.ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue);
                                                                emplea.PERSONA.NOMMUNICIPIO = txtMunicipio.Text;
                                                                emplea.PERSONA.NOMLOCALIDAD = txtLocalidad.Text;
                                                                emplea.PERSONA.T_CELULAR = txtCelular.Text;
                                                                emplea.PERSONA.CURP = txtCurp.Text;
                                                                emplea.PERSONA.FECHA_CREACION = FechaModificacion;
                                                                emplea.PERSONA.ESTADOPERSONA = cbbActivoInactivo.Text;

                                                                emplea.PUESTO = cbbpuestos.Text;
                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                var usu = BaseDatos.GetBaseDatos().USUARIOS.Find(idusu);
                                                                usu.CONTRASENA = psContrasena.Password;

                                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                                MessageBox.Show("Se Edito Correctamente el Empleado");

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

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }
    }
}
