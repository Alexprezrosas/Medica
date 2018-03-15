﻿
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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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
            FillEstados();
            Limpiar();
        }




        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Obtener los valores de los TextBox

            String edad;
            short ed;
            DateTime FechaRegistro = DateTime.Now;

            edad = cbbEdad.Text;
            ed = short.Parse(edad);
            

            //fechacrea.Text = DateTime.Now.ToString();
            //DateTime fechacre = fechacrea.GetValue();
            PERSONA cc = new PERSONA
            {
                NOMBRE = txtNombre.Text,
                A_PATERNO = txtPaterno.Text,
                A_MATERNO = txtMaterno.Text,
                EDAD = ed,
                SEXO = cbbSexo.Text,
                CALLE = txtCalle.Text,
                LOCALIDAD = Convert.ToInt32(comboBoxLocalidades.SelectedValue),
                MUNICIPIO = Convert.ToInt32(comboBoxMunicipios.SelectedValue),
                ESTADO = Convert.ToInt32(comboBoxEstado.SelectedValue),
                T_CELULAR = txtCelular.Text,
                CURP = txtCurp.Text,
                FECHA_CREACION = FechaRegistro
            };
            pr.PERSONAS.Add(cc);
            pr.SaveChanges();
            //cc = pr.PERSONAS.Last();
            
            

            PROVEEDORE prv = new PROVEEDORE
            {
                PERSONAID = cc.ID_PERSONA,
                RFC = txtRfc.Text,
                REFERENCIA = txtReferencia.Text,
                FECHA_CREACION = FechaRegistro
            };
            prv.PERSONA = cc;
            pr.PROVEEDORES.Add(prv);
            pr.SaveChanges();
            //Mensaje
            MessageBoxResult result = MessageBox.Show("Se guardo correctamente el proveedor", "Registro exitoso");

            //Limpiar los textBox
            Limpiar();

        }

        public void Limpiar()
        {
            txtNombre.Text = String.Empty;
            txtPaterno.Text = String.Empty;
            txtMaterno.Text = String.Empty;
            txtCalle.Text = String.Empty;
            txtCelular.Text = String.Empty;
            txtCurp.Text = String.Empty;
            txtRfc.Text = String.Empty;
            txtReferencia.Text = String.Empty;
            cbbEdad.SelectedIndex = -1;
            cbbSexo.SelectedIndex = -1;
            comboBoxEstado.SelectedIndex = -1;

        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        //Llenado de Combobox Estado

        public void FillEstados()
        {
            BaseDatos obj = new BaseDatos();
            List<ESTADO> lst = obj.ESTADOS.ToList();
            comboBoxEstado.ItemsSource = lst;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int EstadosId = Convert.ToInt32(comboBoxEstado.SelectedValue);
            BaseDatos obj1 = new BaseDatos();
            List<MUNICIPIO> lst1 = obj1.MUNICIPIOS.Where(x => x.estado_id == EstadosId).ToList();
            comboBoxMunicipios.ItemsSource = lst1;

        }

        private void comboBox_SelectionChangedL(object sender, SelectionChangedEventArgs e)
        {
            int Municipiosid = Convert.ToInt32(comboBoxMunicipios.SelectedValue);
            BaseDatos obj2 = new BaseDatos();
            List<LOCALIDADE> lst1 = obj2.LOCALIDADES.Where(x => x.municipio_id == Municipiosid).ToList();
            comboBoxLocalidades.ItemsSource = lst1;

        }



    }

    
}