﻿using System;
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

namespace Medica2.Administracion.EquipoHospital
{
    /// <summary>
    /// Lógica de interacción para CatalogoEquipoHospital.xaml
    /// </summary>
    public partial class CatalogoEquipoHospital : Window
    {
        public CatalogoEquipoHospital()
        {
            InitializeComponent();
            FormCatalogoEqiopoH.ItemsSource = CargarSiloeBD.getDB().CATALOGO_EQUIPO_HOSPITAL.ToList();
        }
    }
}
