using AccessoDB;
using Medica2.Farmacia.Medicamentos;
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

namespace Medica2.Farmacia.Conversion
{
    /// <summary>
    /// Lógica de interacción para RegistroConversion.xaml
    /// </summary>
    public partial class RegistroConversion : Window
    {
        public RegistroConversion()
        {
            InitializeComponent();
            autoMedicamentoOrigen.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.ToList();
            autoMedicamentoDestino.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.ToList();
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

            if (ascci >= 4 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void validarNumLetras(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 46)

                e.Handled = false;

            else e.Handled = true;
        }

        void limpiar()
        {
            autoMedicamentoOrigen.SearchText = String.Empty;
            txtUMedidaOrigen.Text = String.Empty;
            txtCantidadOrigen.Text = String.Empty;
            autoMedicamentoDestino.SearchText = String.Empty;
            txtUMedidaDestino.Text = String.Empty;
            txtCantidadDestino.Text = String.Empty;
            txtExistencias.Text = String.Empty;
        }

        void GuardarConversion()
        {
            if (autoMedicamentoOrigen.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un medicamento de origen");
            }else
            {
                if (txtCantidadOrigen.Text == "")
                {
                    MessageBox.Show("Ingresa una cantidad de origen");
                }else
                {
                    if (autoMedicamentoDestino.SelectedItem == null)
                    {
                        MessageBox.Show("Selecciona un medicamento de destino");
                    }else
                    {
                        if (txtCantidadDestino.Text == "")
                        {
                            MessageBox.Show("Ingresa una cantidad de destino");
                        }else
                        {
                            int idmor = ((CATALOGO_MEDICAMENTOS)autoMedicamentoOrigen.SelectedItem).ID_MEDICAMENTO;
                            var mori = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmor);

                            if (mori.CANTIDAD <= 0)
                            {
                                MessageBox.Show("Ya no hay existencias");
                            }else
                            {
                                if (Convert.ToInt32(txtCantidadOrigen.Text) > mori.CANTIDAD)
                                {
                                    MessageBox.Show("No hay suficientes existencias");
                                }else
                                {
                                    mori.CANTIDAD = ((mori.CANTIDAD) - (int.Parse(txtCantidadOrigen.Text)));
                                    BaseDatos.GetBaseDatos().SaveChanges();

                                    int idmdes = ((CATALOGO_MEDICAMENTOS)autoMedicamentoDestino.SelectedItem).ID_MEDICAMENTO;
                                    var mdes = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmdes);
                                    mdes.CANTIDAD = mdes.CANTIDAD + Convert.ToInt32(txtCantidadDestino.Text);
                                    BaseDatos.GetBaseDatos().SaveChanges();
                                    MessageBox.Show("La conversion se realizo correctamente");
                                    limpiar();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void autoMedicamentoDestino_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (autoMedicamentoOrigen.SelectedItem != null)
            {
                int idmedi = ((CATALOGO_MEDICAMENTOS)autoMedicamentoDestino.SelectedItem).ID_MEDICAMENTO;
                var busquedamed = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmedi);
                txtUMedidaDestino.Text = Convert.ToString(busquedamed.U_MEDIDA);
                txtExistenciasDestino.Text = busquedamed.CANTIDAD.ToString();
                //
            }
        }

        private void autoMedicamentoOrigen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (autoMedicamentoOrigen.SelectedItem != null)
            {
                int idmedi = ((CATALOGO_MEDICAMENTOS)autoMedicamentoOrigen.SelectedItem).ID_MEDICAMENTO;
                var busquedamed = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmedi);
                txtUMedidaOrigen.Text = Convert.ToString(busquedamed.U_MEDIDA);
                txtExistencias.Text = busquedamed.CANTIDAD.ToString();
                //
            }
        }

        private void btnConvertir_Click(object sender, RoutedEventArgs e)
        {
            GuardarConversion();
        }

        private void btnNuevoMedicamento_Click(object sender, RoutedEventArgs e)
        {
            RegistroMedicamento rm = new RegistroMedicamento(autoMedicamentoDestino);
            rm.Show();
        }
    }
}
