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
using System.Windows.Forms;

namespace Medica2.Farmacia.Materiales
{
    /// <summary>
    /// Lógica de interacción para NuevoMaterial.xaml
    /// </summary>
    public partial class NuevoMaterial : Window
    {
        BaseDatos mat;

        public NuevoMaterial()
        {
            InitializeComponent();
            mat = new BaseDatos();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nombre, comentario, cantidad, costo, codbarras;
            int barras, cantidadMat;
            DateTime fec = DateTime.Now;
            Decimal cos;


            nombre = txtNombre.Text;
            comentario = txtComentario.Text;
            cantidad = txtCantidad.Text;
            costo = txtCosto.Text;
            //fcreacion = dpFecCreacion.Text;
            codbarras = txtCodBarras.Text;

            cos = Decimal.Parse(costo);
            barras = Int32.Parse(codbarras);
            cantidadMat = Int32.Parse(cantidad);

            CATALOGO_MATERIALES cc = new CATALOGO_MATERIALES
            {
                NOMBRE = nombre,
                CANTIDAD = cantidadMat,
                COMENTARIO = comentario,
                COSTO = cos,
                FECHA_CREACION = fec,
                COD_BARRAS = barras
            };
            mat.CATALOGO_MATERIALES.Add(cc);
            mat.SaveChanges();
            //duy
            VizualizarMateriales.datagrid.ItemsSource = mat.CATALOGO_MATERIALES.ToList();
            //duy
            txtNombre.Text = String.Empty;
            txtComentario.Text = String.Empty;
            txtCosto.Text = String.Empty;
            txtCodBarras.Text = String.Empty;
            txtCantidad.Text = String.Empty;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
