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

namespace Medica2.Farmacia.Medicamentos
{
    /// <summary>
    /// Lógica de interacción para NuevoMedicamento.xaml
    /// </summary>
    public partial class NuevoMedicamento : Window
    {
        
        public NuevoMedicamento()
        {
            InitializeComponent();
            
            Limpiar();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            DateTime fec = DateTime.Now;


            CATALOGO_MEDICAMENTOS cm = new CATALOGO_MEDICAMENTOS
            {
                NOMBRE_MEDI = txtNombre.Text,
                CANTIDAD = Int32.Parse(txtCantidad.Text),
                COMENTARIO = txtComentario.Text,
                P_VENTA = Decimal.Parse(txtPVenta.Text),
                P_COMPRA = Decimal.Parse(txtPHospital.Text),
                P_MEDICOS = Decimal.Parse(txtPPublico.Text),
                DESCUENTO = Decimal.Parse(txtDescuento.Text),
                CADUCIDAD = dpCaducidad.SelectedDate,
                FECHA_CREACION = fec,
                COD_BARRAS = Int32.Parse(txtCodBarras.Text)
            };
            BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Add(cm);
            BaseDatos.GetBaseDatos().SaveChanges();
            MessageBoxResult result = MessageBox.Show("Se guardo correctamente el medicamento", "Registro exitoso");
            Limpiar();
        }
        

        public void Limpiar()
        {
            txtNombre.Text = String.Empty;
            txtCantidad.Text = String.Empty;
            txtComentario.Text = String.Empty;
            txtPVenta.Text = String.Empty;
            txtPHospital.Text = String.Empty;
            txtPPublico.Text = String.Empty;
            txtDescuento.Text = String.Empty;
            txtCodBarras.Text = String.Empty;

        }

        
    }
}
