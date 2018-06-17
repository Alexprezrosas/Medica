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

namespace Medica2.Administracion.EquipoHospital
{
    /// <summary>
    /// Lógica de interacción para CargarEquipoHospital.xaml
    /// </summary>
   
    public partial class CargarEquipoHospital : Window
    {
        Decimal total;
        int ideh1;
        int idcue;

        DateTime fr = DateTime.Now;
        public CargarEquipoHospital()
        {
            InitializeComponent();
            llenarAutocompletes();
        }

        public CargarEquipoHospital(int ids,int idme, int pac, int idc)
        {
            InitializeComponent();
            llenarAutocompletes();

            ideh1 = ids;
            idcue = idc;

            llenarVista();
            var equipoh = BaseDatos.GetBaseDatos().EQUIPO_HOSPITAL.Find(ideh1);           
            
            var medico = BaseDatos.GetBaseDatos().MEDICOS.Find(idme);
            automedico.SearchText = medico.PERSONA.NOMBRE + " " + medico.PERSONA.A_PATERNO+ " " + medico.PERSONA.A_MATERNO;

            var paciente = BaseDatos.GetBaseDatos().PACIENTES.Find(pac);
            autopaceinte.SearchText = paciente.PERSONA.NOMBRE+" "+ paciente.PERSONA.A_PATERNO + " "+ paciente.PERSONA.A_MATERNO;
            autopaceinte.IsEnabled = false;

            autoequipoh.IsEnabled = true;

            total = Decimal.Parse(equipoh.TOTAL.ToString());
            txtTotal.Text = total.ToString();

            btnNuevoeqh.IsEnabled = false;
            btnAgregar.IsEnabled = true;
            btnFinalizar.IsEnabled = true;

        }

        void llenarAutocompletes()
        {
            autoequipoh.ItemsSource = BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.ToList();

            automedico.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                      join e in BaseDatos.GetBaseDatos().MEDICOS
                                      on PERSONA.ID_PERSONA equals e.PERSONAID
                                      select new
                                      {
                                          ID_MEDICO = e.ID_MEDICO,
                                          NOMBRE = PERSONA.NOMBRE + " " + PERSONA.A_PATERNO + " " + PERSONA.A_MATERNO,
                                      }).ToList();

