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
    /// Lógica de interacción para Medicamentos.xaml
    /// </summary>
    public partial class Medicamentos : Window
    {
        public Medicamentos()
        {
            InitializeComponent();
            forMedicamentos.ItemsSource = CargarSiloeBD.getDB().CATALOGO_MEDICAMENTOS.ToList();
        }
    }
}
