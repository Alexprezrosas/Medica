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

namespace Medica2.Administracion
{
    /// <summary>
    /// Lógica de interacción para ConsultaCatalogCirugias.xaml
    /// </summary>
    public partial class ConsultaCatalogCirugias : Window
    {
        BaseDatos ms;
        public ConsultaCatalogCirugias()
        {
            InitializeComponent();
            ms = new BaseDatos();
            radCatalogoCirugias.ItemsSource = ms.CATALOGO_CIRUGIAS.ToList();
        }
    }
}