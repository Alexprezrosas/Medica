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
            LlenarGrid();

        }

        void LlenarGrid()
        {
            rdgvMostrarEstudio.ItemsSource = (from cates in BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS
                                              join newcla in BaseDatos.GetBaseDatos().CLASIFICACION_ESTUDIOS
                                              on cates.CLASIFICACIONID equals newcla.CLASIFICACIONID
                                              where cates.STATUS == "Activo"
                                              select new
                                              {
                                                  ID_CESTU = cates.CATALOGO_ESTUDIO_ID,
                                                  ID_CLASI = newcla.CLASIFICACIONID,

                                                  CATENOM = cates.NOMBRE,
                                                  CATEDESC = cates.DESCRIPCION,
                                                  CATECOSTO = cates.COSTO,
                                                  CLASIESTU = newcla.NOMBRE,
                                                  FECHAC = cates.FECHA_CREACION

                                              });
        }
        void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, this.rdgvMostrarEstudio.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        private void radGridView_CellValidatingCosto(object sender, Telerik.Windows.Controls.GridViewCellValidatingEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "COSTO")
            {
                if (e.NewValue.ToString().Length < 3)
                {
                    e.IsValid = false;
                    e.ErrorMessage = "Debe ser mayor de 100 pesos";
                }
            }
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
                this.Close();
                NuevoEstudio nestud = new NuevoEstudio();
                nestud.Show();


            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar?", "Administración Estudios", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            dynamic ctaestu = rdgvMostrarEstudio.SelectedItem;
                            int idcatalog = ctaestu.ID_CESTU;

                            //int idestudioo = (rdgvMostrarEstudio.SelectedItem as CATALOGO_ESTUDIOS).CATALOGO_ESTUDIO_ID;
                            if (rdgvMostrarEstudio.SelectedItem != null)
                            {
                                var cestu = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(idcatalog);
                                cestu.STATUS = "Inactivo";
                                //BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Remove(cestu);
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado el Estudio", "Administración Estudios");
                            LlenarGrid();
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }
                else
                {
                    if (sender == itemEditar)
                    {
                        if (rdgvMostrarEstudio.SelectedItem != null)
                        {
                            dynamic objce = rdgvMostrarEstudio.SelectedItem;
                            int idce = objce.ID_CESTU;
                            int idclasifi = objce.ID_CLASI;

                            var idcestu = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(idce);
                            var idclasifica = BaseDatos.GetBaseDatos().CLASIFICACION_ESTUDIOS.Find(idclasifi);

                            NuevoEstudio nempl = new NuevoEstudio((CATALOGO_ESTUDIOS)idcestu, (CLASIFICACION_ESTUDIOS)idclasifica, false);
                            nempl.Show();
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
