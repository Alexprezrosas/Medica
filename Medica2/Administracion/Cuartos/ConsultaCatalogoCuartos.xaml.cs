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

namespace Medica2.Administracion.Cuartos
{
    /// <summary>
    /// Lógica de interacción para ConsultaCatalogoCuartos.xaml
    /// </summary>
    public partial class ConsultaCatalogoCuartos : Window
    {
        BaseDatos ms;
        public ConsultaCatalogoCuartos()
        {
            InitializeComponent();
            ms = new BaseDatos();
            RadConsultarCatalogoCuartos.ItemsSource = ms.CATALOGO_CUARTOS.ToList();
        }
    }
}
