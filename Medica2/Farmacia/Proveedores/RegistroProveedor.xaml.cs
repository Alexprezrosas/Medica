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

namespace Medica2.Farmacia.Proveedores
{
    /// <summary>
    /// Lógica de interacción para RegistroProveedor.xaml
    /// </summary>
    public partial class RegistroProveedor : Window
    {
        int idp;
        private RadAutoCompleteBox autoProve;

        public RegistroProveedor()
        {
            InitializeComponent();
            FillEstados();
            Limpiar();
        }

        public RegistroProveedor(PROVEEDORE idprove, bool save)
        {
            InitializeComponent();
            FillEstados();
            idp = idprove.ID_PROVEEDOR;

            if (idprove.PERSONA.A_PATERNO == null)
            {
                checMoral.IsChecked = true;
                txtNombre.Text = idprove.PERSONA.NOMBRE;
                txtPaterno.Text = idprove.PERSONA.A_PATERNO;
                txtMaterno.Text = idprove.PERSONA.A_MATERNO;
                cbbSexo.Text = idprove.PERSONA.SEXO;
                txtCalle.Text = idprove.PERSONA.CALLE;

                dpFecha_Nacimiento.SelectedDate = idprove.PERSONA.F_NACIMIENTO;

                int idestado = comboBoxEstado.Items.IndexOf(idprove.PERSONA.ESTADO1);
                comboBoxEstado.SelectedIndex = idestado;
                txtMunicipio.Text = idprove.PERSONA.NOMMUNICIPIO;
                txtLocalidad.Text = idprove.PERSONA.NOMLOCALIDAD;

                txtCelular.Text = idprove.PERSONA.T_CELULAR;
                txtCurp.Text = idprove.PERSONA.CURP;
                txtRFC.Text = idprove.RFC;
                txtNota.Text = idprove.NOTA;
            }
            else
            {
                checMoral.IsChecked = false;
                txtNombre.Text = idprove.PERSONA.NOMBRE;
                txtCalle.Text = idprove.PERSONA.CALLE;

                txtPaterno.Text = idprove.PERSONA.A_PATERNO;
                txtMaterno.Text = idprove.PERSONA.A_MATERNO;
                cbbSexo.Text = idprove.PERSONA.SEXO;
                txtCurp.Text = idprove.PERSONA.CURP;

                int idestado = comboBoxEstado.Items.IndexOf(idprove.PERSONA.ESTADO1);
                comboBoxEstado.SelectedIndex = idestado;
                txtMunicipio.Text = idprove.PERSONA.NOMMUNICIPIO;
                txtLocalidad.Text = idprove.PERSONA.NOMLOCALIDAD;

                txtCelular.Text = idprove.PERSONA.T_CELULAR;
                txtRFC.Text = idprove.RFC;
                txtNota.Text = idprove.NOTA;
            }
            

            btnGuardar.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Visible;
        }

        public RegistroProveedor(RadAutoCompleteBox autoProveedor)
        {
            InitializeComponent();
            autoProve = autoProveedor;
            FillEstados();
            Limpiar();
            btnGuardar.Visibility = Visibility.Hidden;
            btnCompras.Visibility = Visibility.Visible;
        }

