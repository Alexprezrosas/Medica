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

namespace Medica2.Administracion.Cirugias
{
    /// <summary>
    /// Lógica de interacción para CatalogoCirugias.xaml
    /// </summary>
    public partial class CatalogoCirugias : Window
    {
        public CatalogoCirugias()
        {
            InitializeComponent();
          
                 formcatalogocirugia.ItemsSource = CargarSiloeBD.getDB().CATALOGO_CIRUGIAS.ToList();
        }
    }
}
