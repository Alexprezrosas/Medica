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

namespace Medica2.Farmacia.Materiales
{
    /// <summary>
    /// Lógica de interacción para SolicitudEnfermera.xaml
    /// </summary>
    public partial class SolicitudEnfermera : Window
    {
        public SolicitudEnfermera()
        {
            InitializeComponent();
            autoEnfermera.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                            join e in BaseDatos.GetBaseDatos().ENFERMERAS
                                            on PERSONA.ID_PERSONA equals e.PERSONAID
                                            select new
                                            {
                                                ID_ENFERMERA = e.ID_ENFERMERA,
                                                NOMBRE = PERSONA.NOMBRE
                                            });
            autoMaterial.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_MATERIALES.ToList();
        }

        void GuardarMaterial()
        {
            if (autoEnfermera != null)
            {
                if (autoMaterial != null)
                {
                    if (txtCantidad.Text != "")
                    {
                        DETALLE_MATER_ENFERMERAS dmen = new DETALLE_MATER_ENFERMERAS
                        {
                            //MATERIALID = ,
                            //CANTIDAD = Int32.Parse(txtCantidad.Text),
                            //COSTO = Decimal.Parse(txt,
                            //FECHA_CREACION = 
                        };
                    }
                    else
                    {
                        MessageBox.Show("Asignar una cantidad");
                    }
                }
                else
                {
                    MessageBox.Show("Asignar un material");
                }
            }else
            {
                MessageBox.Show("Asignar una enfermera");
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            GuardarMaterial();

            dynamic obj = autoEnfermera.SelectedItem;
            
            int idmat = ((CATALOGO_MATERIALES)autoMaterial.SelectedItem).ID_CATALOGO_MATERIAL;

            int idenf = obj.ID_ENFERMERA;

            String material = autoMaterial.SelectedItem.ToString();
            //var mat = autoMaterial.TextSearchPath;
            MessageBox.Show("" + material);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
