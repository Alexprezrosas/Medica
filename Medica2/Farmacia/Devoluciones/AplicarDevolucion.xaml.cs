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
using Telerik.Windows.Controls.GridView;

namespace Medica2.Farmacia.Devoluciones
{
    /// <summary>
    /// Lógica de interacción para AplicarDevolucion.xaml
    /// </summary>
    public partial class AplicarDevolucion : Window
    {
        int idpaciente;
        int idcuenta;
        public AplicarDevolucion()
        {
            InitializeComponent();
        }
        int cantidad;
        int idmed;
        DateTime fechareg = DateTime.Now;
        int iddetalle;
        int nexi;

        public AplicarDevolucion(int idpac, String cuarto, int idcuen)
        {
            InitializeComponent();
            idpaciente = idpac;
            idcuenta = idcuen;

            //Asignacion de cuarto y paciente
            txtCuarto.Text = cuarto;
            var pacie = BaseDatos.GetBaseDatos().PACIENTES.Find(idpaciente);
            txtPaciente.Text = pacie.PERSONA.NOMBRE;

            VistaSuministros();
            llenarAutocomplete();
        }

        private void validarLetras(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        private void validarNumeros(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 4 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void validarNumLetras(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 46)

                e.Handled = false;

            else e.Handled = true;
        }

        public void VistaSuministros()
        {
            rgvPacientes.ItemsSource = (from SUMINISTROS_MEDICAMENTOS in BaseDatos.GetBaseDatos().SUMINISTROS_MEDICAMENTOS
                                        join detalle in BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS
                                        on SUMINISTROS_MEDICAMENTOS.ID_SUMINISTRO_MEDICAMENTO equals detalle.SUMINISTRO_MEDICAMENTOID
                                        join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                        on SUMINISTROS_MEDICAMENTOS.CUENTAID equals cuenta.ID_CUENTA
                                        join paciente in BaseDatos.GetBaseDatos().PACIENTES
                                        on cuenta.PACIENTEID equals paciente.ID_PACIENTE
                                        join medicamento in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                        on detalle.MEDICAMENTOID equals medicamento.ID_MEDICAMENTO
                                        where SUMINISTROS_MEDICAMENTOS.CUENTAID == idcuenta
                                        select new
                                        {
                                            ID_PACIENTE = paciente.ID_PACIENTE,
                                            ID_CUENTA = cuenta.ID_CUENTA,
                                            ID_DETALLE_SUMINISTRO = detalle.ID_DETALLE_SUMINISTRO,
                                            NOMBRE = paciente.PERSONA.NOMBRE,
                                            APATERNO = paciente.PERSONA.A_PATERNO,
                                            TIPOPACIENTE = paciente.TIPO_PACIENTE,
                                            CUENTAA = cuenta.TOTAL,
                                            ID_MEDICAMENTO = medicamento.ID_MEDICAMENTO,
                                            NOMMEDICAMENTO = medicamento.NOMBRE_MEDI,
                                            UMEDIDA = medicamento.U_MEDIDA,
                                            EXISTENCIA = medicamento.CANTIDAD,
                                            CANTIDAD = detalle.CANTIDAD,
                                            COSTO = detalle.PRECIO,
                                            FECHA = detalle.FECHA_CREACION,
                                            ENFERMERA = SUMINISTROS_MEDICAMENTOS.ENFERMERA.PERSONA.NOMBRE,
                                            PRECIO = detalle.PRECIO
                                        }).ToList();
        }

        void llenarAutocomplete()
        {
            autoMedicamento.ItemsSource = (from CATALOGO_MEDICAMENTOS in BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS
                                           where CATALOGO_MEDICAMENTOS.STATUS == "Activo"
                                            select new
                                            {
                                                ID_MATERIAL = CATALOGO_MEDICAMENTOS.ID_MEDICAMENTO,
                                                NOMBRE = CATALOGO_MEDICAMENTOS.NOMBRE_MEDI + " " + CATALOGO_MEDICAMENTOS.COMENTARIO + " " + CATALOGO_MEDICAMENTOS.U_MEDIDA,
                                                EXISTENCIAS = CATALOGO_MEDICAMENTOS.CADUCIDAD
                                            }).ToList();
        }

        void Guardar()
        {
            if (autoMedicamento.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un medicamento");
            }else
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Ingresa la cantidad a devolver");
                }else
                {
                    if (Int32.Parse(txtCantidad.Text) > cantidad)
                    {
                        MessageBox.Show("No se puede devolver más de la cantidad solicitada");
                    }else
                    {
                        if (Int32.Parse(txtCantidad.Text) < 0)
                        {
                            MessageBox.Show("No se aceptan numero negativos");
                        }else
                        {
                            if (Convert.ToInt32(txtCantidad.Text) == cantidad)
                            {
                                nexi = cantidad;
                                //Actualizamos existencias
                                var medic = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmed);
                                medic.CANTIDAD = medic.CANTIDAD + cantidad;

                                //Actualizamos el detalle suministro
                                //var dtalle = BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS.Find(iddetalle);
                                //dtalle.CANTIDAD = dtalle.CANTIDAD - nexi;
                                //dtalle.FECHA_MOD = fechareg;
                                //BaseDatos.GetBaseDatos().SaveChanges();

                                //Actualizamos la cuenta
                                var detsumi = BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS.Find(iddetalle);
                                var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuenta);
                                cuenta.TOTAL = cuenta.TOTAL - (nexi * detsumi.PRECIO);
                                cuenta.SALDO = cuenta.SALDO - (nexi * detsumi.PRECIO);
                                cuenta.FECHA_MOD = fechareg;
                                BaseDatos.GetBaseDatos().SaveChanges();

                                //Eliminamos el suministro
                                BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS.Remove(detsumi);
                                BaseDatos.GetBaseDatos().SaveChanges();

                                //Llamamos la vista
                                MessageBox.Show("Devolución correcta");
                                VistaSuministros();

                                //Deshabilitamos los controles
                                autoMedicamento.SearchText = String.Empty;
                                txtCantidad.Text = String.Empty;
                                autoMedicamento.IsEnabled = false;
                                txtCantidad.IsEnabled = false;
                                btnGuardar.IsEnabled = false;
                            }
                            else
                            {
                                if (Convert.ToInt32(txtCantidad.Text) == 0)
                                {
                                    MessageBox.Show("La cantidad mínima a devolver es 1");
                                }else
                                {
                                    nexi = cantidad - Int32.Parse(txtCantidad.Text);

                                    DEVOLUCIONE dv = new DEVOLUCIONE
                                    {
                                        MEDICMANETOID = idmed,
                                        CANTIDAD = Int32.Parse(txtCantidad.Text),
                                        USUARIOID = 2,
                                        FECHA_CREACION = fechareg,
                                        CUENTAID = idcuenta
                                    };
                                    BaseDatos.GetBaseDatos().DEVOLUCIONES.Add(dv);
                                    BaseDatos.GetBaseDatos().SaveChanges();

                                    //Actualizamos existencias
                                    var medic = BaseDatos.GetBaseDatos().CATALOGO_MEDICAMENTOS.Find(idmed);
                                    medic.CANTIDAD = medic.CANTIDAD + (cantidad - Int32.Parse(txtCantidad.Text));

                                    //Actualizamos el detalle suministro
                                    var dtalle = BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS.Find(iddetalle);
                                    dtalle.CANTIDAD = dtalle.CANTIDAD - nexi;
                                    dtalle.FECHA_MOD = fechareg;
                                    BaseDatos.GetBaseDatos().SaveChanges();

                                    //Actualizamos la cuenta
                                    var detsumi = BaseDatos.GetBaseDatos().DETALLE_SUMINISTROS_MEDICAMENTOS.Find(iddetalle);
                                    var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcuenta);
                                    cuenta.TOTAL = cuenta.TOTAL - (nexi * detsumi.PRECIO);
                                    cuenta.SALDO = cuenta.SALDO - (nexi * detsumi.PRECIO);
                                    cuenta.FECHA_MOD = fechareg;
                                    BaseDatos.GetBaseDatos().SaveChanges();

                                    //Llamamos la vista
                                    MessageBox.Show("Devolución correcta");
                                    VistaSuministros();

                                    //Deshabilitamos los controles
                                    autoMedicamento.SearchText = String.Empty;
                                    txtCantidad.Text = String.Empty;
                                    autoMedicamento.IsEnabled = false;
                                    txtCantidad.IsEnabled = false;
                                    btnGuardar.IsEnabled = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void MostrarPacientes_SelectedCellsChanged(object sender, Telerik.Windows.Controls.GridView.GridViewSelectedCellsChangedEventArgs e)
        {
            BaseDatos.GetBaseDatos().SaveChanges();
        }

        //
        private GridViewRow ClickedRow
        {
            get
            {
                return this.GridContextMenu2.GetClickedElement<GridViewRow>();


            }


        }

        private void GridContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            if (ClickedRow != null)
            {
                itemDevolucion.IsEnabled = true;
            }

        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemDevolucion)
            {
                if (rgvPacientes.SelectedItem != null)
                {
                    //Habilitamos los componentes
                    autoMedicamento.IsEnabled = true;
                    txtCantidad.IsEnabled = true;
                    btnGuardar.IsEnabled = true;

                    //Obtenemos los valores del selectedItem
                    dynamic medicamento = rgvPacientes.SelectedItem;
                    cantidad = medicamento.CANTIDAD;
                    idmed = medicamento.ID_MEDICAMENTO;
                    iddetalle = medicamento.ID_DETALLE_SUMINISTRO;

                    //Mandamos el nombre del medicamento a el autocomplete
                    autoMedicamento.SearchText = medicamento.NOMMEDICAMENTO;
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
