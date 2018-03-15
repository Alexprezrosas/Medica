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

namespace Medica2.Administracion.Especialidades
{
    /// <summary>
    /// Lógica de interacción para ConsultarCatalogoEspecialidades.xaml
    /// </summary>
    public partial class ConsultarCatalogoEspecialidades : Window
    {
        BaseDatos ms;
        public ConsultarCatalogoEspecialidades()
        {
            InitializeComponent();
            ms = new BaseDatos();
            RadEspecialidades.ItemsSource = ms.CATALOGO_ESPECIALIDADES.ToList();
        }
    }
}