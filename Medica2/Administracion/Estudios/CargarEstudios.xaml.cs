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

namespace Medica2.Administracion.Estudios
{
    /// <summary>
    /// Lógica de interacción para CargarEstudios.xaml
    /// </summary>
    public partial class CargarEstudios : Window
    {
        int idestud;
        Decimal total;
        int idcue;
        DateTime fr = DateTime.Now;
        public CargarEstudios()
        {
            InitializeComponent();
            llenarAutocompletes();
        }

        public CargarEstudios(int ide, int idm, int idp, int idc)
        {
            InitializeComponent();
            llenarAutocompletes();

            idestud = ide;
            idcue = idc;
            llenarVista();

            autoEstudio.IsEnabled = true;
            btnNuevo_Estudio.IsEnabled = false;
            cbTipoMedico.IsChecked = true;
            cbTipoMedico.IsEnabled = false;
            autoMedico.IsEnabled = true;
            autoPaciente.IsEnabled = false;
            btnAgregar.IsEnabled = true;
            btnFinalizar.IsEnabled = true;

            var medico = BaseDatos.GetBaseDatos().MEDICOS.Find(idm);
            autoMedico.SearchText = medico.PERSONA.NOMBRE + " " + medico.PERSONA.A_PATERNO + " " + medico.PERSONA.A_MATERNO;
            var paciente = BaseDatos.GetBaseDatos().PACIENTES.Find(idp);
            autoPaciente.SearchText = paciente.PERSONA.NOMBRE + " " + paciente.PERSONA.A_PATERNO + " " + paciente.PERSONA.A_MATERNO;

            var estudio = BaseDatos.GetBaseDatos().ESTUDIOS.Find(ide);
            total = Convert.ToDecimal(estudio.TOTAL.ToString());
            txtTotal.Text = total.ToString();

        }

        void llenarAutocompletes()
        {
            autoEstudio.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.ToList();

            autoMedico.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                      join e in BaseDatos.GetBaseDatos().MEDICOS
                                      on PERSONA.ID_PERSONA equals e.PERSONAID
                                      select new
                                      {
                                          ID_MEDICO = e.ID_MEDICO,
                                          NOMBRE = PERSONA.NOMBRE + " " + PERSONA.A_PATERNO + " " + PERSONA.A_MATERNO,
                                      }).ToList();

