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

namespace Medica2.Farmacia.Proveedores
{
    /// <summary>
    /// Lógica de interacción para MostrarProveedores.xaml
    /// </summary>
    public partial class MostrarProveedores : Window
    {
        BaseDatos prov;
        public MostrarProveedores()
        {
            prov = new BaseDatos();
            InitializeComponent();
            vistaProveedores.ItemsSource = prov.vista_proveedores.ToList();
        }
    }
}
