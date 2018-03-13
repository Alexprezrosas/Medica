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

namespace Medica2.Farmacia
{
    /// <summary>
    /// Lógica de interacción para ConsultaProveedores.xaml
    /// </summary>
    public partial class ConsultaProveedores : Window
    {
        BaseDatos ms;
        public ConsultaProveedores()
        {
            InitializeComponent();
            ms = new BaseDatos();
            radProveedores.ItemsSource = ms.PROVEEDORES.ToList();
        }
    }
}