            autoPaciente.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                        join e in BaseDatos.GetBaseDatos().PACIENTES
                                        on PERSONA.ID_PERSONA equals e.PERSONAID
                                        join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                        on e.ID_PACIENTE equals cuenta.PACIENTEID
                                        select new
                                        {
                                            ID_PACIENTE = e.ID_PACIENTE,
                                            NOMBRE = PERSONA.NOMBRE + " " + PERSONA.A_PATERNO + " " + PERSONA.A_MATERNO,
                                            CUENTAA = cuenta.TOTAL,
                                            ID_CUENTA = cuenta.ID_CUENTA
                                        }).ToList();
        }

        void llenarVista()
        {
            rgvEstudios.ItemsSource = (from ESTUDIOS in BaseDatos.GetBaseDatos().ESTUDIOS
                                       join destu in BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS
                                       on ESTUDIOS.ID_ESTUDIO equals destu.ESTUDIOSID
                                       join usu in BaseDatos.GetBaseDatos().USUARIOS
                                       on ESTUDIOS.USUARIOID equals usu.ID_USUARIO
                                       join cue in BaseDatos.GetBaseDatos().CUENTAS
                                       on ESTUDIOS.CUENTAID equals cue.ID_CUENTA
                                       join med in BaseDatos.GetBaseDatos().MEDICOS
                                       on ESTUDIOS.MEDICOID equals med.ID_MEDICO
                                       join cte in BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS
                                       on destu.CATALOGO_ESTUDIOS_ID equals cte.CATALOGO_ESTUDIO_ID
                                       where ESTUDIOS.ID_ESTUDIO == idestud
                                       select new
                                       {
                                           ID_ESTUDIOS = ESTUDIOS.ID_ESTUDIO,
                                           ID_CATALOGO_ESTUDIOS = cte.CATALOGO_ESTUDIO_ID,
                                           ID_USUARIO = usu.ID_USUARIO,
                                           ID_CUENTA = cue.ID_CUENTA,
                                           ID_MEDICO = med.ID_MEDICO,
                                           ID_DETALLE = destu.ID_DETALLE_ESTUDIOS,
                                           ESTUDIONOMBRE = cte.NOMBRE,
                                           MEDICONOMBRE = med.PERSONA.NOMBRE,
                                           USUARIOO = usu.EMPLEADO.PERSONA.NOMBRE,
                                           DESCRIPCION = cte.DESCRIPCION,
                                           COSTOO = cte.COSTO
                                       });
        }

        void llenarVistaNormal()
        {
            rgvEstudios.ItemsSource = (from ESTUDIOS in BaseDatos.GetBaseDatos().ESTUDIOS
                                       join destu in BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS
                                       on ESTUDIOS.ID_ESTUDIO equals destu.ESTUDIOSID
                                       join usu in BaseDatos.GetBaseDatos().USUARIOS
                                       on ESTUDIOS.USUARIOID equals usu.ID_USUARIO
                                       join cte in BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS
                                       on destu.CATALOGO_ESTUDIOS_ID equals cte.CATALOGO_ESTUDIO_ID
                                       where ESTUDIOS.ID_ESTUDIO == idestud
                                       select new
                                       {
                                           ID_ESTUDIOS = ESTUDIOS.ID_ESTUDIO,
                                           ID_CATALOGO_ESTUDIOS = cte.CATALOGO_ESTUDIO_ID,
                                           ID_USUARIO = usu.ID_USUARIO,
                                           ID_DETALLE = destu.ID_DETALLE_ESTUDIOS,
                                           ESTUDIONOMBRE = cte.NOMBRE,
                                           USUARIOO = usu.EMPLEADO.PERSONA.NOMBRE,
                                           DESCRIPCION = cte.DESCRIPCION,
                                           COSTOO = cte.COSTO
                                       });
        }

        void limpiar()
        {
            autoEstudio.SearchText = String.Empty;
            txtCosto.Text = String.Empty;
        }

        void limpiartodo()
        {
            autoEstudio.SearchText = String.Empty;
            txtCosto.Text = String.Empty;
            autoMedico.Visibility = Visibility.Hidden;
            autoPaciente.Visibility = Visibility.Hidden;
            txtMedico.Text = String.Empty;
            txtPaciente.Text = String.Empty;
            cbTipoMedico.IsChecked = false;
            llenarVista();
            txtTotal.Text = String.Empty;
        }

        void GuardarDetalleEstudios()
        {
            if (autoEstudio.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un estudio");
            }
            else
            {
                if (cbTipoMedico.IsChecked == true)
                {
                    if (autoMedico.SelectedItem == null)
                    {
                        MessageBox.Show("Introce un médico");
                    }
                    else
                    {
                        if (autoPaciente.SelectedItem == null)
                        {
                            MessageBox.Show("Ingresa un paciente");
                        }
                        else
                        {
                            txtMedico.Visibility = Visibility.Hidden;
                            txtPaciente.Visibility = Visibility.Hidden;
                            autoMedico.Visibility = Visibility.Visible;
                            autoPaciente.Visibility = Visibility.Visible;

                            if (autoMedico.SelectedItem == null)
                            {
                                MessageBox.Show("Selecciona un médico");
                            }
                            else
                            {
                                if (autoPaciente.SelectedItem == null)
                                {
                                    MessageBox.Show("Selecciona un paciente");
                                }
                                else
                                {
                                    int idestudio = ((CATALOGO_ESTUDIOS)autoEstudio.SelectedItem).CATALOGO_ESTUDIO_ID;
                                    var estuidionombre = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(idestudio);
                                    dynamic paciente = autoPaciente.SelectedItem;
                                    dynamic medico = autoMedico.SelectedItem;
                                    idcue = paciente.ID_CUENTA;
                                    int idmed = medico.ID_MEDICO;
                                    DETALLE_ESTUDIOS des = new DETALLE_ESTUDIOS
                                    {
                                        ESTUDIOSID = idestud,
                                        CATALOGO_ESTUDIOS_ID = idestudio,
                                        CANTIDAD = 1,
                                        COSTO = estuidionombre.COSTO,
                                        FECHA_CREACION = fr
                                    };
                                    BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS.Add(des);
                                    BaseDatos.GetBaseDatos().SaveChanges();

                                    total = total + (Decimal.Parse(txtCosto.Text));
                                    txtTotal.Text = total.ToString();

                                    dynamic medic = autoMedico.SelectedItem;
                                    dynamic cuent = autoPaciente.SelectedItem;
                                    int idcuenta = cuent.ID_CUENTA;
                                    int idmedicoo = medic.ID_MEDICO;

                                    var estu = BaseDatos.GetBaseDatos().ESTUDIOS.Find(idestud);
                                    estu.TOTAL = estu.TOTAL + total;
                                    estu.MEDICOID = idmedicoo;
                                    estu.CUENTAID = idcuenta;
                                    BaseDatos.GetBaseDatos().SaveChanges();

                                    llenarVista();
                                    limpiar();
                                    autoEstudio.SelectedItem = null;
                                    btnFinalizar.IsEnabled = true;
                                    cbTipoMedico.IsEnabled = false;

                                    autoPaciente.IsEnabled = false;
                                }
                            }
                        }
                    }

                }
                else
                {
                    itemEditar2.Visibility = Visibility.Visible;
                    if (cbTipoMedico.IsChecked == false)
                    {
                        if (txtMedico.Text == "")
                        {
                            MessageBox.Show("Seleccionaun médico");
                        }
                        else
                        {
                            if (txtPaciente.Text == "")
                            {
                                MessageBox.Show("Selecciona un paciente");
                            }
                            else
                            {
                                txtMedico.Visibility = Visibility.Visible;
                                txtPaciente.Visibility = Visibility.Visible;
                                autoMedico.Visibility = Visibility.Hidden;
                                autoPaciente.Visibility = Visibility.Hidden;

                                int idestudio = ((CATALOGO_ESTUDIOS)autoEstudio.SelectedItem).CATALOGO_ESTUDIO_ID;
                                var estuidionombre = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(idestudio);

                                DETALLE_ESTUDIOS des = new DETALLE_ESTUDIOS
                                {
                                    ESTUDIOSID = idestud,
                                    CATALOGO_ESTUDIOS_ID = idestudio,
                                    CANTIDAD = 1,
                                    COSTO = estuidionombre.COSTO,
                                    FECHA_CREACION = fr
                                };
                                BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS.Add(des);
                                BaseDatos.GetBaseDatos().SaveChanges();

                                total = total + (Decimal.Parse(txtCosto.Text));
                                txtTotal.Text = total.ToString();

                                var estud = BaseDatos.GetBaseDatos().ESTUDIOS.Find(idestud);
                                estud.MEDICO_SOLICITANTE = txtMedico.Text;
                                estud.PACIENTE_SOLICITANTE = txtPaciente.Text;
                                estud.TOTAL = total;
                                BaseDatos.GetBaseDatos().SaveChanges();

                                llenarVistaNormal();
                                cbTipoMedico.IsEnabled = false;
                                limpiar();
                                autoEstudio.SelectedItem = null;
                                btnFinalizar.IsEnabled = true;
                                cbTipoMedico.IsEnabled = false;

                                txtPaciente.IsEnabled = false;
                            }
                        }
                    }
                }
            }//
        }

        void llenarCosto()
        {
            if (autoEstudio.SelectedItem != null)
            {
                int idest = ((CATALOGO_ESTUDIOS)autoEstudio.SelectedItem).CATALOGO_ESTUDIO_ID;
                var busquedaest = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(idest);
                txtCosto.Text = busquedaest.COSTO.ToString();
                //

            }
        }

        void Eliminar()
        {
            dynamic detalleEst = rgvEstudios.SelectedItem;
            int iddetalle = detalleEst.ID_DETALLE;
            if (rgvEstudios.SelectedItem != null)
            {
                var detalleEstudi = BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS.Find(iddetalle);

                //Actualizamos el total
                total = total - (Decimal.Parse(detalleEstudi.COSTO.ToString()));
                txtTotal.Text = total.ToString();

                //Actualizamos cuenta
                int idc = detalleEst.ID_CUENTA;
                var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idc);
                cuenta.TOTAL = cuenta.TOTAL - detalleEstudi.COSTO;

                //Eliminar el suministro
                BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS.Remove(detalleEstudi);
                BaseDatos.GetBaseDatos().SaveChanges();
                llenarVista();
            }
        }

        void Eliminar2()
        {
            dynamic detalleEst = rgvEstudios.SelectedItem;
            int iddetalle = detalleEst.ID_DETALLE;
            if (rgvEstudios.SelectedItem != null)
            {
                var detalleEstudi = BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS.Find(iddetalle);

                //Actualizamos el total
                total = total - (Decimal.Parse(detalleEstudi.COSTO.ToString()));
                txtTotal.Text = total.ToString();

                //se actualiza el total del estudio
                var estudio = BaseDatos.GetBaseDatos().ESTUDIOS.Find(idestud);
                estudio.TOTAL = estudio.TOTAL - detalleEstudi.COSTO;

                //Eliminar el suministro
                BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS.Remove(detalleEstudi);
                BaseDatos.GetBaseDatos().SaveChanges();
                llenarVistaNormal();
            }
        }

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
                if (cbTipoMedico.IsChecked == true)
                {
                    itemEliminar.Visibility = Visibility.Visible;
                    itemEditar.Visibility = Visibility.Visible;
                    itemEditar.IsEnabled = true;
                    itemEliminar.IsEnabled = true;

                    itemEditar2.Visibility = Visibility.Hidden;
                    itemEliminar2.Visibility = Visibility.Hidden;
                    itemEliminar2.IsEnabled = false;
                    itemEditar2.IsEnabled = false;
                }
                else
                {
                    if (cbTipoMedico.IsChecked == false)
                    {
                        itemEditar2.Visibility = Visibility.Visible;
                        itemEliminar2.Visibility = Visibility.Visible;
                        itemEliminar2.IsEnabled = true;
                        itemEditar2.IsEnabled = true;

                        itemEliminar.Visibility = Visibility.Hidden;
                        itemEditar.Visibility = Visibility.Hidden;
                        itemEditar.IsEnabled = false;
                        itemEliminar.IsEnabled = false;
                    }
                }
            }
        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemEliminar)
            {
                //
                MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el Estudio?", "Administración", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Eliminar();
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                if (sender == itemEditar)
                {

                    if (rgvEstudios.SelectedItem != null)
                    {
                        btnFinalizar.IsEnabled = false;
                        btnAgregar.Visibility = Visibility.Hidden;
                        btnEditar.Visibility = Visibility.Visible;
                        btnEditar.IsEnabled = true;

                        //Se busca el detalle suministro
                        dynamic detalle = rgvEstudios.SelectedItem;
                        int iddetalle = detalle.ID_DETALLE;
                        var detallees = BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS.Find(iddetalle);
                        int ide = detalle.ID_CATALOGO_ESTUDIOS;

                        //Asigna los valores a los txt
                        var estudio = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(ide);
                        txtCosto.Text = detallees.COSTO.ToString();
                        autoEstudio.SearchText = estudio.NOMBRE;
                        int idme = detalle.ID_MEDICO;
                        var med = BaseDatos.GetBaseDatos().MEDICOS.Find(idme);
                        autoMedico.SearchText = med.PERSONA.NOMBRE + " " + med.PERSONA.A_PATERNO + " " + med.PERSONA.A_MATERNO;

                        int idpac = detalle.ID_CUENTA;
                        var pac = BaseDatos.GetBaseDatos().CUENTAS.Find(idpac);
                        autoPaciente.SearchText = pac.PACIENTE.PERSONA.NOMBRE + " " + pac.PACIENTE.PERSONA.A_PATERNO + " " + pac.PACIENTE.PERSONA.A_MATERNO;
                        cbTipoMedico.IsEnabled = false;

                        //Se actualizan los totales
                        total = total - (Decimal.Parse(detallees.COSTO.ToString()));
                        txtTotal.Text = total.ToString();

                    }
                }
            }
        }

        private void itemAgregar_Click2(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemEliminar2)
            {
                //
                MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el Estudio?", "Administración", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Eliminar2();
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                if (sender == itemEditar2)
                {

                    if (rgvEstudios.SelectedItem != null)
                    {
                        btnFinalizar.IsEnabled = false;
                        btnAgregar.Visibility = Visibility.Hidden;
                        btnEditar.Visibility = Visibility.Visible;
                        btnEditar.IsEnabled = true;

                        //Se busca el detalle suministro
                        dynamic detalle = rgvEstudios.SelectedItem;
                        int iddetalle = detalle.ID_DETALLE;
                        var detallees = BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS.Find(iddetalle);
                        int ide = detalle.ID_CATALOGO_ESTUDIOS;

                        //Asigna los valores a los txt
                        var estudio = BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS.Find(ide);
                        txtCosto.Text = detallees.COSTO.ToString();
                        autoEstudio.SearchText = estudio.NOMBRE;

                        int idess = detalle.ID_ESTUDIOS;
                        var estt = BaseDatos.GetBaseDatos().ESTUDIOS.Find(idess);
                        txtMedico.Text = estt.MEDICO_SOLICITANTE;
                        txtPaciente.Text = estt.PACIENTE_SOLICITANTE;
                        cbTipoMedico.IsEnabled = false;

                        //Se actualizan los totales
                        total = total - (Decimal.Parse(detallees.COSTO.ToString()));
                        txtTotal.Text = total.ToString();


                    }
                }
            }
        }

        void EditarDetalleEstudio()
        {
            if (autoEstudio.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un estudio");
            }
            else
            {
                if (cbTipoMedico.IsChecked == true)
                {
                    if (autoMedico.SelectedItem == null)
                    {
                        MessageBox.Show("Introce un medico");
                    }
                    else
                    {
                        if (autoPaciente.SelectedItem == null)
                        {
                            MessageBox.Show("Ingresa un paciente");
                        }
                        else
                        {
                            txtMedico.Visibility = Visibility.Hidden;
                            txtPaciente.Visibility = Visibility.Hidden;
                            autoMedico.Visibility = Visibility.Visible;
                            autoPaciente.Visibility = Visibility.Visible;

                            if (autoMedico.SelectedItem == null)
                            {
                                MessageBox.Show("Selecciona un medico");
                            }
                            else
                            {
                                if (autoPaciente.SelectedItem == null)
                                {
                                    MessageBox.Show("Selecciona un paciente");
                                }
                                else
                                {
                                    //
                                    dynamic detalle = rgvEstudios.SelectedItem;
                                    int iddetalle = detalle.ID_DETALLE;
                                    int ide = ((CATALOGO_ESTUDIOS)autoEstudio.SelectedItem).CATALOGO_ESTUDIO_ID;

                                    var de = BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS.Find(iddetalle);
                                    de.CATALOGO_ESTUDIOS_ID = ide;
                                    de.COSTO = Decimal.Parse(txtCosto.Text);
                                    de.FECHA_MOD = fr;
                                    BaseDatos.GetBaseDatos().SaveChanges();

                                    //Actualizamos el total
                                    total = total + (Decimal.Parse(txtCosto.Text));
                                    txtTotal.Text = total.ToString();

                                    var estud = BaseDatos.GetBaseDatos().ESTUDIOS.Find(idestud);
                                    estud.MEDICO_SOLICITANTE = txtMedico.Text;
                                    estud.PACIENTE_SOLICITANTE = txtPaciente.Text;
                                    estud.TOTAL = total;
                                    BaseDatos.GetBaseDatos().SaveChanges();

                                    //Actualizamos los botones
                                    btnEditar.Visibility = Visibility.Hidden;
                                    btnAgregar.Visibility = Visibility.Visible;
                                    btnFinalizar.IsEnabled = true;
                                    cbTipoMedico.IsEnabled = false;
                                    limpiar();
                                    autoEstudio.SelectedItem = null;
                                    llenarVistaNormal();

                                }
                            }
                        }
                    }

                }
                else
                {
                    if (cbTipoMedico.IsChecked == false)
                    {
                        if (txtMedico.Text == "")
                        {
                            MessageBox.Show("Seleccionaun medico");
                        }
                        else
                        {
                            if (txtPaciente.Text == "")
                            {
                                MessageBox.Show("Selecciona un paciente");
                            }
                            else
                            {
                                txtMedico.Visibility = Visibility.Visible;
                                txtPaciente.Visibility = Visibility.Visible;
                                autoMedico.Visibility = Visibility.Hidden;
                                autoPaciente.Visibility = Visibility.Hidden;

                                dynamic detalle = rgvEstudios.SelectedItem;
                                int iddetalle = detalle.ID_DETALLE;
                                int ide = ((CATALOGO_ESTUDIOS)autoEstudio.SelectedItem).CATALOGO_ESTUDIO_ID;

                                var de = BaseDatos.GetBaseDatos().DETALLE_ESTUDIOS.Find(iddetalle);
                                de.CATALOGO_ESTUDIOS_ID = ide;
                                de.COSTO = Decimal.Parse(txtCosto.Text);
                                de.FECHA_MOD = fr;
                                BaseDatos.GetBaseDatos().SaveChanges();

                                //Actualizamos el total
                                total = total + (Decimal.Parse(txtCosto.Text));
                                txtTotal.Text = total.ToString();

                                //Actualizamos los botones
                                btnEditar.Visibility = Visibility.Hidden;
                                btnAgregar.Visibility = Visibility.Visible;
                                btnFinalizar.IsEnabled = true;
                                cbTipoMedico.IsEnabled = false;

                                //Actualizamos el total de la tabla principal estudios
                                var estuf = BaseDatos.GetBaseDatos().ESTUDIOS.Find(idestud);
                                estuf.TOTAL = total;
                                BaseDatos.GetBaseDatos().SaveChanges();

                                llenarVistaNormal();
                                limpiar();
                                autoEstudio.SelectedItem = null;
                            }
                        }
                    }
                }
            }//
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            if (cbTipoMedico.IsChecked == true)
            {

                var cuenta = BaseDatos.GetBaseDatos().CUENTAS.Find(idcue);
                cuenta.TOTAL = cuenta.TOTAL + total;
                cuenta.SALDO = cuenta.SALDO + total;
                BaseDatos.GetBaseDatos().SaveChanges();

                var estudi = BaseDatos.GetBaseDatos().ESTUDIOS.Find(idestud);
                estudi.TOTAL = total;
                BaseDatos.GetBaseDatos().SaveChanges();

                MessageBox.Show("Se finalizo el proceso");
                idestud = 0;
                llenarVista();
                total = 0;
                btnNuevo_Estudio.IsEnabled = true;
                btnAgregar.IsEnabled = false;
                btnFinalizar.IsEnabled = false;
                cbTipoMedico.IsEnabled = false;
                autoMedico.SelectedItem = 0;
                autoMedico.SearchText = "";
                autoPaciente.SearchText = "";
                autoPaciente.SelectedItem = 0;
                txtPaciente.IsEnabled = false;
                txtMedico.IsEnabled = false;
                autoEstudio.IsEnabled = false;
                autoEstudio.SearchText = "";
                limpiartodo();
            }
            else
            {
                MessageBox.Show("Se finalizo el proceso");
                limpiartodo();
                idestud = 0;
                llenarVista();
                total = 0;
                btnNuevo_Estudio.IsEnabled = true;
                btnAgregar.IsEnabled = false;
                btnFinalizar.IsEnabled = false;
                cbTipoMedico.IsEnabled = false;
                txtMedico.IsEnabled = false;
                txtPaciente.IsEnabled = false;
                autoEstudio.IsEnabled = false;

            }
        }

        private void cbTipoMedico_Checked(object sender, RoutedEventArgs e)
        {
            if (cbTipoMedico.IsChecked == true)
            {
                txtMedico.Visibility = Visibility.Hidden;
                txtPaciente.Visibility = Visibility.Hidden;
                autoMedico.Visibility = Visibility.Visible;
                autoPaciente.Visibility = Visibility.Visible;
            }
        }

        private void cbTipoMedico_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbTipoMedico.IsChecked == false)
            {
                txtMedico.Visibility = Visibility.Visible;
                txtPaciente.Visibility = Visibility.Visible;
                autoMedico.Visibility = Visibility.Hidden;
                autoPaciente.Visibility = Visibility.Hidden;
            }
        }

        private void autoEstudio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            llenarCosto();
        }

        private void btnNuevo_Estudio_Click(object sender, RoutedEventArgs e)
        {

            ESTUDIO obj = new ESTUDIO
            {
                USUARIOID = 2,
                FECHA_CREACION = fr
            };
            BaseDatos.GetBaseDatos().ESTUDIOS.Add(obj);
            BaseDatos.GetBaseDatos().SaveChanges();

            idestud = obj.ID_ESTUDIO;
            cbTipoMedico.IsEnabled = true;
            autoEstudio.IsEnabled = true;
            txtMedico.IsEnabled = true;
            txtPaciente.IsEnabled = true;
            btnAgregar.IsEnabled = true;

            btnNuevo_Estudio.IsEnabled = false;

            autoPaciente.IsEnabled = true;


        }

        private void btnAgregar_Copy_Click(object sender, RoutedEventArgs e)
        {
            GuardarDetalleEstudios();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            GuardarDetalleEstudios();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarDetalleEstudio();
        }
    }
}
