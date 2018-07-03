using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medica2.Farmacia.Ventas.Reportes
{
    public partial class RVentasGenerales : Form
    {
        public RVentasGenerales()
        {
            InitializeComponent();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}
