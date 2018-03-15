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
    /// Lógica de interacción para Actualizar_Materiales.xaml
    /// </summary>
    public partial class Actualizar_Materiales : Window
    {
        BaseDatos db = new BaseDatos();
        int Id;
        public Actualizar_Materiales(int materialesId)
        {
            InitializeComponent();
            Id = materialesId;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            CATALOGO_MATERIALES actualiza = (from m in db.CATALOGO_MATERIALES
                                             where m.ID_CATALOGO_MATERIAL == Id
                                             select m).Single();
            db.SaveChanges();
            VizualizarMateriales.datagrid.ItemsSource = db.CATALOGO_MATERIALES.ToList();
        }

        
    }
}
