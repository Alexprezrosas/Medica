using AccessoDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Lógica de interacción para MostrarProveedores.xaml
    /// </summary>
    public partial class MostrarProveedores : Window
    {
        
        
        public MostrarProveedores()
        {

            InitializeComponent();

            //PROVEEDORE obj  = BaseDatos.GetBaseDatos().PROVEEDORES
            //    .Where(p=>p.ID_PROVEEDOR==1004)
            //    .Include(p => p.PERSONA)
            //    .FirstOrDefault();

            //vistaProveedores.Items.Add(obj);

            vistaProveedores.ItemsSource = BaseDatos.GetBaseDatos().PROVEEDORES.ToList();
        }

        private void buttoneditar_Click(object sender, RoutedEventArgs e)
        {
            if(vistaProveedores.SelectedItem != null)
            {
                Proveedores p = new Proveedores(
                    (PROVEEDORE)vistaProveedores.SelectedItem,false);
                p.Show();

            }

        }
    }
}
