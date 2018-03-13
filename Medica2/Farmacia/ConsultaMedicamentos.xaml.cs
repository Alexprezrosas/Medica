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
    /// Lógica de interacción para ConsultaMedicamentos.xaml
    /// </summary>
    public partial class ConsultaMedicamentos : Window
    {
        BaseDatos ms;
        public ConsultaMedicamentos()
        {
            InitializeComponent();
            ms = new BaseDatos();
            radMedicamentos.ItemsSource = ms.CATALOGO_MEDICAMENTOS.ToList();
        }
    }
}
