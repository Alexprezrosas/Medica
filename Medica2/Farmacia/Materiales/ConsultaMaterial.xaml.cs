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
    /// Lógica de interacción para ConsultaMaterial.xaml
    /// </summary>
    public partial class ConsultaMaterial : Window
    {

        
        public ConsultaMaterial()
        {
            InitializeComponent();
            MostrarMateriales.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_MATERIALES.ToList();
        }
        
        
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ///////////////
            MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el material?", "Farmacia Materiales", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    int idmat = (MostrarMateriales.SelectedItem as CATALOGO_MATERIALES).ID_CATALOGO_MATERIAL;
                    if (MostrarMateriales.SelectedItem != null)
                    {
                        var cmatt = BaseDatos.GetBaseDatos().CATALOGO_MATERIALES.Find(idmat);
                        BaseDatos.GetBaseDatos().CATALOGO_MATERIALES.Remove(cmatt);
                        BaseDatos.GetBaseDatos().SaveChanges();
                    }
                    MessageBox.Show("Se ha eliminado el material", "Farmacia Materiales");
                    MostrarMateriales.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_MATERIALES.ToList();
                    break;

                case MessageBoxResult.No:
                    
                    break;
            }

            ///////////////

            

           
            



        }

        private void MostrarMateriales_SelectedCellsChanged(object sender, Telerik.Windows.Controls.GridView.GridViewSelectedCellsChangedEventArgs e)
        {
            BaseDatos.GetBaseDatos().SaveChanges();
        }

        
        private void validarLetras(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        private void validarNumeros(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;

        }

        private void validarDecimal(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else if (e.Key == Key.Decimal)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void GridViewDataColumn_Error(object sender, ValidationErrorEventArgs e)
        {

        }
    }
}
