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
        
        public NuevaEnfermera()
        {
            InitializeComponent();
            
            FillEstados();
           
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
            txtEdad.Text = "";
            cbbSexo.Text = "";
            txtCalle.Text = "";
            comboBoxEstado.Text = "";
            comboBoxMunicipios.Text = "";
            comboBoxLocalidades.Text = "";
            txtCelular.Text = "";
            txtCurp.Text = "";
            txtCProfesional.Text = "";
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
                        if (txtEdad.Text == "")
                        {
                            MessageBox.Show("Insertar una edad");
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
                                        if (comboBoxMunicipios.Text == "")
                                        {
                                            MessageBox.Show("Seleccionar un municipio");
                                        }else
                                        {
                                            if (comboBoxLocalidades.Text == "")
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
                                                            //Obtener los valores de los TextBox
                                                            DateTime Fecharegistro = DateTime.Now;
                                                            short ed;
                                                            String edad;

                                                            edad = txtEdad.Text;
                                                            ed = short.Parse(edad);

                                                            //fechacrea.Text = DateTime.Now.ToString();
                                                            //DateTime fechacre = fechacrea.GetValue();
                                                            PERSONA cc = new PERSONA
                                                            {
                                                                NOMBRE = txtNombre.Text,
                                                                A_PATERNO = txtPaterno.Text,
                                                                A_MATERNO = txtMaterno.Text,
                                                                //EDAD = ed,
                                                                SEXO = cbbSexo.Text,
                                                                CALLE = txtCalle.Text,
                                                                LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue),
                                                                MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue),
                                                                ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                                                                T_CELULAR = txtCelular.Text,
                                                                CURP = txtCurp.Text,
                                                                FECHA_CREACION = Fecharegistro
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
                                                            MessageBox.Show("Se gurado el registro correctamente");
                                                            limpiarEnfermera();
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



        private void Window_Closed(object sender, EventArgs e)
        {
            //CargarSiloeBD.getDB().SaveChanges();
        }
        public void FillEstados()
        {
            
            List<ESTADO> lst = BaseDatos.GetBaseDatos().ESTADOS.ToList();
            comboBoxEstado.ItemsSource = lst;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int EstadosId = Convert.ToInt32(comboBoxEstado.SelectedValue);
            
            List<MUNICIPIO> lst1 = BaseDatos.GetBaseDatos().MUNICIPIOS.Where(x => x.estado_id == EstadosId).ToList();
            comboBoxMunicipios.ItemsSource = lst1;

        }

        private void comboBox_SelectionChangedL(object sender, SelectionChangedEventArgs e)
        {
            int Municipiosid = Convert.ToInt32(comboBoxMunicipios.SelectedValue);
            
            List<LOCALIDADE> lst1 = BaseDatos.GetBaseDatos().LOCALIDADES.Where(x => x.municipio_id == Municipiosid).ToList();
            comboBoxLocalidades.ItemsSource = lst1;

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
        ///////



    }
}
