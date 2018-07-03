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
            llenarAutocompletes();
        }

        void llenarAutocompletes()
        {
            autoMedicamentoOrigen.ItemsSource = (from medi in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                                 where medi.STATUS == "Activo"
                                                 select new
                                                 {
                                                     ID_MEDICAMENTO = medi.ID_MEDICAMENTO,
                                                     NOMBRE = medi.NOMBRE_MEDI + " " + medi.COMENTARIO + " " + medi.U_MEDIDA
                                                 });

            autoMedicamentoDestino.ItemsSource = (from medic in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                                  where medic.STATUS == "Activo"
                                                  select new
                                                  {
                                                      ID_MEDICAMENTO = medic.ID_MEDICAMENTO,
                                                      NOMBRE = medic.NOMBRE_MEDI + " " + medic.COMENTARIO + " " + medic.U_MEDIDA
                                                  });


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
            autoMedicamentoOrigen.SelectedItem = null;
            txtUMedidaOrigen.Text = String.Empty;
            txtCantidadOrigen.Text = String.Empty;
            autoMedicamentoDestino.SearchText = String.Empty;
            autoMedicamentoDestino.SelectedItem = null;
            txtUMedidaDestino.Text = String.Empty;
            txtCantidadDestino.Text = String.Empty;
            txtExistencias.Text = String.Empty;
            txtExistenciasDestino.Text = String.Empty;
        }

        void GuardarConversion()
        {
            if (autoMedicamentoOrigen.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un medicamento de orígen");
            }else
            {
                if (txtCantidadOrigen.Text == "")
                {
                    MessageBox.Show("Ingresa una cantidad de orígen");
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
                            dynamic mediOri = autoMedicamentoOrigen.SelectedItem;
                            int idmor = mediOri.ID_MEDICAMENTO;
                            var mori = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmor);

                            if (mori.CANTIDAD <= 0)
                            {
                                MessageBox.Show("No se cuenta con existencias");
                            }else
                            {
                                if (Convert.ToInt32(txtCantidadOrigen.Text) > mori.CANTIDAD)
                                {
                                    MessageBox.Show("No hay suficientes existencias");
                                }else
                                {
                                    mori.CANTIDAD = ((mori.CANTIDAD) - (int.Parse(txtCantidadOrigen.Text)));
                                    BaseDatos.GetBaseDatos().SaveChanges();

                                    dynamic mediDesti = autoMedicamentoDestino.SelectedItem;
                                    int idmdes = mediDesti.ID_MEDICAMENTO;
                                    var mdes = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmdes);
                                    mdes.CANTIDAD = mdes.CANTIDAD + Convert.ToInt32(txtCantidadDestino.Text);
                                    BaseDatos.GetBaseDatos().SaveChanges();
                                    MessageBox.Show("La conversion se realizó correctamente");
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
                dynamic medi = autoMedicamentoDestino.SelectedItem;
                int idmedi = medi.ID_MEDICAMENTO;
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
                dynamic medi = autoMedicamentoOrigen.SelectedItem;
                int idmedi = medi.ID_MEDICAMENTO;
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
            int med = 1;
            RegistroMedicamento rm = new RegistroMedicamento(autoMedicamentoDestino, med);
            rm.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
