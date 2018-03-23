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

namespace Medica2.Administracion.Cuartos
{
    /// <summary>
    /// Lógica de interacción para CatalogoCuartos.xaml
    /// </summary>
    public partial class CatalogoCuartos : Window
    {
        
        public CatalogoCuartos()
        {
            InitializeComponent();
            FormCatalogoCuarto.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_CUARTOS.ToList();
        }
    }
}

    
