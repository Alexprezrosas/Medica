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
using Telerik.WinControls.UI;

namespace Medica2.Administracion.Pacientes
{
    /// <summary>
    /// Lógica de interacción para IngresoPaciente.xaml
    /// </summary>
    public partial class IngresoPaciente : Window
    {
        int idf;
        int idp;
        int idccp;
        private RadAutoCompleteBox autoPacienteC;

        public IngresoPaciente()
        {
            InitializeComponent();
            FillEstados();
            llenarAutocmpletes();
            dpFecha_Nacimiento.DisplayDateEnd = DateTime.Now;
        }

        public IngresoPaciente(RadAutoCompleteBox autoPacienteC)
        {

            InitializeComponent();
            this.autoPacienteC = autoPacienteC;
            FillEstados();
            autoCuarto.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.ToList();


        }

        void llenarAutocmpletes()
        {
            autoCuarto.ItemsSource = (from cuarto in BaseDatos.GetBaseDatos().CATALOGO_CUARTOS
                                      where cuarto.ESTADO == "Libre"
                                      select new
                                      {
                                          ID_CATALOGO_CUARTO = cuarto.ID_CATALOGO_CUARTO,
                                          NOMBRE = cuarto.NOMBRE_CUARTO
                                      });
        }

        public IngresoPaciente(PACIENTE idpaciente, FAM_RESPONSABLES idfamiliar , bool save, int id_cuarto)
        {
            InitializeComponent();
            FillEstados();
            
            idccp = id_cuarto;
            
            var cc = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Find(id_cuarto);
            autoCuarto.SearchText = cc.NOMBRE_CUARTO;
            cc.PAC_ACTUALES = cc.PAC_ACTUALES - 1;
            BaseDatos.GetBaseDatos().SaveChanges();

            if (cc.PAC_ACTUALES <= cc.MAX_PACIENTES)
            {
                cc.ESTADO = "Libre";
                BaseDatos.GetBaseDatos().SaveChanges();
            }

            llenarAutocmpletes();

            if (idpaciente.TIPO_PACIENTE == "Hospitalizado")
            {
                idp = idpaciente.ID_PACIENTE;
                idf = idfamiliar.ID_FAM_RESPOSABLE;

                

                txtNombre.Text = idpaciente.PERSONA.NOMBRE;
                txtPaterno.Text = idpaciente.PERSONA.A_PATERNO;
                txtMaterno.Text = idpaciente.PERSONA.A_MATERNO;
                cbbSexo.Text = idpaciente.PERSONA.SEXO;
                txtCalle.Text = idpaciente.PERSONA.CALLE;
                int idestado = comboBoxEstado.Items.IndexOf(idpaciente.PERSONA.ESTADO1);
                comboBoxEstado.SelectedIndex = idestado;
                
                txtMunicipio.Text = idpaciente.PERSONA.NOMMUNICIPIO;
                txtLocalidad.Text = idpaciente.PERSONA.NOMLOCALIDAD;
                txtCurp.Text = idpaciente.PERSONA.CURP;
                dpFecha_Nacimiento.Text = idpaciente.PERSONA.F_NACIMIENTO.ToString();
                txtNombreFam.Text = idfamiliar.PERSONA.NOMBRE;
                txtPaternoRes.Text = idfamiliar.PERSONA.A_PATERNO;
                txtMaternoRes.Text = idfamiliar.PERSONA.A_MATERNO;                
                cbbSexoFR.Text = idfamiliar.PERSONA.SEXO;
                txtCelularRes.Text = idfamiliar.PERSONA.T_CELULAR;
                txtParentezco.Text = idfamiliar.PARENTESCO;
                cbTipoPaciente.IsChecked = true;

                
            }else
            {
                idp = idpaciente.ID_PACIENTE;
                idf = idfamiliar.ID_FAM_RESPOSABLE;

                txtNombre.Text = idpaciente.PERSONA.NOMBRE;
                txtPaterno.Text = idpaciente.PERSONA.A_PATERNO;
                txtMaterno.Text = idpaciente.PERSONA.A_MATERNO;
                cbbSexo.Text = idpaciente.PERSONA.SEXO;
                txtCalle.Text = idpaciente.PERSONA.CALLE;
                int idestado = comboBoxEstado.Items.IndexOf(idpaciente.PERSONA.ESTADO1);
                comboBoxEstado.SelectedIndex = idestado;
                txtMunicipio.Text = idpaciente.PERSONA.NOMMUNICIPIO;
                txtLocalidad.Text = idpaciente.PERSONA.NOMLOCALIDAD;
                txtCurp.Text = idpaciente.PERSONA.CURP;
                dpFecha_Nacimiento.Text = idpaciente.PERSONA.F_NACIMIENTO.ToString();                
                txtNombreFam.Text = idfamiliar.PERSONA.NOMBRE;
                txtPaternoRes.Text = idfamiliar.PERSONA.A_PATERNO;
                txtMaternoRes.Text = idfamiliar.PERSONA.A_MATERNO;
                cbbSexoFR.Text = idfamiliar.PERSONA.SEXO;
                txtCelularRes.Text = idfamiliar.PERSONA.T_CELULAR;
                txtParentezco.Text = idfamiliar.PARENTESCO;
                

            }

            btnGuardar.IsEnabled = false;
            btnEditar.IsEnabled = true;

            btnGuardar.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Visible;

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

        //private void dpFecha_Nacimiento_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var picker = sender as DatePicker;
        //    DateTime? date = picker.SelectedDate;

        //    if (date == null)
        //    {
        //        this.Title = "No se ha seleccionado una fecha";
        //    }
        //}

        public void FillEstados()
        {

            List<ESTADO> lst = BaseDatos.GetBaseDatos().ESTADOS.ToList();
            comboBoxEstado.ItemsSource = lst;
        }

        void limpiar()
        {
            txtNombre.Text = String.Empty;
            txtPaterno.Text = String.Empty;
            txtMaterno.Text = String.Empty;
            txtCalle.Text = String.Empty;
            txtCelularRes.Text = String.Empty;
            txtCurp.Text = String.Empty;
            cbbSexo.SelectedIndex = -1;
            comboBoxEstado.SelectedIndex = -1;
            txtNombreFam.Text = String.Empty;
            txtPaternoRes.Text = String.Empty;
            txtMaternoRes.Text = String.Empty;
            txtCelularRes.Text = String.Empty;
            txtParentezco.Text = String.Empty;
            cbbSexoFR.SelectedIndex = -1;
            autoCuarto.SearchText = String.Empty;
            dpFecha_Nacimiento.Text = String.Empty;
            txtMunicipio.Text = String.Empty;
            txtLocalidad.Text = String.Empty;
        }

        void Guardar()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa el nombre del paciente");
            } else
            {
                if (txtPaterno.Text == "" && txtMaterno.Text == "")
                {
                    MessageBox.Show("Ingresa los apellidos del paciente");
                }else
                {
                    if (dpFecha_Nacimiento.SelectedDate == null)
                    {
                        MessageBox.Show("Selecciona la fecha de nacimiento del paciente");
                    }else
                    {
                        if (cbbSexo.Text == "")
                        {
                            MessageBox.Show("Selecciona el sexo del paciente");
                        }else
                        {
                            if (txtCalle.Text == "")
                            {
                                MessageBox.Show("Ingresa la calle");
                            }else
                            {
                                if (comboBoxEstado.Text == "")
                                {
                                    MessageBox.Show("Selecciona un estado");
                                }else
                                {
                                    if (txtMunicipio.Text == "")
                                    {
                                        MessageBox.Show("Ingresa un municipio");
                                    }else
                                    {
                                        if (txtLocalidad.Text == "")
                                        {
                                            MessageBox.Show("Ingresa una localidad");
                                        }else
                                        {
                                            if (txtCurp.Text == "" && txtCurp.Text.Length < 19)
                                            {
                                                MessageBox.Show("Ingresa una CURP valida");
                                            }else
                                            {
                                                if (txtNombreFam.Text == "")
                                                {
                                                    MessageBox.Show("Ingresa el nombre del familiar responsable");
                                                }else
                                                {
                                                    if (txtPaternoRes.Text == "")
                                                    {
                                                        MessageBox.Show("Ingresa el apellido paterno del familiar");
                                                    }else
                                                    {
                                                        if (txtMaternoRes.Text == "")
                                                        {
                                                            MessageBox.Show("Ingresa el apellido materno del familiar");
                                                        }else
                                                        {
                                                            if (cbbSexoFR.Text == "")
                                                            {
                                                                MessageBox.Show("Selecciona el sexo del familiar");
                                                            }else
                                                            {
                                                                if (txtCelularRes.Text == "")
                                                                {
                                                                    MessageBox.Show("Ingresa el numero de telefono del paciente");
                                                                }else
                                                                {
                                                                    if (txtParentezco.Text == "")
                                                                    {
                                                                        MessageBox.Show("Ingresa el parentezco");
                                                                    }else
                                                                    {
                                                                        if (autoCuarto.SelectedItem == null)
                                                                        {
                                                                            MessageBox.Show("Selecciona un cuarto");
                                                                        }else
                                                                        {
                                                                            if (cbTipoPaciente.IsChecked == true)
                                                                            {
                                                                                DateTime fregistro = DateTime.Now;
                                                                                dynamic cua = autoCuarto.SelectedItem;
                                                                                int idcua = cua.ID_CATALOGO_CUARTO;

                                                                                PERSONA pac = new PERSONA
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
                                                                                    FECHA_CREACION = fregistro,
                                                                                    ESTADOPERSONA = "Activo"
                                                                                };

                                                                                BaseDatos.GetBaseDatos().PERSONAS.Add(pac);
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                PACIENTE paciente = new PACIENTE
                                                                                {
                                                                                    PERSONAID = pac.ID_PERSONA,
                                                                                    TIPO_PACIENTE = "Hospitalizado",
                                                                                    FECHA_CREACION = fregistro,
                                                                                    CUARTOID = idcua
                                                                                };

                                                                                BaseDatos.GetBaseDatos().PACIENTES.Add(paciente);
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                PERSONA fam = new PERSONA
                                                                                {
                                                                                    NOMBRE = txtNombreFam.Text,
                                                                                    A_PATERNO = txtPaternoRes.Text,
                                                                                    A_MATERNO = txtMaternoRes.Text,
                                                                                    SEXO = cbbSexoFR.Text,
                                                                                    T_CELULAR = txtCelularRes.Text,
                                                                                    FECHA_CREACION = fregistro
                                                                                };

                                                                                BaseDatos.GetBaseDatos().PERSONAS.Add(fam);
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                FAM_RESPONSABLES famres = new FAM_RESPONSABLES
                                                                                {
                                                                                    PERSONAID = fam.ID_PERSONA,
                                                                                    PARENTESCO = txtParentezco.Text,
                                                                                    FECHA_CREACION = fregistro,
                                                                                    PACIENTEID = paciente.ID_PACIENTE
                                                                                };

                                                                                BaseDatos.GetBaseDatos().FAM_RESPONSABLES.Add(famres);
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                CUENTA cupac = new CUENTA
                                                                                {
                                                                                    PACIENTEID = paciente.ID_PACIENTE,
                                                                                    TOTAL = 0,
                                                                                    SALDO = -500
                                                                                };

                                                                                BaseDatos.GetBaseDatos().CUENTAS.Add(cupac);
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                var cuarto = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Find(idcua);
                                                                                if (cuarto.MAX_PACIENTES == cuarto.PAC_ACTUALES)
                                                                                {
                                                                                    cuarto.ESTADO = "Ocupado";
                                                                                    BaseDatos.GetBaseDatos().SaveChanges();
                                                                                }else
                                                                                {
                                                                                    cuarto.PAC_ACTUALES = cuarto.PAC_ACTUALES + 1;
                                                                                    BaseDatos.GetBaseDatos().SaveChanges();
                                                                                    if (cuarto.MAX_PACIENTES == cuarto.PAC_ACTUALES)
                                                                                    {
                                                                                        cuarto.ESTADO = "Ocupado";
                                                                                        BaseDatos.GetBaseDatos().SaveChanges();
                                                                                    }
                                                                                }

                                                                                MessageBox.Show("Registro exitoso");
                                                                                llenarAutocmpletes();
                                                                                limpiar();
                                                                                //
                                                                            }
                                                                            else
                                                                            {
                                                                                DateTime fregistro = DateTime.Now;
                                                                                dynamic cua = autoCuarto.SelectedItem;
                                                                                int idcua = cua.ID_CATALOGO_CUARTO;

                                                                                PERSONA pac = new PERSONA
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
                                                                                    FECHA_CREACION = fregistro,
                                                                                    ESTADOPERSONA = "Activo"
                                                                                };

                                                                                BaseDatos.GetBaseDatos().PERSONAS.Add(pac);
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                PACIENTE paciente = new PACIENTE
                                                                                {
                                                                                    PERSONAID = pac.ID_PERSONA,
                                                                                    TIPO_PACIENTE = "Ambulatorio",
                                                                                    FECHA_CREACION = fregistro,
                                                                                    CUARTOID = idcua
                                                                                };

                                                                                BaseDatos.GetBaseDatos().PACIENTES.Add(paciente);
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                PERSONA fam = new PERSONA
                                                                                {
                                                                                    NOMBRE = txtNombreFam.Text,
                                                                                    A_PATERNO = txtPaternoRes.Text,
                                                                                    A_MATERNO = txtMaternoRes.Text,
                                                                                    SEXO = cbbSexoFR.Text,
                                                                                    T_CELULAR = txtCelularRes.Text,
                                                                                    FECHA_CREACION = fregistro
                                                                                };

                                                                                BaseDatos.GetBaseDatos().PERSONAS.Add(fam);
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                FAM_RESPONSABLES famres = new FAM_RESPONSABLES
                                                                                {
                                                                                    PERSONAID = fam.ID_PERSONA,
                                                                                    PARENTESCO = txtParentezco.Text,
                                                                                    FECHA_CREACION = fregistro,
                                                                                    PACIENTEID = paciente.ID_PACIENTE
                                                                                };

                                                                                BaseDatos.GetBaseDatos().FAM_RESPONSABLES.Add(famres);
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                CUENTA cupac = new CUENTA
                                                                                {
                                                                                    PACIENTEID = paciente.ID_PACIENTE,
                                                                                    TOTAL = 0,
                                                                                    SALDO = -500
                                                                                };

                                                                                BaseDatos.GetBaseDatos().CUENTAS.Add(cupac);
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                var cuarto = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Find(idcua);
                                                                                if (cuarto.MAX_PACIENTES == cuarto.PAC_ACTUALES)
                                                                                {
                                                                                    cuarto.ESTADO = "Ocupado";
                                                                                    BaseDatos.GetBaseDatos().SaveChanges();
                                                                                }
                                                                                else
                                                                                {
                                                                                    cuarto.PAC_ACTUALES = cuarto.PAC_ACTUALES + 1;
                                                                                    BaseDatos.GetBaseDatos().SaveChanges();
                                                                                    if (cuarto.MAX_PACIENTES == cuarto.PAC_ACTUALES)
                                                                                    {
                                                                                        cuarto.ESTADO = "Ocupado";
                                                                                        BaseDatos.GetBaseDatos().SaveChanges();
                                                                                    }
                                                                                }

                                                                                MessageBox.Show("Registro exitoso");
                                                                                limpiar();
                                                                                llenarAutocmpletes();
                                                                                //
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
            }
        }

        void Editar()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa el nombre del paciente");
            }
            else
            {
                if (txtPaterno.Text == "" && txtMaterno.Text == "")
                {
                    MessageBox.Show("Ingresa los apellidos del paciente");
                }
                else
                {
                    if (dpFecha_Nacimiento.SelectedDate == null)
                    {
                        MessageBox.Show("Selecciona la fecha de nacimiento del paciente");
                    }
                    else
                    {
                        if (cbbSexo.Text == "")
                        {
                            MessageBox.Show("Selecciona el sexo del paciente");
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
                                        MessageBox.Show("Ingresa un municipio");
                                    }
                                    else
                                    {
                                        if (txtLocalidad.Text == "")
                                        {
                                            MessageBox.Show("Ingresa una localidad");
                                        }
                                        else
                                        {
                                            if (txtCurp.Text == "" && txtCurp.Text.Length < 19)
                                            {
                                                MessageBox.Show("Ingresa una CURP valida");
                                            }
                                            else
                                            {
                                                if (txtNombreFam.Text == "")
                                                {
                                                    MessageBox.Show("Ingresa el nombre del familiar responsable");
                                                }
                                                else
                                                {
                                                    if (txtPaternoRes.Text == "")
                                                    {
                                                        MessageBox.Show("Ingresa el apellido paterno del familiar");
                                                    }
                                                    else
                                                    {
                                                        if (txtMaternoRes.Text == "")
                                                        {
                                                            MessageBox.Show("Ingresa el apellido materno del familiar");
                                                        }
                                                        else
                                                        {
                                                            if (cbbSexoFR.Text == "")
                                                            {
                                                                MessageBox.Show("Selecciona el sexo del familiar");
                                                            }
                                                            else
                                                            {
                                                                if (txtCelularRes.Text == "")
                                                                {
                                                                    MessageBox.Show("Ingresa el numero de telefono del paciente");
                                                                }
                                                                else
                                                                {
                                                                    if (txtParentezco.Text == "")
                                                                    {
                                                                        MessageBox.Show("Ingresa el parentezco");
                                                                    }
                                                                    else
                                                                    {
                                                                        if (autoCuarto.SelectedItem == null)
                                                                        {
                                                                            MessageBox.Show("Selecciona un cuarto");
                                                                        }else
                                                                        {
                                                                            if (cbTipoPaciente.IsChecked == true)
                                                                            {
                                                                                //var ccua = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Find(idccp);
                                                                                //ccua.PAC_ACTUALES = -1;
                                                                                //BaseDatos.GetBaseDatos().SaveChanges();

                                                                                DateTime fmod = DateTime.Now;

                                                                                dynamic c = autoCuarto.SelectedItem;
                                                                                int idcuart = c.ID_CATALOGO_CUARTO;

                                                                                var pcc = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Find(idcuart);
                                                                                pcc.PAC_ACTUALES = pcc.PAC_ACTUALES + 1;
                                                                                if (pcc.MAX_PACIENTES == pcc.PAC_ACTUALES)
                                                                                {
                                                                                    pcc.ESTADO = "Ocupado";
                                                                                    BaseDatos.GetBaseDatos().SaveChanges();
                                                                                }

                                                                                var pa = BaseDatos.GetBaseDatos().PACIENTES.Find(idp);
                                                                                pa.PERSONA.NOMBRE = txtNombre.Text;
                                                                                pa.PERSONA.A_MATERNO = txtMaterno.Text;
                                                                                pa.PERSONA.A_PATERNO = txtPaterno.Text;
                                                                                pa.PERSONA.F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate;
                                                                                pa.PERSONA.SEXO = cbbSexo.Text;
                                                                                pa.PERSONA.CALLE = txtCalle.Text;
                                                                                pa.PERSONA.ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue);
                                                                                pa.PERSONA.NOMMUNICIPIO = txtMunicipio.Text;
                                                                                pa.PERSONA.NOMLOCALIDAD = txtLocalidad.Text;
                                                                                pa.PERSONA.CURP = txtCurp.Text;
                                                                                pa.TIPO_PACIENTE = "Hospitalizado";
                                                                                pa.FECHA_MOD = fmod;
                                                                                pa.CUARTOID = idcuart;
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                var fam = BaseDatos.GetBaseDatos().FAM_RESPONSABLES.Find(idf);
                                                                                fam.PERSONA.NOMBRE = txtNombreFam.Text;
                                                                                fam.PERSONA.A_PATERNO = txtPaternoRes.Text;
                                                                                fam.PERSONA.A_MATERNO = txtMaternoRes.Text;
                                                                                fam.PERSONA.SEXO = cbbSexo.Text;
                                                                                fam.PERSONA.T_CELULAR = txtCelularRes.Text;
                                                                                fam.PARENTESCO = txtParentezco.Text;
                                                                                fam.FECHA_MOD = fmod;
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                MessageBox.Show("Se actualizo el registro");
                                                                                ConsultaPacientes cp = new ConsultaPacientes();
                                                                                cp.Show();
                                                                                this.Close();
                                                                            }
                                                                            else
                                                                            {
                                                                                DateTime fmod = DateTime.Now;
                                                                                dynamic c = autoCuarto.SelectedItem;
                                                                                int idcuart = c.ID_CATALOGO_CUARTO;

                                                                                var pcc = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.Find(idcuart);
                                                                                pcc.PAC_ACTUALES = pcc.PAC_ACTUALES + 1;
                                                                                if (pcc.MAX_PACIENTES == pcc.PAC_ACTUALES)
                                                                                {
                                                                                    pcc.ESTADO = "Ocupado";
                                                                                    BaseDatos.GetBaseDatos().SaveChanges();
                                                                                }

                                                                                var pa = BaseDatos.GetBaseDatos().PACIENTES.Find(idp);
                                                                                pa.PERSONA.NOMBRE = txtNombre.Text;
                                                                                pa.PERSONA.A_MATERNO = txtMaterno.Text;
                                                                                pa.PERSONA.A_PATERNO = txtPaterno.Text;
                                                                                pa.PERSONA.F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate;
                                                                                pa.PERSONA.SEXO = cbbSexo.Text;
                                                                                pa.PERSONA.CALLE = txtCalle.Text;
                                                                                pa.PERSONA.ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue);
                                                                                pa.PERSONA.NOMMUNICIPIO = txtMunicipio.Text;
                                                                                pa.PERSONA.NOMLOCALIDAD = txtLocalidad.Text;
                                                                                pa.PERSONA.CURP = txtCurp.Text;
                                                                                pa.TIPO_PACIENTE = "Hospitalizado";
                                                                                pa.FECHA_MOD = fmod;
                                                                                pa.CUARTOID = idcuart;
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                var fam = BaseDatos.GetBaseDatos().FAM_RESPONSABLES.Find(idf);
                                                                                fam.PERSONA.NOMBRE = txtNombreFam.Text;
                                                                                fam.PERSONA.A_PATERNO = txtPaternoRes.Text;
                                                                                fam.PERSONA.A_MATERNO = txtMaternoRes.Text;
                                                                                fam.PERSONA.SEXO = cbbSexo.Text;
                                                                                fam.PERSONA.T_CELULAR = txtCelularRes.Text;
                                                                                fam.PARENTESCO = txtParentezco.Text;
                                                                                fam.FECHA_MOD = fmod;
                                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                                MessageBox.Show("Se actualizo el registro");
                                                                                ConsultaPacientes cp = new ConsultaPacientes();
                                                                                cp.Show();
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
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }
    }
}