        public void GuardarPMoralCompras()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa un nombre");
            }
            else
            {
                if (txtCalle.Text == "")
                {
                    MessageBox.Show("Ingresa una calle");
                }
                else
                {
                    if (comboBoxEstado.SelectedItem == null)
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
                                if (txtCelular.Text == "")
                                {
                                    MessageBox.Show("Ingresa un celular");
                                }
                                else
                                {
                                    if (txtRFC.Text == "" && txtRFC.Text.Length < 12)
                                    {
                                        MessageBox.Show("Ingresa un RFC valido");
                                    }
                                    else
                                    {
                                        if (!ConsultaRFC(txtRFC.Text))
                                        {
                                            if (txtNota.Text == "")
                                            {
                                                DateTime FechaRegistro = DateTime.Now;

                                                PERSONA cc = new PERSONA
                                                {
                                                    NOMBRE = txtNombre.Text,
                                                    CALLE = txtCalle.Text,
                                                    //LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue),
                                                    NOMLOCALIDAD = txtLocalidad.Text,
                                                    //MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue),
                                                    NOMMUNICIPIO = txtMunicipio.Text,
                                                    ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                    FECHA_CREACION = FechaRegistro,
                                                    T_CELULAR = txtCelular.Text
                                                };
                                                BaseDatos.GetBaseDatos().PERSONAS.Add(cc);
                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                PROVEEDORE prv = new PROVEEDORE
                                                {
                                                    PERSONAID = cc.ID_PERSONA,
                                                    RFC = txtRFC.Text,
                                                    FECHA_CREACION = FechaRegistro
                                                };
                                                prv.PERSONA = cc;
                                                BaseDatos.GetBaseDatos().PROVEEDORES.Add(prv);
                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                //Mensaje
                                                MessageBoxResult result = MessageBox.Show("Se guardo correctamente el proveedor", "Registro exitoso");
                                                autoProve.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                                                         join e in BaseDatos.GetBaseDatos().PROVEEDORES
                                                                         on PERSONA.ID_PERSONA equals e.PERSONAID
                                                                         select new
                                                                         {
                                                                             ID_PROVEEDOR = e.ID_PROVEEDOR,
                                                                             NOMBRE = PERSONA.NOMBRE
                                                                         });
                                                this.Close();
                                            }
                                            else
                                            {
                                                DateTime FechaRegistro = DateTime.Now;

                                                PERSONA cc = new PERSONA
                                                {
                                                    NOMBRE = txtNombre.Text,
                                                    CALLE = txtCalle.Text,
                                                    //LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue),
                                                    NOMLOCALIDAD = txtLocalidad.Text,
                                                    //MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue),
                                                    NOMMUNICIPIO = txtMunicipio.Text,
                                                    ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                    FECHA_CREACION = FechaRegistro,
                                                    T_CELULAR = txtCelular.Text
                                                };
                                                BaseDatos.GetBaseDatos().PERSONAS.Add(cc);
                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                //cc = pr.PERSONAS.Last();



                                                PROVEEDORE prv = new PROVEEDORE
                                                {
                                                    PERSONAID = cc.ID_PERSONA,
                                                    RFC = txtRFC.Text,
                                                    NOTA = txtNota.Text,
                                                    FECHA_CREACION = FechaRegistro
                                                };
                                                prv.PERSONA = cc;
                                                BaseDatos.GetBaseDatos().PROVEEDORES.Add(prv);
                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                //Mensaje
                                                MessageBoxResult result = MessageBox.Show("Se guardo correctamente el proveedor", "Registro exitoso");
                                                autoProve.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                                                         join e in BaseDatos.GetBaseDatos().PROVEEDORES
                                                                         on PERSONA.ID_PERSONA equals e.PERSONAID
                                                                         select new
                                                                         {
                                                                             ID_PROVEEDOR = e.ID_PROVEEDOR,
                                                                             NOMBRE = PERSONA.NOMBRE
                                                                         });
                                                this.Close();
                                            }
                                        }else
                                        {
                                            MessageBox.Show("El RFC ya existe");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void GuardarPFisicaCompras()
        {
            //
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Insertar un nombre");
            }
            else
            {
                if (txtPaterno.Text == "")
                {
                    MessageBox.Show("Insertar un apellido paterno");
                }
                else
                {
                    if (txtMaterno.Text == "")
                    {
                        MessageBox.Show("Insertar un apellido materno");
                    }
                    else
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
                            }
                            else
                            {
                                if (comboBoxEstado.SelectedItem == null)
                                {
                                    MessageBox.Show("Selecciona un estado");
                                }
                                else
                                {
                                    if (txtMunicipio.Text == "")
                                    {
                                        MessageBox.Show("Seleccionar un municipio");
                                    }
                                    else
                                    {
                                        if (txtLocalidad.Text == "")
                                        {
                                            MessageBox.Show("Seleccionar una localidad");
                                        }
                                        else
                                        {
                                            if (txtCelular.Text == "")
                                            {
                                                MessageBox.Show("Insertar un celular");
                                            }
                                            else
                                            {
                                                if (txtCurp.Text == "" && txtCurp.Text.Length < 18)
                                                {
                                                    MessageBox.Show("Insertar una curp valida");
                                                }
                                                else
                                                {
                                                    if (txtRFC.Text == "" && txtRFC.Text.Length < 13)
                                                    {
                                                        MessageBox.Show("Insertar un RFC valido");
                                                    }
                                                    else
                                                    {
                                                        if (!ConsultaRFC(txtRFC.Text))
                                                        {
                                                            if (txtNota.Text == "")
                                                            {
                                                                //Obtener los valores de los TextBox

                                                                DateTime FechaRegistro = DateTime.Now;

                                                                //fechacrea.Text = DateTime.Now.ToString();
                                                                //DateTime fechacre = fechacrea.GetValue();
                                                                PERSONA cc = new PERSONA
                                                                {
                                                                    NOMBRE = txtNombre.Text,
                                                                    A_PATERNO = txtPaterno.Text,
                                                                    A_MATERNO = txtMaterno.Text,
                                                                    F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate,
                                                                    SEXO = cbbSexo.Text,
                                                                    CALLE = txtCalle.Text,
                                                                    //LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue),
                                                                    //MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue),
                                                                    NOMLOCALIDAD = txtLocalidad.Text,
                                                                    NOMMUNICIPIO = txtMunicipio.Text,
                                                                    ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                                    T_CELULAR = txtCelular.Text,
                                                                    CURP = txtCurp.Text,
                                                                    FECHA_CREACION = FechaRegistro
                                                                };
                                                                BaseDatos.GetBaseDatos().PERSONAS.Add(cc);
                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                PROVEEDORE prv = new PROVEEDORE
                                                                {
                                                                    PERSONAID = cc.ID_PERSONA,
                                                                    RFC = txtRFC.Text,
                                                                    FECHA_CREACION = FechaRegistro
                                                                };
                                                                prv.PERSONA = cc;
                                                                BaseDatos.GetBaseDatos().PROVEEDORES.Add(prv);
                                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                                //Mensaje
                                                                MessageBoxResult result = MessageBox.Show("Se guardo correctamente el proveedor", "Registro exitoso");
                                                                autoProve.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                                                                         join e in BaseDatos.GetBaseDatos().PROVEEDORES
                                                                                         on PERSONA.ID_PERSONA equals e.PERSONAID
                                                                                         select new
                                                                                         {
                                                                                             ID_PROVEEDOR = e.ID_PROVEEDOR,
                                                                                             NOMBRE = PERSONA.NOMBRE
                                                                                         });
                                                                this.Close();
                                                            }
                                                            else
                                                            {
                                                                //Obtener los valores de los TextBox

                                                                DateTime FechaRegistro = DateTime.Now;

                                                                //fechacrea.Text = DateTime.Now.ToString();
                                                                //DateTime fechacre = fechacrea.GetValue();
                                                                PERSONA cc = new PERSONA
                                                                {
                                                                    NOMBRE = txtNombre.Text,
                                                                    A_PATERNO = txtPaterno.Text,
                                                                    A_MATERNO = txtMaterno.Text,
                                                                    F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate,
                                                                    SEXO = cbbSexo.Text,
                                                                    CALLE = txtCalle.Text,
                                                                    NOMLOCALIDAD = txtLocalidad.Text,
                                                                    NOMMUNICIPIO = txtMunicipio.Text,
                                                                    ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                                    T_CELULAR = txtCelular.Text,
                                                                    CURP = txtCurp.Text,
                                                                    FECHA_CREACION = FechaRegistro
                                                                };
                                                                BaseDatos.GetBaseDatos().PERSONAS.Add(cc);
                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                PROVEEDORE prv = new PROVEEDORE
                                                                {
                                                                    PERSONAID = cc.ID_PERSONA,
                                                                    RFC = txtRFC.Text,
                                                                    NOTA = txtNota.Text,
                                                                    FECHA_CREACION = FechaRegistro
                                                                };
                                                                prv.PERSONA = cc;
                                                                BaseDatos.GetBaseDatos().PROVEEDORES.Add(prv);
                                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                                //Mensaje
                                                                MessageBoxResult result = MessageBox.Show("Se guardo correctamente el proveedor", "Registro exitoso");
                                                                autoProve.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                                                                         join e in BaseDatos.GetBaseDatos().PROVEEDORES
                                                                                         on PERSONA.ID_PERSONA equals e.PERSONAID
                                                                                         select new
                                                                                         {
                                                                                             ID_PROVEEDOR = e.ID_PROVEEDOR,
                                                                                             NOMBRE = PERSONA.NOMBRE
                                                                                         });
                                                                this.Close();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("El RFC ya existe");
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

        public void GuardarPMoral()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa un nombre");
            }
            else
            {
                if (txtCalle.Text == "")
                {
                    MessageBox.Show("Ingresa una calle");
                }
                else
                {
                    if (comboBoxEstado.SelectedItem == null)
                    {
                        MessageBox.Show("Ingresa un estado");
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
                                if (txtCelular.Text == "")
                                {
                                    MessageBox.Show("Ingresa un celular");
                                }
                                else
                                {
                                    if (txtRFC.Text == "" && txtRFC.Text.Length < 12)
                                    {
                                        MessageBox.Show("Ingresa un RFC valido");
                                    }
                                    else
                                    {//
                                        if (!ConsultaRFC(txtRFC.Text))
                                        {
                                            if (txtNota.Text == "")
                                            {
                                                DateTime FechaRegistro = DateTime.Now;

                                                PERSONA cc = new PERSONA
                                                {
                                                    NOMBRE = txtNombre.Text,
                                                    CALLE = txtCalle.Text,
                                                    //LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue),
                                                    NOMLOCALIDAD = txtLocalidad.Text,
                                                    //MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue),
                                                    NOMMUNICIPIO = txtMunicipio.Text,
                                                    ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                    FECHA_CREACION = FechaRegistro,
                                                    T_CELULAR = txtCelular.Text
                                                };
                                                BaseDatos.GetBaseDatos().PERSONAS.Add(cc);
                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                PROVEEDORE prv = new PROVEEDORE
                                                {
                                                    PERSONAID = cc.ID_PERSONA,
                                                    RFC = txtRFC.Text,
                                                    FECHA_CREACION = FechaRegistro
                                                };
                                                prv.PERSONA = cc;
                                                BaseDatos.GetBaseDatos().PROVEEDORES.Add(prv);
                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                //Mensaje
                                                MessageBoxResult result = MessageBox.Show("Se guardo correctamente el proveedor", "Registro exitoso");
                                                //autoProveedor.ItemsSource = BaseDatos.GetBaseDatos().PROVEEDORES;
                                                //MostrarProveedores mp = new MostrarProveedores();
                                                //mp.Show();
                                                Limpiar();
                                            }
                                            else
                                            {
                                                DateTime FechaRegistro = DateTime.Now;

                                                PERSONA cc = new PERSONA
                                                {
                                                    NOMBRE = txtNombre.Text,
                                                    CALLE = txtCalle.Text,
                                                    //LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue),
                                                    NOMLOCALIDAD = txtLocalidad.Text,
                                                    //MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue),
                                                    NOMMUNICIPIO = txtMunicipio.Text,
                                                    ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                    FECHA_CREACION = FechaRegistro,
                                                    T_CELULAR = txtCelular.Text
                                                };
                                                BaseDatos.GetBaseDatos().PERSONAS.Add(cc);
                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                //cc = pr.PERSONAS.Last();



                                                PROVEEDORE prv = new PROVEEDORE
                                                {
                                                    PERSONAID = cc.ID_PERSONA,
                                                    RFC = txtRFC.Text,
                                                    NOTA = txtNota.Text,
                                                    FECHA_CREACION = FechaRegistro
                                                };
                                                prv.PERSONA = cc;
                                                BaseDatos.GetBaseDatos().PROVEEDORES.Add(prv);
                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                //Mensaje
                                                MessageBoxResult result = MessageBox.Show("Se guardo correctamente el proveedor", "Registro exitoso");
                                                //autoProveedor.ItemsSource = BaseDatos.GetBaseDatos().PROVEEDORES;
                                                //MostrarProveedores mp = new MostrarProveedores();
                                                //mp.Show();
                                                Limpiar();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("EL RFC ya existe");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void GuardarPFisica()
        {
            //
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Insertar un nombre");
            }
            else
            {
                if (txtPaterno.Text == "")
                {
                    MessageBox.Show("Insertar un apellido paterno");
                }
                else
                {
                    if (txtMaterno.Text == "")
                    {
                        MessageBox.Show("Insertar un apellido materno");
                    }
                    else
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
                            }
                            else
                            {
                                if (comboBoxEstado.SelectedItem == null)
                                {
                                    MessageBox.Show("Seleccionar un estado");
                                }
                                else
                                {
                                    if (txtMunicipio.Text == "")
                                    {
                                        MessageBox.Show("Seleccionar un municipio");
                                    }
                                    else
                                    {
                                        if (txtLocalidad.Text == "")
                                        {
                                            MessageBox.Show("Seleccionar una localidad");
                                        }
                                        else
                                        {
                                            if (txtCelular.Text == "")
                                            {
                                                MessageBox.Show("Insertar un celular");
                                            }
                                            else
                                            {
                                                if (txtCurp.Text == "" && txtCurp.Text.Length < 18)
                                                {
                                                    MessageBox.Show("Insertar una curp valida");
                                                }
                                                else
                                                {
                                                    if (txtRFC.Text == "" && txtRFC.Text.Length < 13)
                                                    {
                                                        MessageBox.Show("Insertar un RFC valido");
                                                    }
                                                    else
                                                    {
                                                        if (!ConsultaRFC(txtRFC.Text))
                                                        {
                                                            if (txtNota.Text == "")
                                                            {
                                                                //Obtener los valores de los TextBox

                                                                DateTime FechaRegistro = DateTime.Now;

                                                                //fechacrea.Text = DateTime.Now.ToString();
                                                                //DateTime fechacre = fechacrea.GetValue();
                                                                PERSONA cc = new PERSONA
                                                                {
                                                                    NOMBRE = txtNombre.Text,
                                                                    A_PATERNO = txtPaterno.Text,
                                                                    A_MATERNO = txtMaterno.Text,
                                                                    F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate,
                                                                    SEXO = cbbSexo.Text,
                                                                    CALLE = txtCalle.Text,
                                                                    //LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue),
                                                                    //MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue),
                                                                    NOMLOCALIDAD = txtLocalidad.Text,
                                                                    NOMMUNICIPIO = txtMunicipio.Text,
                                                                    ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                                    T_CELULAR = txtCelular.Text,
                                                                    CURP = txtCurp.Text,
                                                                    FECHA_CREACION = FechaRegistro
                                                                };
                                                                BaseDatos.GetBaseDatos().PERSONAS.Add(cc);
                                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                                //cc = pr.PERSONAS.Last();

                                                                PROVEEDORE prv = new PROVEEDORE
                                                                {
                                                                    PERSONAID = cc.ID_PERSONA,
                                                                    RFC = txtRFC.Text,
                                                                    FECHA_CREACION = FechaRegistro
                                                                };
                                                                prv.PERSONA = cc;
                                                                BaseDatos.GetBaseDatos().PROVEEDORES.Add(prv);
                                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                                //Mensaje
                                                                MessageBoxResult result = MessageBox.Show("Se guardo correctamente el proveedor", "Registro exitoso");
                                                                Limpiar();
                                                            }
                                                            else
                                                            {
                                                                //Obtener los valores de los TextBox

                                                                DateTime FechaRegistro = DateTime.Now;

                                                                //fechacrea.Text = DateTime.Now.ToString();
                                                                //DateTime fechacre = fechacrea.GetValue();
                                                                PERSONA cc = new PERSONA
                                                                {
                                                                    NOMBRE = txtNombre.Text,
                                                                    A_PATERNO = txtPaterno.Text,
                                                                    A_MATERNO = txtMaterno.Text,
                                                                    F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate,
                                                                    SEXO = cbbSexo.Text,
                                                                    CALLE = txtCalle.Text,
                                                                    NOMLOCALIDAD = txtLocalidad.Text,
                                                                    NOMMUNICIPIO = txtMunicipio.Text,
                                                                    ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                                    T_CELULAR = txtCelular.Text,
                                                                    CURP = txtCurp.Text,
                                                                    FECHA_CREACION = FechaRegistro
                                                                };
                                                                BaseDatos.GetBaseDatos().PERSONAS.Add(cc);
                                                                BaseDatos.GetBaseDatos().SaveChanges();

                                                                PROVEEDORE prv = new PROVEEDORE
                                                                {
                                                                    PERSONAID = cc.ID_PERSONA,
                                                                    RFC = txtRFC.Text,
                                                                    NOTA = txtNota.Text,
                                                                    FECHA_CREACION = FechaRegistro
                                                                };
                                                                prv.PERSONA = cc;
                                                                BaseDatos.GetBaseDatos().PROVEEDORES.Add(prv);
                                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                                //Mensaje
                                                                MessageBoxResult result = MessageBox.Show("Se guardo correctamente el proveedor", "Registro exitoso");
                                                                Limpiar();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("El RFC ya existe");
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
            //

        }

        public void EditarPMoral()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingresa un nombre");
            }
            else
            {
                if (txtCalle.Text == "")
                {
                    MessageBox.Show("Ingresa una calle");
                }
                else
                {
                    if (comboBoxEstado.SelectedItem == null)
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
                                if (txtCelular.Text == "")
                                {
                                    MessageBox.Show("Ingresa un celular");
                                }
                                else
                                {
                                    if (txtRFC.Text == "" && txtRFC.Text.Length < 12)
                                    {
                                        MessageBox.Show("Ingresa un RFC valido");
                                    }
                                    else
                                    {
                                        if (!ConsultaRFC(txtRFC.Text))
                                        {
                                            if (txtNota.Text == "")
                                            {
                                                DateTime FechaModificacion = DateTime.Now;

                                                var prove = BaseDatos.GetBaseDatos().PROVEEDORES.Find(idp);
                                                prove.PERSONA.NOMBRE = txtNombre.Text;
                                                prove.PERSONA.CALLE = txtCalle.Text;
                                                //prove.PERSONA.LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue);
                                                //prove.PERSONA.MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue);
                                                prove.PERSONA.NOMLOCALIDAD = txtLocalidad.Text;
                                                prove.PERSONA.NOMMUNICIPIO = txtMunicipio.Text;
                                                prove.PERSONA.ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue);
                                                prove.PERSONA.T_CELULAR = txtCelular.Text;
                                                prove.PERSONA.FECHA_MOD = FechaModificacion;

                                                prove.RFC = txtRFC.Text;
                                                prove.FECHA_MOD = FechaModificacion;


                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                MessageBox.Show("Se ha editado correctamente el proveedor");
                                                this.Close();
                                                MostrarProveedores mp = new MostrarProveedores();
                                                mp.Show();
                                            }
                                            else
                                            {
                                                DateTime FechaModificacion = DateTime.Now;

                                                var prove = BaseDatos.GetBaseDatos().PROVEEDORES.Find(idp);
                                                prove.PERSONA.NOMBRE = txtNombre.Text;
                                                prove.PERSONA.CALLE = txtCalle.Text;
                                                //prove.PERSONA.LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue);
                                                //prove.PERSONA.MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue);
                                                prove.PERSONA.NOMLOCALIDAD = txtLocalidad.Text;
                                                prove.PERSONA.NOMMUNICIPIO = txtMunicipio.Text;
                                                prove.PERSONA.ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue);
                                                prove.PERSONA.T_CELULAR = txtCelular.Text;
                                                prove.PERSONA.FECHA_MOD = FechaModificacion;

                                                prove.RFC = txtRFC.Text;
                                                prove.NOTA = txtNota.Text;
                                                prove.FECHA_MOD = FechaModificacion;


                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                MessageBox.Show("Se ha editado correctamente el proveedor");
                                                this.Close();
                                                MostrarProveedores mp = new MostrarProveedores();
                                                mp.Show();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("El RFC ya existe");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void EditarPFisica()
        {
            //
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Insertar un nombre");
            }
            else
            {
                if (txtPaterno.Text == "")
                {
                    MessageBox.Show("Insertar un apellido paterno");
                }
                else
                {
                    if (txtMaterno.Text == "")
                    {
                        MessageBox.Show("Insertar un apellido materno");
                    }
                    else
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
                            }
                            else
                            {
                                if (comboBoxEstado.SelectedItem == null)
                                {
                                    MessageBox.Show("Selecciona un estado");
                                }
                                else
                                {
                                    if (txtMunicipio.Text == "")
                                    {
                                        MessageBox.Show("Seleccionar un municipio");
                                    }
                                    else
                                    {
                                        if (txtLocalidad.Text == "")
                                        {
                                            MessageBox.Show("Seleccionar una localidad");
                                        }
                                        else
                                        {
                                            if (txtCelular.Text == "")
                                            {
                                                MessageBox.Show("Insertar un celular");
                                            }
                                            else
                                            {
                                                if (txtCurp.Text == "" && txtCurp.Text.Length < 18)
                                                {
                                                    MessageBox.Show("Insertar una curp valida");
                                                }
                                                else
                                                {
                                                    if (txtRFC.Text == "" && txtRFC.Text.Length < 12)
                                                    {
                                                        MessageBox.Show("Insertar un RFC valido");
                                                    }
                                                    else
                                                    {
                                                        if (!ConsultaRFC(txtRFC.Text))
                                                        {
                                                            if (txtNota.Text == "")
                                                            {
                                                                DateTime FechaModificacion = DateTime.Now;

                                                                var prove = BaseDatos.GetBaseDatos().PROVEEDORES.Find(idp);
                                                                prove.PERSONA.NOMBRE = txtNombre.Text;
                                                                prove.PERSONA.A_PATERNO = txtPaterno.Text;
                                                                prove.PERSONA.A_MATERNO = txtMaterno.Text;
                                                                prove.PERSONA.F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate;
                                                                prove.PERSONA.SEXO = cbbSexo.Text;
                                                                prove.PERSONA.CALLE = txtCalle.Text;
                                                                //prove.PERSONA.LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue);
                                                                //prove.PERSONA.MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue);
                                                                prove.PERSONA.NOMLOCALIDAD = txtLocalidad.Text;
                                                                prove.PERSONA.NOMMUNICIPIO = txtMunicipio.Text;
                                                                prove.PERSONA.ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue);
                                                                prove.PERSONA.T_CELULAR = txtCelular.Text;
                                                                prove.PERSONA.CURP = txtCurp.Text;
                                                                prove.PERSONA.FECHA_MOD = FechaModificacion;

                                                                prove.RFC = txtRFC.Text;
                                                                prove.FECHA_MOD = FechaModificacion;


                                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                                MessageBox.Show("Se ha editado correctamente el proveedor");
                                                                this.Close();
                                                                MostrarProveedores mp = new MostrarProveedores();
                                                                mp.Show();
                                                            }
                                                            else
                                                            {
                                                                DateTime FechaModificacion = DateTime.Now;

                                                                var prove = BaseDatos.GetBaseDatos().PROVEEDORES.Find(idp);
                                                                prove.PERSONA.NOMBRE = txtNombre.Text;
                                                                prove.PERSONA.A_PATERNO = txtPaterno.Text;
                                                                prove.PERSONA.A_MATERNO = txtMaterno.Text;
                                                                prove.PERSONA.F_NACIMIENTO = dpFecha_Nacimiento.SelectedDate;
                                                                prove.PERSONA.SEXO = cbbSexo.Text;
                                                                prove.PERSONA.CALLE = txtCalle.Text;
                                                                //prove.PERSONA.LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue);
                                                                //prove.PERSONA.MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue);
                                                                prove.PERSONA.NOMLOCALIDAD = txtLocalidad.Text;
                                                                prove.PERSONA.NOMMUNICIPIO = txtMunicipio.Text;
                                                                prove.PERSONA.ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue);
                                                                prove.PERSONA.T_CELULAR = txtCelular.Text;
                                                                prove.PERSONA.CURP = txtCurp.Text;
                                                                prove.PERSONA.FECHA_MOD = FechaModificacion;

                                                                prove.RFC = txtRFC.Text;
                                                                prove.NOTA = txtNota.Text;
                                                                prove.FECHA_MOD = FechaModificacion;


                                                                BaseDatos.GetBaseDatos().SaveChanges();
                                                                MessageBox.Show("Se ha editado correctamente el proveedor");
                                                                this.Close();
                                                                MostrarProveedores mp = new MostrarProveedores();
                                                                mp.Show();
                                                            }
                                                        }else
                                                        {
                                                            MessageBox.Show("El RFC ya existe");
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
            //

        }

        public bool ConsultaRFC(String rfc )
        {
            //var factura = (from COMPRA in BaseDatos.GetBaseDatos().COMPRAS
            //               where COMPRA.NUM_FACTURA == fac
            //               select COMPRA).Count();
            //if (factura == 0)
            //    return false;
            //else
            //    return true;

            var rfcpr = (from PROVEEDORE in BaseDatos.GetBaseDatos().PROVEEDORES
                           where PROVEEDORE.RFC == rfc
                           select PROVEEDORE).Count();
            if (rfcpr == 0)
                return false;
            else
                return true;

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (checMoral.IsChecked == true)
            {
                GuardarPMoral();
            }
            else
            {
                if (checMoral.IsChecked == false)
                {
                    GuardarPFisica();
                }
            }

        }

        public void Limpiar()
        {
            txtNombre.Text = String.Empty;
            txtPaterno.Text = String.Empty;
            txtMaterno.Text = String.Empty;
            txtCalle.Text = String.Empty;
            txtCelular.Text = String.Empty;
            txtCurp.Text = String.Empty;
            txtRFC.Text = String.Empty;
            txtNota.Text = String.Empty;
            cbbSexo.SelectedIndex = -1;
            comboBoxEstado.SelectedIndex = -1;
            dpFecha_Nacimiento.Text = String.Empty;
            txtMunicipio.Text = String.Empty;
            txtLocalidad.Text = String.Empty;
        }

        public void FillEstados()
        {

            List<ESTADO> lst = BaseDatos.GetBaseDatos().ESTADOS.ToList();
            comboBoxEstado.ItemsSource = lst;
        }

        private void checMoral_Checked(object sender, RoutedEventArgs e)
        {
            if (checMoral.IsChecked == true)
            {
                txtPaterno.IsEnabled = false;
                txtMaterno.IsEnabled = false;
                dpFecha_Nacimiento.IsEnabled = false;
                cbbSexo.IsEnabled = false;
                txtCurp.IsEnabled = false;
            }
        }

        private void checMoral_Unchecked(object sender, RoutedEventArgs e)
        {
            if (checMoral.IsChecked == false)
            {
                txtPaterno.IsEnabled = true;
                txtMaterno.IsEnabled = true;
                dpFecha_Nacimiento.IsEnabled = true;
                cbbSexo.IsEnabled = true;
                txtCurp.IsEnabled = true;
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (checMoral.IsChecked == true)
            {
                EditarPMoral();

            }
            else
            {
                if (checMoral.IsChecked == false)
                {
                    EditarPFisica();
                }
            }
        }

        private void btnCompras_Click(object sender, RoutedEventArgs e)
        {
            if (checMoral.IsChecked == true)
            {
                GuardarPMoralCompras();
            }
            else
            {
                if (checMoral.IsChecked == false)
                {
                    GuardarPFisicaCompras();
                }
            }
        }
    }
}
