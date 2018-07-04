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

namespace Medica2.Administracion.EquipoHospital
{
    /// <summary>
    /// Lógica de interacción para CatalogoEquipoHospital.xaml
    /// </summary>
    public partial class CatalogoEquipoHospital : Window
    {
        int ideh;
        public CatalogoEquipoHospital()
        {
            InitializeComponent();

            //FormCatalogoEqiopoH.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.ToList();

        }
        public CatalogoEquipoHospital(int idceh, bool save)
        {
            InitializeComponent();
            ideh = idceh;
            var caeqho = BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.Find(ideh);

            txtNombre.Text = caeqho.NOM_EQUIPO_HOSPITAL;
            txtDescripcion.Text = caeqho.DESCRIPCION;
            txtCosto.Text = caeqho.COSTO.ToString();

            btnGuardar.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Visible;

        }
        //MEtodo Guardar Equipo hospital
        public void Guardar()
        {
            if (txtNombre.Text == "")
            {
                System.Windows.MessageBox.Show("Inserta el nombre del equipo de hospital");
            }
            else
            {
                if (txtDescripcion.Text == "")
                {
                    System.Windows.MessageBox.Show("Inserta la Descripción");
                }
                else
                {
                    if (txtCosto.Text == "")
                    {
                        System.Windows.MessageBox.Show("Inserta el Costo");
                    }
                    else
                    {

                        DateTime fec = DateTime.Now;

                        CATALOGO_EQUIPO_HOSPITAL c_e_h = new CATALOGO_EQUIPO_HOSPITAL
                        {
                            NOM_EQUIPO_HOSPITAL = txtNombre.Text,
                            DESCRIPCION = txtDescripcion.Text,
                            COSTO = Decimal.Parse(txtCosto.Text),
                            FECHA_CREACION = fec,
                            STATUS = "Activo"

                        };
                        BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.Add(c_e_h);
                        BaseDatos.GetBaseDatos().SaveChanges();
                        System.Windows.MessageBox.Show("Registro exitoso, se ha guardado CORRECTAMENTE");

                        Limpiar();

                        this.Close();

                    }
                }
            }
        }

        public void Editar()
        {
            if (txtNombre.Text == "")
            {
                System.Windows.MessageBox.Show("Inserta el nombre del equipo de hospital");
            }
            else
            {
                if (txtDescripcion.Text == "")
                {
                    System.Windows.MessageBox.Show("Inserta la Descripción");
                }
                else
                {
                    if (txtCosto.Text == "")
                    {
                        System.Windows.MessageBox.Show("Inserta el Costo");
                    }
                    else
                    {

                        DateTime fec = DateTime.Now;
                        var equipoh = BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.Find(ideh);

                        equipoh.NOM_EQUIPO_HOSPITAL = txtNombre.Text;
                        equipoh.DESCRIPCION = txtDescripcion.Text;
                        equipoh.COSTO = Decimal.Parse(txtCosto.Text);
                        equipoh.FECHA_MOD = fec;

                        BaseDatos.GetBaseDatos().SaveChanges();
                        MessageBoxResult result = MessageBox.Show("Registro exitoso se Actualizo correctamente ");
                        Limpiar();
                        this.Close();

                    }
                }
            }
        }

        void Limpiar()
        {
            txtNombre.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCosto.Text = String.Empty;
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            Guardar();

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

            //ConsultaCatalogoEquipoHospital cequipoh = new ConsultaCatalogoEquipoHospital();
            //cequipoh.Show();
            this.Close();
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

            if (ascci >= 46 && ascci <= 57) e.Handled = false;

            else e.Handled = true;

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }
    }
}
