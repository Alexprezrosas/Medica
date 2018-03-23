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

namespace Medica2.Farmacia.Proveedores
{
    /// <summary>
    /// Lógica de interacción para EditarProveedor.xaml
    /// </summary>
    public partial class EditarProveedor : Window
    {
        
        public EditarProveedor()
        {
            InitializeComponent();
            
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

            var prove = BaseDatos.GetBaseDatos().PROVEEDORES.Find(1004);
            prove.PERSONA.NOMBRE = "Holaaa";
            BaseDatos.GetBaseDatos().SaveChanges();
            

        }
    }
}
