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

namespace Medica2.Administracion.Enfermeras
{
    /// <summary>
    /// Lógica de interacción para NuevaEnfermera.xaml
    /// </summary>
    public partial class NuevaEnfermera : Window
    {
        int idenf;
        int idusu;
        
        public NuevaEnfermera()
        {
            InitializeComponent();
            
            FillEstados();
           
        }
        public NuevaEnfermera(ENFERMERA enfe,USUARIO usu, bool save)
        {
            InitializeComponent();

            FillEstados();
            idenf = enfe.ID_ENFERMERA;
            idusu = usu.ID_USUARIO;

            txtNombre.Text = enfe.PERSONA.NOMBRE;
            txtPaterno.Text = enfe.PERSONA.A_PATERNO;
            txtMaterno.Text = enfe.PERSONA.A_MATERNO;
            cbbSexo.Text = enfe.PERSONA.SEXO;
            txtCalle.Text = enfe.PERSONA.CALLE;
            dpFecha_Nacimiento.SelectedDate = enfe.PERSONA.F_NACIMIENTO;
            int idestado = comboBoxEstado.Items.IndexOf(enfe.PERSONA.ESTADO1);
            comboBoxEstado.SelectedIndex = idestado;
            comboBoxEstado.SelectedValue = enfe.PERSONA.ESTADO;
            txtMunicipio.Text = enfe.PERSONA.NOMMUNICIPIO;
            txtLocalidad.Text = enfe.PERSONA.NOMLOCALIDAD;
            txtCelular.Text = enfe.PERSONA.T_CELULAR;
            txtCurp.Text = enfe.PERSONA.CURP;
            txtCProfesional.Text = enfe.C_PROFESIONAL;
            psContrasena.Password = usu.CONTRASENA;

            btnEditar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Hidden;
            btnGuardar.IsEnabled = false;
            btnEditar.IsEnabled = true;
        }
        

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void limpiarEnfermera()
        {
            txtNombre.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            dpFecha_Nacimiento.Text = "";
            cbbSexo.Text = "";
            txtCalle.Text = "";
            comboBoxEstado.Text = "";
            txtLocalidad.Text = "";
            txtMunicipio.Text = "";
            txtCelular.Text = "";
            txtCurp.Text = "";
            txtCProfesional.Text = "";
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

        private void guardarEnfermera()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Insertar un nombre");
            }else
            {
                if (txtPaterno.Text == "")
                {
                    MessageBox.Show("Insertar un apellido paterno");
                }else
                {
                    if (txtMaterno.Text == "")
                    {
                        MessageBox.Show("Insertar un apellido materno");
                    }else
                    {
                        if (dpFecha_Nacimiento.Text == "")
                        {
                            MessageBox.Show("Insertar una fecha de nacimiento");
                        }else
                        {
                            if (cbbSexo.Text == "")
                            {
                                MessageBox.Show("Seleccionar un sexo");
                            }
                            else
                            {
                                if (txtCalle.Text == "")
                                {
                                    MessageBox.Show("Insertar una calle");
                                }else
                                {
                                    if (comboBoxEstado.Text == "")
                                    {
                                        MessageBox.Show("Seleccionar un mstado");
                                    }else
                                    {
                                        if (txtMunicipio.Text == "")
                                        {
                                            MessageBox.Show("Seleccionar un municipio");
                                        }else
                                        {
                                            if (txtLocalidad.Text == "")
                                            {
                                                MessageBox.Show("Seleccionar una localidad");
                                            }else
                                            {
                                                if (txtCelular.Text == "")
                                                {
                                                    MessageBox.Show("Insertar un celular");
                                                }else
                                                {
                                                    if (txtCurp.Text == "")
                                                    {
                                                        MessageBox.Show("Insertar una curp");
                                                    }else
                                                    {
                                                        if (txtCProfesional.Text == "")
                                                        {
                                                            MessageBox.Show("Insertar una cedula profesional");
                                                        }else
                                                        {
                                                            if (psContrasena.Password=="")
                                                            {
                                                                MessageBox.Show("Ingresa una Contrase");
                                                            }
                                                            else
                                                            {
                                                                if (!ConsultaCedulaE(txtCProfesional.Text))
                                                                {
                                                                    
                                                                    //Obtener los valores de los TextBox
                                                                    DateTime Fecharegistro = DateTime.Now;
                                                                   
                                                                    PERSONA cc = new PERSONA
                                                                    {
                                                                        NOMBRE = txtNombre.Text,
                                                                        A_PATERNO = txtPaterno.Text,
                                                                        A_MATERNO = txtMaterno.Text,
                                                                        //EDAD = ed,
                                                                        SEXO = cbbSexo.Text,
                                                                        CALLE = txtCalle.Text,
                                                                        NOMMUNICIPIO = txtMunicipio.Text,
                                                                        NOMLOCALIDAD = txtLocalidad.Text,
                                                                        ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                                        F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate,
                                                                        T_CELULAR = txtCelular.Text,
                                                                        CURP = txtCurp.Text,
                                                                        FECHA_CREACION = Fecharegistro,
                                                                        ESTADOPERSONA = "Activo"
                                                                    };
                                                                    BaseDatos.GetBaseDatos().PERSONAS.Add(cc);
                                                                    BaseDatos.GetBaseDatos().SaveChanges();
                                                                    //cc = pr.PERSONAS.Last();

                                                                    ENFERMERA enfermera = new ENFERMERA
                                                                    {
                                                                        PERSONAID = cc.ID_PERSONA,
                                                                        C_PROFESIONAL = txtCProfesional.Text,
                                                                        FECHA_CREACION = Fecharegistro
                                                                    };
                                                                    enfermera.PERSONA = cc;
                                                                    BaseDatos.GetBaseDatos().ENFERMERAS.Add(enfermera);
                                                                    BaseDatos.GetBaseDatos().SaveChanges();

                                                                    EMPLEADO em = new EMPLEADO
                                                                    {
                                                                        PERSONAID = cc.ID_PERSONA,
                                                                        PUESTO = "Enfermera",
                                                                        FECHA_CREACION = Fecharegistro
                                                                    };

                                                                    BaseDatos.GetBaseDatos().EMPLEADOS.Add(em);
                                                                    BaseDatos.GetBaseDatos().SaveChanges();

                                                                    USUARIO us = new USUARIO
                                                                    {
                                                                        EMPLEADOID = em.ID_EMPLEADO,
                                                                        CONTRASENA = psContrasena.Password,
                                                                        FECHA_CREACION = Fecharegistro,
                                                                        PERMISOSID = 1
                                                                    };

                                                                    BaseDatos.GetBaseDatos().USUARIOS.Add(us);
                                                                    BaseDatos.GetBaseDatos().SaveChanges();
                                                                    //Mensaje
                                                                    MessageBoxResult result = MessageBox.Show("Registro exitoso");                                                                    
                                                                    limpiarEnfermera();
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("El registro de la Enfermera ya existe");
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

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            guardarEnfermera();
        }

        public bool ConsultaCedulaE(String cedulita)
        {
            var cedumd = (from Enfecp in BaseDatos.GetBaseDatos().ENFERMERAS
                          where Enfecp.C_PROFESIONAL == cedulita
                          select Enfecp).Count();
            if (cedumd == 0)
                return false;
            else
                return true;

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
                                    if (txtMunicipio.Text == "")
                                    {
                                        MessageBox.Show("Inserta un Municipio");

                                    }
                                    else
                                    {
                                        if (txtLocalidad.Text == "")
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

                                                    if (txtCProfesional.Text == "")
                                                    {
                                                        MessageBox.Show("Inserta la cedula profesional");
                                                    }
                                                    else
                                                    {
                                                        
                                                            DateTime FechaModificacion = DateTime.Now;
                                                            var enfe = BaseDatos.GetBaseDatos().ENFERMERAS.Find(idenf);

                                                            enfe.PERSONA.NOMBRE = txtNombre.Text;
                                                            enfe.PERSONA.A_PATERNO = txtPaterno.Text;
                                                            enfe.PERSONA.A_MATERNO = txtMaterno.Text;
                                                            enfe.PERSONA.F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate;
                                                            enfe.PERSONA.SEXO = cbbSexo.Text;
                                                            enfe.PERSONA.CALLE = txtCalle.Text;
                                                            enfe.PERSONA.ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue);
                                                            enfe.PERSONA.NOMMUNICIPIO = txtMunicipio.Text;
                                                            enfe.PERSONA.NOMLOCALIDAD = txtLocalidad.Text;
                                                            enfe.PERSONA.T_CELULAR = txtCelular.Text;
                                                            enfe.PERSONA.CURP = txtCurp.Text;
                                                            enfe.C_PROFESIONAL = txtCProfesional.Text;

                                                            var usu = BaseDatos.GetBaseDatos().USUARIOS.Find(idenf);
                                                            usu.CONTRASENA = psContrasena.Password;

                                                            BaseDatos.GetBaseDatos().SaveChanges();
                                                            MessageBox.Show("Se Edito Correctamente la enfermera");
                                                            limpiarEnfermera();

                                                            limpiarEnfermera();
                                                            this.Close();
                                                            ConsultaEnfermera obj = new ConsultaEnfermera();
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

                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //CargarSiloeBD.getDB().SaveChanges();
        }
        public void FillEstados()
        {
            
            List<ESTADO> lst = BaseDatos.GetBaseDatos().ESTADOS.ToList();
            comboBoxEstado.ItemsSource = lst;
        }
        ///////
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

            if (ascci >= 4 && ascci <= 57) e.Handled = false;

            else e.Handled = true;

        }

        private void validarNumLetras( object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 46)

                e.Handled = false;

            else e.Handled = true;
            ///
            
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarMedico();
        }
        ///////



    }
}
