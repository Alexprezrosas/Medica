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
    /// Lógica de interacción para VizualizarMateriales.xaml
    /// </summary>
    public partial class VizualizarMateriales : Window
    {
        BaseDatos db = new BaseDatos();
        public static DataGrid datagrid;

        public VizualizarMateriales()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            myDataGrid.ItemsSource = db.CATALOGO_MATERIALES.ToList();
            datagrid = myDataGrid;
        }

        private void InsertarBtn_Click(object sender, RoutedEventArgs e)
        {
            NuevoMaterial numa = new NuevoMaterial();
            numa.ShowDialog();
        }

        private void ActualizarBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as CATALOGO_MATERIALES).ID_CATALOGO_MATERIAL;
            Actualizar_Materiales actualiza = new Actualizar_Materiales(Id);
            actualiza.ShowDialog();
        }

        private void EliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as CATALOGO_MATERIALES).ID_CATALOGO_MATERIAL;
            var eliminamaterial = db.CATALOGO_MATERIALES.Where(m => m.ID_CATALOGO_MATERIAL == Id).Single();
            db.CATALOGO_MATERIALES.Remove(eliminamaterial);
            db.SaveChanges();
            myDataGrid.ItemsSource = db.CATALOGO_MATERIALES.ToList();
        }
    }
}
