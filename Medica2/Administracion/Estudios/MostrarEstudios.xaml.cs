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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.GridView.SearchPanel;
using Telerik.Windows.Data;

namespace Medica2.Administracion.Estudios
{
    /// <summary>
    /// Lógica de interacción para MostrarEstudios.xaml
    /// </summary>
    public partial class MostrarEstudios : Window
    {
        public MostrarEstudios()
        {
            InitializeComponent();


            AverageFunction a = new AverageFunction();
            ((GridViewDataColumn)this.rdgvMostrarEstudio.Columns["COSTO"]).AggregateFunctions.Add(a);



            //Nuevo CAmpo en GRid
            //LocalizationManager.Manager = new CustomLocalizationManager();
            //----

            rdgvMostrarEstudio.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.ToList();

            //para editar

            this.rdgvMostrarEstudio.CellEditEnded += radGridView_CellEditEnded;

            //---
            //para Validar
            this.rdgvMostrarEstudio.CellValidating += radGridView_CellValidatingCosto;
            this.rdgvMostrarEstudio.RowValidating += radGridView_RowValidating;
            //
            //Panel de busqueda
            this.rdgvMostrarEstudio.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
            //


        }
        void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, this.rdgvMostrarEstudio.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }
        private void radGridView_CellValidating(object sender, GridViewCellValidatingEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "COSTO")
            {
                int newValue = Int32.Parse(e.NewValue.ToString());
                if (newValue < 0)
                {
                    e.IsValid = false;
                    e.ErrorMessage = "El valor ingresado debe ser mayor que 0";
                }
            }
        }
        private void radGridView_CellValidatingCosto(object sender, Telerik.Windows.Controls.GridViewCellValidatingEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "COSTO")
            {
                if (e.NewValue.ToString().Length < 3)
                {
                    e.IsValid = false;
                    e.ErrorMessage = "debe ser mayor de 100 pesos";
                }
            }
        }

        private void radGridView_RowValidating(object sender, Telerik.Windows.Controls.GridViewRowValidatingEventArgs e)
        {

            CATALOGO_ESTUDIOS order = e.Row.DataContext as CATALOGO_ESTUDIOS;
            if (String.IsNullOrEmpty(order.NOMBRE) || order.COSTO.Value < 3)
            {
                GridViewCellValidationResult validationResult = new GridViewCellValidationResult();
                validationResult.PropertyName = "NOMBRE";
                validationResult.ErrorMessage = "COSTO Rquiere ser mayor a 100 pesos";
                e.ValidationResults.Add(validationResult);
                e.IsValid = false;
            }

            if (order.COSTO < 0)
            {
                GridViewCellValidationResult validationResult = new GridViewCellValidationResult();
                validationResult.PropertyName = "COSTO";
                validationResult.ErrorMessage = "COSTO must be positive";
                e.ValidationResults.Add(validationResult);
                e.IsValid = false;
            }
        }
        private void validarLetras(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;


        }

        private void radGridView_CancelBeginningEdit(object sender, Telerik.Windows.Controls.GridViewBeginningEditRoutedEventArgs e)
        {
            e.Cancel = true;
        }

        private void clubsGrid_PreparingCellForEdit(object sender, GridViewPreparingCellForEditEventArgs e)
        {
            if ((string)e.Column.Header == "NOMBRE")
            {
                var tb = e.EditingElement as TextBox;
                tb.TextWrapping = TextWrapping.Wrap;
            }
        }
        private void radGridView_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            CATALOGO_ESTUDIOS editedestudio = e.Cell.DataContext as CATALOGO_ESTUDIOS;
            string propertyName = e.Cell.Column.UniqueName;
            //MessageBox.Show(string.Format("La propiedad: {0} está editada y el nuevo valor es:  {1}", propertyName, e.NewData));
            BaseDatos.GetBaseDatos().SaveChanges();
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
        private GridViewRow ClickedRow
        {
            get
            {
                return this.GridContextMenu2.GetClickedElement<GridViewRow>();
            }
        }

        private void GridContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            if (ClickedRow != null)
            {
                itemAgregar.IsEnabled = true;
                itemEliminar.IsEnabled = true;
            }
        }
        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemAgregar)
            {
                this.Close();
                NuevoEstudio nestud = new NuevoEstudio();
                nestud.Show();


            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar?", "Administración Cirugías", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            int idestudioo = (rdgvMostrarEstudio.SelectedItem as CATALOGO_ESTUDIOS).CATALOGO_ESTUDIO_ID;
                            if (rdgvMostrarEstudio.SelectedItem != null)
                            {
                                var cestu = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(idestudioo);
                                BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Remove(cestu);
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado", "Administración Estudios");
                            rdgvMostrarEstudio.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.ToList();
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
            }
        }
    }
}
