﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medica2.Farmacia.Proveedores.Reportes
{
    public partial class RProveedores : Form
    {
        public RProveedores()
        {
            InitializeComponent();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}
