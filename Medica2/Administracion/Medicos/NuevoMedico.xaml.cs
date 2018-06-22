using AccessoDB;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Medica2.Administracion.Medicos
{
    /// <summary>
    /// Lógica de interacción para NuevoMedico.xaml
    /// </summary>
    public partial class NuevoMedico : Window
    {
        int idmed;
        int idusu;
        public NuevoMedico()
        {
            InitializeComponent();
            FillEstados();

        }

        public NuevoMedico(Medico m, USUARIO usua, bool save)
        {
            InitializeComponent();
            FillEstados();

            idmed = m.ID_MEDICO;
            idusu = usua.ID_USUARIO;


            txtNombre.Text = m.PERSONA.NOMBRE;
            txtPaterno.Text = m.PERSONA.A_PATERNO;
            txtMaterno.Text = m.PERSONA.A_MATERNO;
            dpFecha_Nacimiento.SelectedDate = m.PERSONA.F_NACIMIENTO;
            cbbSexo.Text = m.PERSONA.SEXO;
            txtCalle.Text = m.PERSONA.CALLE;
            int idestado = comboBoxEstado.Items.IndexOf(m.PERSONA.ESTADO1);
            txtmunicipio.Text=m.PERSONA.NOMMUNICIPIO;
            txtlocalidad.Text = m.PERSONA.NOMLOCALIDAD;
            comboBoxEstado.SelectedIndex = idestado;
            txtCelular.Text = m.PERSONA.T_CELULAR;
            txtCurp.Text = m.PERSONA.CURP;

            txtTconsultorio.Text = m.T_CONSULTORIO;
            txtTparticular.Text = m.T_PARTICULAR;
            txtCorreo.Text = m.CORREO;
            txtCedulap.Text = m.C_PROFESIONAL;
            psContrasena.Password = usua.CONTRASENA;


            btnEditar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Hidden;
            btnGuardar.IsEnabled = false;
            btnEditar.IsEnabled = true;
           
        }

        public void GuardarMedico()
        {
            //Es para comprobar que no esten vacias las cajas de texto
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Inserta un Nombre");

            }
            else
            {
                if (txtPaterno.Text == "")
                {
                    MessageBox.Show("Inserta apellido Paterno");
                }

                else
                {
                    if (txtMaterno.Text == "")
                    {
                        MessageBox.Show("Inserta apellido Materno");
                    }
                    else
                    {//
                        if (cbbSexo.Text == "")
                        {
                            MessageBox.Show("Inserta el sexo");
                        }
                        else
                        {
                            if (txtCalle.Text == "")
                            {
                                MessageBox.Show("Inserta la calle");
                            }
                            else
                            {
                                if (comboBoxEstado.Text == "")
                                {
                                    MessageBox.Show("Inserta un Estado");
                                }
                                else
                                {
                                    if (txtmunicipio.Text == "")
                                    {
                                        MessageBox.Show("Inserta un Municipio");

                                    }
                                    else
                                    {
                                        if (txtlocalidad.Text == "")
                                        {
                                            MessageBox.Show("Inserta una Localidad");

                                        }
                                        else
                                        {
                                            if (txtCelular.Text == "")
                                            {
                                                MessageBox.Show("Inserta el numero Celular");
                                            }
                                            else
                                            {
                                                if (txtCurp.Text == "")
                                                {
                                                    MessageBox.Show("Inserta la CURP");
                                                }
                                                else
                                                {
                                                    if (txtTconsultorio.Text == "")
                                                    {
                                                        MessageBox.Show("inserta el telefpno consultorio");
                                                    }
                                                    else
                                                    {
                                                        if (txtTparticular.Text == "")
                                                        {
                                                            MessageBox.Show("Inserta el telefono Particular");
                                                        }
                                                        else
                                                            if (txtCorreo.Text == "")
                                                        {
                                                            MessageBox.Show("Inserta el Correo");

                                                        }
                                                        else
                                                        {
                                                            if (txtCedulap.Text == "")
                                                            {
                                                                MessageBox.Show("Inserta la Cedula Profesional");

                                                            }
                                                            else
                                                            {
                                                                if (psContrasena.Password == "")
                                                                    {
                                                                        MessageBox.Show("Ingresa una contraseña");
                                                                    }else
                                                                    {
                                                                        if (!ConsultaCedula(txtCedulap.Text))
                                                                        {
                                                                            

                                                                            //Obtener los valores de los TextBox


                                                                            DateTime FechaRegistro = DateTime.Now;


                                                                            PERSONA cmed = new PERSONA
                                                                            {
                                                                                NOMBRE = txtNombre.Text,
                                                                                A_PATERNO = txtPaterno.Text,
                                                                                A_MATERNO = txtMaterno.Text,
                                                                                F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate,
                                                                                SEXO = cbbSexo.Text,
                                                                                CALLE = txtCalle.Text,
                                                                                ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                                                NOMMUNICIPIO = txtmunicipio.Text,
                                                                                NOMLOCALIDAD = txtlocalidad.Text,
                                                                                T_CELULAR = txtCelular.Text,
                                                                                CURP = txtCurp.Text,
                                                                                FECHA_CREACION = FechaRegistro,
                                                                                ESTADOPERSONA = "Activo"
                                                                            };
                                                                            BaseDatos.GetBaseDatos().PERSONAS.Add(cmed);
                                                                            BaseDatos.GetBaseDatos().SaveChanges();

                                                                            Medico med = new Medico
                                                                            {
                                                                                PERSONAID = cmed.ID_PERSONA,
                                                                                T_CONSULTORIO = txtTconsultorio.Text,
                                                                                T_PARTICULAR = txtTparticular.Text,
                                                                                CORREO = txtCorreo.Text,
                                                                                C_PROFESIONAL = txtCedulap.Text,
                                                                                FECHA_CREACION = FechaRegistro
                                                                            };
                                                                            med.PERSONA = cmed;
                                                                            BaseDatos.GetBaseDatos().MEDICOS.Add(med);
                                                                            BaseDatos.GetBaseDatos().SaveChanges();

                                                                            EMPLEADO em = new EMPLEADO
                                                                            {
                                                                                PERSONAID = cmed.ID_PERSONA,
                                                                                PUESTO = "Medico",
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

                                                                            //Limpiar los textBox
                                                                            LimpiarMedicos();
                                                                        }
                                                                        else
                                                                        {
                                                                            MessageBox.Show("EL registro del medico ya Existe");
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


            }
        }

        public void EditarMedico()
        {
            //Es para comprobar que no esten vacias las cajas de texto
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Inserta un Nombre");

            }
            else
            {
                if (txtPaterno.Text == "")
                {
                    MessageBox.Show("Inserta apellido Paterno");
                }

                else
                {
                    if (txtMaterno.Text == "")
                    {
                        MessageBox.Show("Inserta apellido Materno");
                    }
                    else
                    {//
                        if (cbbSexo.Text == "")
                        {
                            MessageBox.Show("Inserta el sexo");
                        }
                        else
                        {
                            if (txtCalle.Text == "")
                            {
                                MessageBox.Show("Inserta la calle");
                            }
                            else
                            {
                                if (comboBoxEstado.Text == "")
                                {
                                    MessageBox.Show("Inserta un Estado");
                                }
                                else
                                {
                                    if (txtmunicipio.Text == "")
                                    {
                                        MessageBox.Show("Inserta un Municipio");

                                    }
                                    else
                                    {
                                        if (txtlocalidad.Text == "")
                                        {
                                            MessageBox.Show("Inserta una Localidad");

                                        }
                                        else
                                        {
                                            if (txtCelular.Text == "")
                                            {
                                                MessageBox.Show("Inserta el numero Celular");
                                            }
                                            else
                                            {
                                                if (txtCurp.Text == "")
                                                {
                                                    MessageBox.Show("Inserta la CURP");
                                                }
                                                else
                                                {
                                                    if (txtTconsultorio.Text == "")
                                                    {
                                                        MessageBox.Show("inserta el telefpno consultorio");
                                                    }
                                                    else
                                                    {
                                                        if (txtTparticular.Text == "")
                                                        {
                                                            MessageBox.Show("Inserta el telefono Particular");
                                                        }
                                                        else
                                                            if (txtCorreo.Text == "")
                                                        {
                                                            MessageBox.Show("Inserta el Correo");

                                                        }
                                                        else
                                                        {
                                                            if (txtCedulap.Text == "")
                                                            {
                                                                MessageBox.Show("Inserta la Cedula Profesional");

                                                            }else
                                                            {
                                                                if (psContrasena.Password == "")
                                                                {
                                                                    MessageBox.Show("Ingresas la contraseña del medico");
                                                                }
                                                                else
                                                                {
                                                                    
                                                                        DateTime FechaModificacion = DateTime.Now;
                                                                        var emedico = BaseDatos.GetBaseDatos().MEDICOS.Find(idmed);

                                                                        emedico.PERSONA.NOMBRE = txtNombre.Text;
                                                                        emedico.PERSONA.A_PATERNO = txtPaterno.Text;
                                                                        emedico.PERSONA.A_MATERNO = txtMaterno.Text;
                                                                        emedico.PERSONA.F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate;
                                                                        emedico.PERSONA.SEXO = cbbSexo.Text;
                                                                        emedico.PERSONA.CALLE = txtCalle.Text;
                                                                        emedico.PERSONA.ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue);
                                                                        emedico.PERSONA.NOMMUNICIPIO = txtmunicipio.Text;
                                                                        emedico.PERSONA.NOMLOCALIDAD = txtlocalidad.Text;
                                                                        emedico.PERSONA.T_CELULAR = txtCelular.Text;
                                                                        emedico.PERSONA.CURP = txtCurp.Text;
                                                                        emedico.PERSONA.FECHA_CREACION = FechaModificacion;


                                                                        emedico.T_CONSULTORIO = txtTconsultorio.Text;
                                                                        emedico.T_PARTICULAR = txtTparticular.Text;
                                                                        emedico.CORREO = txtCorreo.Text;
                                                                        emedico.C_PROFESIONAL = txtCedulap.Text;
                                                                        BaseDatos.GetBaseDatos().SaveChanges();


                                                                        var usu = BaseDatos.GetBaseDatos().USUARIOS.Find(idusu);
                                                                        usu.CONTRASENA = psContrasena.Password;
                                                                        BaseDatos.GetBaseDatos().SaveChanges();
                                                                        MessageBox.Show("Se Edito Correctamente el medico");

                                                                        LimpiarMedicos();
                                                                        this.Close();
                                                                        MostrarMedicos obj = new MostrarMedicos();
                                                                        obj.Show();

                                                                        //Limpiar los textBox
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
        }

        private void LimpiarMedicos()
        {
            txtNombre.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            cbbSexo.Text = "";
            txtCalle.Text = "";
            dpFecha_Nacimiento.Text = "";
            comboBoxEstado.Text = "";
            txtmunicipio.Text = "";
            txtlocalidad.Text = "";
            txtCelular.Text = "";
            txtCurp.Text = "";


            txtTconsultorio.Text = "";
            txtTparticular.Text = "";
            txtCorreo.Text = "";
            txtCedulap.Text = "";
            psContrasena.Password = String.Empty;

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
        //inicio Validacion
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

        private void validarNumLetras(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 31 || ascci == 46 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }//fin Validacion

        public bool ConsultaCedula(String cedulita)
        {
           var cedumd = (from Medicocp in BaseDatos.GetBaseDatos().MEDICOS
                         where Medicocp.C_PROFESIONAL == cedulita
                         select Medicocp).Count();
            if (cedumd == 0)
                return false;
            else
                return true;

        }

        public void FillEstados()
        {

            List<ESTADO> lst = BaseDatos.GetBaseDatos().ESTADOS.ToList();
            comboBoxEstado.ItemsSource = lst;
        }       
        //activa el evento de Guardar Manda atraer el metodo y realiza las acciones progradas 
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            GuardarMedico();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditarMedico(object sender, RoutedEventArgs e)
        {
            EditarMedico();
        }
    }
}
