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

namespace Medica2.Administracion.EspecialidadesEnfermeras
{
    /// <summary>
    /// Lógica de interacción para CatalogoEspecialidadesEnfermeras.xaml
    /// </summary>
    public partial class CatalogoEspecialidadesEnfermeras : Window
    {
        public CatalogoEspecialidadesEnfermeras()
        {
            InitializeComponent();
            FormEspecialidadesEnfermeras.ItemsSource = CargarSiloeBD.getDB().CATALOGO_ESPECIALIDADES_ENFERMERAS.ToList();
        }
    }
}
