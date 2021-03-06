﻿using AccessoDB;
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

namespace Medica2.Farmacia.Medicamentos
{
    /// <summary>
    /// Lógica de interacción para ConsultaMedicamentos.xaml
    /// </summary>
    public partial class ConsultaMedicamentos : Window
    {
        int idUsuario;
        public ConsultaMedicamentos()
        {
            InitializeComponent();

            VistaGrid();

            rgvMedicamentos.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
        }

        public ConsultaMedicamentos(int idu)
        {
            InitializeComponent();
            VistaGrid();
            rgvMedicamentos.SearchPanelVisibilityChanged += RadGridView_SearchPanelVisibilityChanged;
            idUsuario = idu;
            var usuario = BaseDatos.GetBaseDatos().USUARIOS.Find(idu);
            if (usuario.EMPLEADO.PUESTO == "Administrador")
            {
                itemEliminar.Visibility = Visibility.Visible;
            }else
            {
                if (usuario.EMPLEADO.PUESTO == "Farmaceutico")
                {
                    itemEliminar.Visibility = Visibility.Hidden;
                }
            }
        }

        void VistaGrid()
        {
            rgvMedicamentos.ItemsSource = (from medic in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                           where medic.STATUS == "Activo"
                                           select new
                                           {
                                               ID_MEDICAMENTO = medic.ID_MEDICAMENTO,
                                               NOMMEDI = medic.NOMBRE_MEDI,
                                               DESCRIPCION = medic.COMENTARIO,
                                               UMEDIDA = medic.U_MEDIDA,
                                               COD_BARRAS = medic.COD_BARRAS,
                                               P_VENTA = medic.P_VENTA,
                                               P_COMPRA = medic.P_COMPRA,
                                               P_MEDICOS = medic.P_MEDICOS,
                                               CANTIDAD = medic.CANTIDAD,
                                               CADUCIDAD = medic.CADUCIDAD,
                                               CFDI = medic.CFDI,
                                               F_REGISTRO = medic.FECHA_CREACION,
                                               F_MOD = medic.FECHA_MOD,
                                               ALMACEN = medic.ALMACEN
                                           });
        }

        private void RadGridView_SearchPanelVisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.NewVisibility == Visibility.Collapsed)
            {
                var clearSearchValue = GridViewSearchPanelCommands.ClearSearchValue as RoutedUICommand;
                clearSearchValue.Execute(null, rgvMedicamentos.ChildrenOfType<GridViewSearchPanel>().FirstOrDefault());
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

        private void validarPunto(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci == 46) e.Handled = false;

            else e.Handled = true;

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
                itemEditar.IsEnabled = true;
                itemEliminar.IsEnabled = true;
            }

        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemAgregar)
            {
                RegistroMedicamento nmed = new RegistroMedicamento();
                nmed.Show();
                VistaGrid();

            }
            else
            {
                if (sender == itemEliminar)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de eliminar el medicamento?", "Farmacia Medicamentos", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            dynamic medi = rgvMedicamentos.SelectedItem;
                            int idmed = medi.ID_MEDICAMENTO;
                            if (rgvMedicamentos.SelectedItem != null)
                            {
                                var cmed = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmed);
                                cmed.STATUS = "Inactivo";
                                BaseDatos.GetBaseDatos().SaveChanges();
                                MessageBox.Show("Se eliminó el medicamento", "Farmacia Medicamentos");
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
                        dynamic medic = rgvMedicamentos.SelectedItem;
                        int idmed = medic.ID_MEDICAMENTO;
                        NuevoMedicamento nm = new NuevoMedicamento(idmed);
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

    }
}