            autopaceinte.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                        join e in BaseDatos.GetBaseDatos().PACIENTES
                                        on PERSONA.ID_PERSONA equals e.PERSONAID
                                        join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                        on e.ID_PACIENTE equals cuenta.PACIENTEID
                                        select new
                                        {
                                            ID_PACIENTE = e.ID_PACIENTE,
                                            NOMBRE = PERSONA.NOMBRE+" "+PERSONA.A_PATERNO+" "+PERSONA.A_MATERNO,
                                            CUENTAA = cuenta.TOTAL,
                                            ID_CUENTA = cuenta.ID_CUENTA
                                        }).ToList();
        }

        void llenarVista()
        {

            rgvEquipoHospital.ItemsSource = (from EQUIPOH in BaseDatos.GetBaseDatos().EQUIPO_HOSPITAL
                                             join med in BaseDatos.GetBaseDatos().MEDICOS
                                             on EQUIPOH.MEDICOID equals med.ID_MEDICO
                                             join deqh in BaseDatos.GetBaseDatos().DETALLE_EQUIPO_HOSPITAL
                                             on EQUIPOH.ID_EQUIPO_HOSPITAL equals deqh.EQUIPO_HOSPITALID
                                             join cateh in BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL
                                             on deqh.CATALOGO_EQUIPO_HOSPITALID equals cateh.ID_EQUIPO_HOSPITAL
                                             join cuent in BaseDatos.GetBaseDatos().CUENTAS
                                             on EQUIPOH.CUENTAID equals cuent.ID_CUENTA
                                             where EQUIPOH.ID_EQUIPO_HOSPITAL == ideh1
                                             select new
                                             {
                                                 ID_MEDICO = med.ID_MEDICO,
                                                 IDCEUNTA = cuent.ID_CUENTA,
                                                 IDCATALOGOEH = cateh.ID_EQUIPO_HOSPITAL,
                                                 NOMBRE = cateh.NOM_EQUIPO_HOSPITAL,
                                                 DESCRIPCION = cateh.DESCRIPCION,
                                                 COSTO = cateh.COSTO,
                                                 ID_DETALLE = deqh.ID_DETALLE_EQUIPO_HOSPITAL

                                             });
          
        }

        void limpiar()
        {
            autoequipoh.SearchText = String.Empty;
            autoequipoh.SelectedItem = null;
            txtcosto.Text = String.Empty;
        }

        void limpiartodo()
        {
            autoequipoh.SearchText = String.Empty;
            autoequipoh.SelectedItem = null;
            txtcosto.Text = String.Empty;
            automedico.SearchText = String.Empty;
            automedico.SelectedItem = null;
            autopaceinte.SearchText = String.Empty;
            autopaceinte.SelectedItem = null;

            ideh1 = 0;
            llenarVista();
            txtTotal.Text = String.Empty;
        }

        void NuevoEquipoHospital()
        {
            if (automedico.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un Medico");
            }
            else
            {
                if (autopaceinte.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un Paciente");
                }else
                {
                    dynamic medico = automedico.SelectedItem;
                    int idmed = medico.ID_MEDICO;

                    dynamic cuenta = autopaceinte.SelectedItem;
                    int idcuent = cuenta.ID_CUENTA;

                    EQUIPO_HOSPITAL eh = new EQUIPO_HOSPITAL
                    {
                        MEDICOID = idmed,
                        CUENTAID = idcuent,
                        USUARIOID = 2,
                        FECHA_CREACION = fr

                    };
                    BaseDatos.GetBaseDatos().EQUIPO_HOSPITAL.Add(eh);
                    BaseDatos.GetBaseDatos().SaveChanges();

                    ideh1 = eh.ID_EQUIPO_HOSPITAL;
                    idcue = idcuent;//esta cuenta para saber a que cuenta se van a gragar los quipo hospital

                    autoequipoh.IsEnabled = true;
                    btnAgregar.IsEnabled = true;
                    autopaceinte.IsEnabled = false;
                    btnNuevoeqh.IsEnabled = false;
                }
            }
           
        }

        void Agregar()
        {
            if (autoequipoh.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un Equipo de Hospital");
            }
            else
            {
                if(txtcosto.Text=="")
                {
                    MessageBox.Show("Ingresa el costo del Equipo Hospital");
                }
                else
                {
                    int idequipoh = ((CATALOGO_EQUIPO_HOSPITAL)autoequipoh.SelectedItem).ID_EQUIPO_HOSPITAL;
                    var equipohospital=BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.Find(idequipoh);

                    DETALLE_EQUIPO_HOSPITAL deh = new DETALLE_EQUIPO_HOSPITAL
                    {
                        EQUIPO_HOSPITALID = ideh1,
                        CATALOGO_EQUIPO_HOSPITALID = idequipoh,
                        CANTIDAD = 1,
                        COSTO = equipohospital.COSTO,
                        FECHA_CREACION = fr
                    };
                    BaseDatos.GetBaseDatos().DETALLE_EQUIPO_HOSPITAL.Add(deh);
                    BaseDatos.GetBaseDatos().SaveChanges();

                    btnFinalizar.IsEnabled = true;
                    total = total + Decimal.Parse(deh.COSTO.ToString());
                    txtTotal.Text = total.ToString();

                    llenarVista();
                    limpiar();

                }

            }
        }

        void Editar()
        {
            if (autoequipoh.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un Equipo de Hospital");
            }
            else
            {
                if(txtcosto.Text=="")
                {
                    MessageBox.Show("Ingresa el costo del Equipo Hospital");
                }
                else
                {
                    int idequipoh = ((CATALOGO_EQUIPO_HOSPITAL)autoequipoh.SelectedItem).ID_EQUIPO_HOSPITAL;
                    var equipohospital=BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.Find(idequipoh);

                    dynamic detalle = rgvEquipoHospital.SelectedItem;
                    int iddetalle = detalle.ID_DETALLE;
                    var det = BaseDatos.GetBaseDatos().DETALLE_EQUIPO_HOSPITAL.Find(iddetalle);
                    det.CATALOGO_EQUIPO_HOSPITALID = idequipoh;
                    det.COSTO = equipohospital.COSTO;
                    det.FECHA_MOD = fr;
                    BaseDatos.GetBaseDatos().SaveChanges();

                    btnFinalizar.IsEnabled = true;
                    btnEditar.Visibility = Visibility.Hidden;
                    btnAgregar.Visibility = Visibility.Visible;

                    total = total + Decimal.Parse(det.COSTO.ToString());
                    txtTotal.Text = total.ToString();

                    llenarVista();
                    limpiar();

                }

            }
        }

        void llenarCosto()
        {
            if (autoequipoh.SelectedItem != null)
            {
                int ideqho = ((CATALOGO_EQUIPO_HOSPITAL)autoequipoh.SelectedItem).ID_EQUIPO_HOSPITAL;
                var busquedaequipH = BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.Find(ideqho);
                txtcosto.Text = busquedaequipH.COSTO.ToString();

            }
        }
       
        void Finalizar()
        {
            var cuentita = BaseDatos.GetBaseDatos().CUENTAS.Find(idcue);
            cuentita.TOTAL = cuentita.TOTAL + total;
            cuentita.SALDO = cuentita.SALDO + total;
            BaseDatos.GetBaseDatos().SaveChanges();
            MessageBox.Show("Se finalizo el proceso");

            var equipo = BaseDatos.GetBaseDatos().EQUIPO_HOSPITAL.Find(ideh1);
            equipo.TOTAL = total;
            BaseDatos.GetBaseDatos().SaveChanges();

            limpiartodo();

           automedico.IsEnabled = true;
           autopaceinte.IsEnabled = true;
           autoequipoh.IsEnabled = false;
           btnAgregar.IsEnabled = false;
            btnFinalizar.IsEnabled = false;
            btnNuevoeqh.IsEnabled = true;
        
            
        }

        void Eliminar()
        {
            dynamic detalleEst = rgvEquipoHospital.SelectedItem;
            int iddetalle = detalleEst.ID_DETALLE;
            if (rgvEquipoHospital.SelectedItem != null)
            {
                var detalleEH = BaseDatos.GetBaseDatos().DETALLE_EQUIPO_HOSPITAL.Find(iddetalle);

                //Actualizamos el total
                total = total - (Decimal.Parse(detalleEH.COSTO.ToString()));
                txtTotal.Text = total.ToString();                

                //Eliminar el detalle equipo hospital
                BaseDatos.GetBaseDatos().DETALLE_EQUIPO_HOSPITAL.Remove(detalleEH);
                BaseDatos.GetBaseDatos().SaveChanges();
                llenarVista();
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
                itemEditar.IsEnabled = true;
                itemEliminar.IsEnabled = true;
            }
        }

        private void itemAgregar_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (sender == itemEliminar)
            {
                //
                MessageBoxResult result = MessageBox.Show("Esta seguro de eliminar el Equipo de Hospital?", "Administracion", MessageBoxButton.YesNo);
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

                    if (rgvEquipoHospital.SelectedItem != null)
                    {
                        btnFinalizar.IsEnabled = false;
                        btnAgregar.Visibility = Visibility.Hidden;
                        btnEditar.Visibility = Visibility.Visible;
                        btnEditar.IsEnabled = true;

                        //Se busca el detalle suministro
                        dynamic detalle = rgvEquipoHospital.SelectedItem;
                        int iddetalle = detalle.ID_DETALLE;

                        var detallees = BaseDatos.GetBaseDatos().DETALLE_EQUIPO_HOSPITAL.Find(iddetalle);
                        int ide = detalle.IDCATALOGOEH;

                        //Asigna los valores a los txt
                        var equipo = BaseDatos.GetBaseDatos().CATALOGO_EQUIPO_HOSPITAL.Find(ide);
                        txtcosto.Text = detallees.COSTO.ToString();
                        autoequipoh.SearchText = equipo.NOM_EQUIPO_HOSPITAL;

                        int idme = detalle.ID_MEDICO;
                        var med = BaseDatos.GetBaseDatos().MEDICOS.Find(idme);
                        automedico.SearchText = med.PERSONA.NOMBRE + " " + med.PERSONA.A_PATERNO + " " + med.PERSONA.A_MATERNO;

                        int idpac = detalle.IDCEUNTA;
                        var pac = BaseDatos.GetBaseDatos().CUENTAS.Find(idpac);
                        autopaceinte.SearchText = pac.PACIENTE.PERSONA.NOMBRE + " " + pac.PACIENTE.PERSONA.A_PATERNO + " " + pac.PACIENTE.PERSONA.A_MATERNO;
                        
                        

                        //Se actualizan los totales
                        total = total - (Decimal.Parse(detallees.COSTO.ToString()));
                        txtTotal.Text = total.ToString();

                    }
                }
            }
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            Finalizar();
        }

        private void autoequipoh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            llenarCosto();
        }


        private void btnNuevoeqh_Click(object sender, RoutedEventArgs e)
        {
            NuevoEquipoHospital();
        }
        
       
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Agregar();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }
    }
}
