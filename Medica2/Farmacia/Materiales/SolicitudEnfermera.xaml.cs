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

namespace Medica2.Farmacia.Materiales
{
    /// <summary>
    /// Lógica de interacción para SolicitudEnfermera.xaml
    /// </summary>
    public partial class SolicitudEnfermera : Window
    {
        BaseDatos enf;
        public SolicitudEnfermera()
        {
            InitializeComponent();
            enf = new BaseDatos();
        }
    }
}
