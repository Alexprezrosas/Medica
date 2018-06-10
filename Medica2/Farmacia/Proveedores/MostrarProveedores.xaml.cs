using AccessoDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Medica2.Farmacia.Proveedores
{
    /// <summary>
    /// Lógica de interacción para MostrarProveedores.xaml
    /// </summary>
    public partial class MostrarProveedores : Window
    {
        
        
        public MostrarProveedores()
        {

            InitializeComponent();

            VistaProveedoresPersonas();

            vistaProveedores.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, vistaProveedores.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
            }
        }

        public void VistaProveedoresPersonas()
        {
            vistaProveedores.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                            join e in BaseDatos.GetBaseDatos().PROVEEDORES
                                            on PERSONA.ID_PERSONA equals e.PERSONAID
                                            join esta in BaseDatos.GetBaseDatos().ESTADOS
                                            on PERSONA.ESTADO equals esta.id
                                            select new
                                            {
                                                ID_PROVEEDOR = e.ID_PROVEEDOR,
                                                NOMBRE = PERSONA.NOMBRE,
                                                APATERNO = PERSONA.A_PATERNO,
                                                AMATERNO = PERSONA.A_MATERNO,
                                                SEXO = PERSONA.SEXO,
                                                F_NACIMIENTO = PERSONA.F_NACIMIENTO,
                                                CALLE = PERSONA.CALLE,
                                                ESTADOO = esta.nombre,
                                                MUNICIPIOO = PERSONA.NOMMUNICIPIO,
                                                LOCALIDADD = PERSONA.NOMLOCALIDAD,
                                                TELEFONO = e.PERSONA.T_CELULAR,
                                                CURP = PERSONA.CURP,
                                                RFC = e.RFC,
                                                NOTA = e.NOTA
                                            }).ToList();
        }

        private void buttoneditar_Click(object sender, RoutedEventArgs e)
        {
            //if(vistaProveedores.SelectedItem != null)
            //{
            //    Proveedores p = new Proveedores(
            //        (PROVEEDORE)vistaProveedores.SelectedItem,false);
            //    p.Show();

            //}

        }

        /////////////////////
        
        private void MostrarEnfermeras_SelectedCellsChanged(object sender, Telerik.Windows.Controls.GridView.GridViewSelectedCellsChangedEventArgs e)
        {
            BaseDatos.GetBaseDatos().SaveChanges();
        }

        //
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
                RegistroProveedor prov = new RegistroProveedor();
                prov.Show();
                this.Close();

            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar e; proveedor?", "Farmacia", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            dynamic idprove = vistaProveedores.SelectedItem;
                            int idp = idprove.ID_PROVEEDOR;

                            if (vistaProveedores.SelectedItem != null)
                            {
                                var cenfer = BaseDatos.GetBaseDatos().PROVEEDORES.Find(idp);
                                BaseDatos.GetBaseDatos().PROVEEDORES.Remove(cenfer);
                                BaseDatos.GetBaseDatos().SaveChanges();
                            }
                            MessageBox.Show("Se ha eliminado el proveedor", "Farmacia");
                            VistaProveedoresPersonas();

                            ////
                            
                            break;

                        case MessageBoxResult.No:

                            break;
                    }
                }else
                {
                    if (sender == itemEditar)
                    {
                        if (vistaProveedores.SelectedItem != null)
                        {
                            dynamic idprove = vistaProveedores.SelectedItem;
                            int idp = idprove.ID_PROVEEDOR;
                            var p = BaseDatos.GetBaseDatos().PROVEEDORES.Find(idp);
                            RegistroProveedor pr = new RegistroProveedor(
                                (PROVEEDORE)p, false);
                            pr.Show();
                            this.Close();
                            
                        }
                    }
                }
            }
        }
    
    //

    }
}
