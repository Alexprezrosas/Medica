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
        BaseDatos medi;
        public NuevoMedicamento()
        {
            InitializeComponent();
            medi = new BaseDatos();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            DateTime fec = DateTime.Now;


            CATALOGO_MEDICAMENTOS cc = new CATALOGO_MEDICAMENTOS
            {
                NOMBRE_MEDI = txtNombre.Text,
                CANTIDAD = Int32.Parse(txtCantidad.Text),
                COMENTARIO = txtComentario.Text,
                P_VENTA = Decimal.Parse(txtPVenta.Text),
                P_HOSPITAL = Decimal.Parse(txtPHospital.Text),
                P_PUBLICO = Decimal.Parse(txtPPublico.Text),
                DESCUENTO = Decimal.Parse(txtDescuento.Text),
                CADUCIDAD = dpCaducidad.SelectedDate,
                FECHA_CREACION = fec,
                COD_BARRAS = Int32.Parse(txtCodBarras.Text)
            };
            medi.CATALOGO_MEDICAMENTOS.Add(cc);
            medi.SaveChanges();
        }

        private void dpCaducidad_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
