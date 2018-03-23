using AccessoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Medica2
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        
        public Login()
        {
            InitializeComponent();
           
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (txtUsuario.Text != string.Empty && pssPassword.Password != string.Empty)
            {
                var usu = BaseDatos.GetBaseDatos().PERSONAS.FirstOrDefault(a => a.NOMBRE.Equals(txtUsuario.Text));
                var usu1 = BaseDatos.GetBaseDatos().USUARIOS.FirstOrDefault(a => a.CONTRASENA.Equals(pssPassword.Password));
                if (usu1 != null)
                {
                    if (usu1.CONTRASENA.Equals(pssPassword.Password))
                    {
                        MainWindow main = new MainWindow();
                        main.Show();
                    }
                    else
                        MessageBox.Show("Contraseña incorrecta");
                }
                else
                    MessageBox.Show("Contraseña incorrecta");
            }else
                MessageBox.Show("Favor de llenar los campos");
            

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
