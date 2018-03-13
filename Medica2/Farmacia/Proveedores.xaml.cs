
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Medica2.Farmacia
{
    /// <summary>
    /// Lógica de interacción para Proveedores.xaml
    /// </summary>
    public partial class Proveedores : Window
    {

        BaseDatos pr;
 
        public Proveedores()
        {
            InitializeComponent();
            pr = new BaseDatos();

        }




        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Obtener los valores de los TextBox

            String nombre, apaterno, amaterno, sexo, calle, celular, curp, referencia, rfc;
            String edad, localidad, municipio, estado;
            int edadd, localidadd, municipiod, estadod;
            short ed;

            nombre = txtNombre.Text;
            apaterno = txtPaterno.Text;
            amaterno = txtMaterno.Text;

            edad = cbbEdad.Text;
            ed = short.Parse(edad);

            sexo = cbbSexo.Text;
            calle = txtCalle.Text;
            municipio = txtMunicipio.Text;
            municipiod = Int32.Parse(municipio);
            estado = txtEstado.Text;
            estadod = Int32.Parse(estado);

            localidad = txtLocalidad.Text;
            localidadd = Int32.Parse(localidad);

            celular = txtCelular.Text;
            curp = txtCurp.Text;
            referencia = txtReferencia.Text;
            rfc = txtRfc.Text;

            //fechacrea.Text = DateTime.Now.ToString();
            //DateTime fechacre = fechacrea.GetValue();
            PERSONA cc = new PERSONA { NOMBRE = nombre, A_PATERNO = apaterno, A_MATERNO = amaterno,
                EDAD = ed, SEXO = sexo, CALLE = calle, LOCALIDAD = localidadd, MUNICIPIO = municipiod,
                ESTADO = estadod, T_CELULAR = celular, CURP = curp};
            pr.PERSONAS.Add(cc);
            pr.SaveChanges();
            //cc = pr.PERSONAS.Last();
            

            PROVEEDORE prv = new PROVEEDORE { PERSONAID = cc.ID_PERSONA, RFC = rfc, REFERENCIA = referencia };
            prv.PERSONA = cc;
            pr.PROVEEDORES.Add(prv);
            pr.SaveChanges();

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
}
