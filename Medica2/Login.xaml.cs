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
        BaseDatos log;
        public Login()
        {
            InitializeComponent();
            log = new BaseDatos();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            USUARIO usr = new USUARIO { };
            PERSONA per = new PERSONA { };

            if (txtUsuario.Text.Length == 0)

            {

                MessageBoxResult result = MessageBox.Show("Inserta tu nombre de usuario", "Error");
            }else if (pssPassword.Password.Length == 0)
            {
                MessageBoxResult result = MessageBox.Show("Inserta tu password", "Error");
            }

            if (usr.CONTRASENA == pssPassword.Password)
            {
                if (per.NOMBRE == txtUsuario.Text)
                {
                    MainWindow pri = new MainWindow();
                    pri.Show();
                }
            }




            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
