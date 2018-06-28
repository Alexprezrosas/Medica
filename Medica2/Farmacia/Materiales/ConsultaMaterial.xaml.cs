using AccessoDB;
using Medica2.Farmacia.Medicamentos;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.GridView.SearchPanel;

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
            VistaGrid();
            rgvMostrarMateriales.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;

        }

        void VistaGrid()
        {
            rgvMostrarMateriales.ItemsSource = (from mate in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                                where mate.ALMACEN == "Materiales" && mate.STATUS == "Activo"
                                                select new
                                                {
                                                    ID_MEDICAMENTO = mate.ID_MEDICAMENTO,
                                                    NOMMEDI = mate.NOMBRE_MEDI,
                                                    DESCRIPCION = mate.COMENTARIO,
                                                    UMEDIDA = mate.U_MEDIDA,
                                                    COD_BARRAS = mate.COD_BARRAS,
                                                    P_VENTA = mate.P_VENTA,
                                                    P_COMPRA = mate.P_COMPRA,
                                                    P_MEDICOS = mate.P_MEDICOS,
                                                    CANTIDAD = mate.CANTIDAD,
                                                    CADUCIDAD = mate.CADUCIDAD,
                                                    CFDI = mate.CFDI,
                                                    F_REGISTRO = mate.FECHA_CREACION,
                                                    F_MOD = mate.FECHA_MOD,
                                                    ALMACEN = mate.ALMACEN
                                                });
        }

        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvMostrarMateriales.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
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

        private void validarPunto(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci == 46) e.Handled = false;

            else e.Handled = true;

        }


        /////

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
                itemEditar.IsEnabled = true;
            }
            
        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemAgregar)
            {
                RegistroMedicamento rm = new RegistroMedicamento();
                rm.Show();
                this.Close();
            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de eliminar el material?", "Farmacia Materiales", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            dynamic mater = rgvMostrarMateriales.SelectedItem;
                            int idmat = mater.ID_MEDICAMENTO;
                            if (rgvMostrarMateriales.SelectedItem != null)
                            {
                                var cmatt = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmat);
                                cmatt.STATUS = "Inactivo";
                                BaseDatos.GetBaseDatos().SaveChanges();
                                MessageBox.Show("Se eliminó el material", "Farmacia Materiales");
                                VistaGrid();
                            }
                            
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }else
                {
                    if (sender == itemEditar)
                    {
                        dynamic mate = rgvMostrarMateriales.SelectedItem;
                        int idmat = mate.ID_MEDICAMENTO;
                        NuevoMedicamento nm = new NuevoMedicamento(idmat);
                        nm.Show();
                        this.Close();
                    }
                }
            }
        }

        private void GridViewDataColumn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
                e.Handled = false;
            else if (e.Key == Key.Decimal)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void MostrarMateriales_CellValidating(object sender, Telerik.Windows.Controls.GridViewCellValidatingEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "COD_BARRAS")
            {
                //var newValue = Int32.Parse(e.NewValue.ToString());
                
                //if (newValue < 0 || newValue > 130)
                //{
                //    e.IsValid = false;
                //    e.ErrorMessage = "Solo enteros entre 0 y 130";
                //}
            } 
        }
    }
    
    
}
