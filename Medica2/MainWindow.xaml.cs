using Medica2.Administracion;
using Medica2.Administracion.Cirugias;
using Medica2.Administracion.Cuartos;
using Medica2.Administracion.Depositos;
using Medica2.Administracion.Enfermeras;
using Medica2.Administracion.EquipoHospital;
using Medica2.Administracion.Especialidades;
using Medica2.Administracion.EspecialidadesEnfermeras;
using Medica2.Administracion.Estudios;
using Medica2.Administracion.Pacientes;
using Medica2.Enfermeria.Pacientes;
using Medica2.Farmacia;
using Medica2.Farmacia.Compras;
using Medica2.Farmacia.Conversion;
using Medica2.Farmacia.Devoluciones;
using Medica2.Farmacia.Materiales;
using Medica2.Farmacia.Medicamentos;
using Medica2.Farmacia.Proveedores;
using Medica2.Farmacia.Ventas;
using System.Windows;


namespace Medica2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadMenuItem_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
           //Enfermeria
           if (sender == itemEnfermerasPacientes)
            {
                MostrarPacientes mp = new MostrarPacientes();
                mp.Show();
            }

           //Devoluciones
           if (sender == itemDevolucion)
            {
                DevolucionPacientes dp = new DevolucionPacientes();
                dp.Show();
            }

            // Proveedores
            if(sender == addProveedor){
                RegistroProveedor prov = new RegistroProveedor();
                prov.Show();
            }
            else
            {
                if (sender == conProveedor)
                {
                    MostrarProveedores cprov = new MostrarProveedores();
                    cprov.Show();
                }
                
                
            }

            //Materiales
            //if (sender == itemNuevoMaterial)
            //{
            //    NuevoMaterial nuMat = new NuevoMaterial();
            //    nuMat.Show();
            //}
            //else
            //{
                if (sender == itemConsultarMaterial)
                {
                    ConsultaMaterial mat = new ConsultaMaterial();
                    mat.Show();
                }
                else
                {
                    if (sender == itemMaterialEnfermera)
                    {
                        SolicitudEnfermera solenf = new SolicitudEnfermera();
                        solenf.Show();
                    }
                    else
                    {
                        if (sender == itemMaterialDoctor)
                        {
                            SolicitudDoctor soldoc = new SolicitudDoctor();
                            soldoc.Show();
                        }
                    }
                }
            //}

            //Medicamentos
            if (sender == itemNuevoMedicamentos)
            {
                RegistroMedicamento nmedi = new RegistroMedicamento();
                nmedi.Show();
            }else
            {
                if (sender == itemShowMedi)
                {
                    ConsultaMedicamentos cmed = new ConsultaMedicamentos();
                    cmed.Show();
                }else
                {
                    if (sender == itemConversion)
                    {
                        RegistroConversion c = new RegistroConversion();
                        c.Show();
                    }
                }  
            }

            //Compras
            if (sender == itemNuevaCompra)
            {
                NuevaCompra rcom = new NuevaCompra();
                rcom.Show();
            }
            else
            {
                if (sender == itemComprasdelDia)
                {
                    ConsultaCompras mcom = new ConsultaCompras();
                    mcom.Show();
                }
            }

            //Ventas
            if(sender == itemNuevaVenta)
            {
                RegistrarVenta rg = new RegistrarVenta();
                rg.Show();
            }else
            {
                if(sender == itemConsultarVentas)
                {
                    ConsultaVentas cv = new ConsultaVentas();
                    cv.Show();
                }
            }


            //Cerrar Sesion

            if (sender == itemSalir)
            {
                this.Close();
            }else
            {
                if (sender == itemSalirEnfermeria)
                {
                    this.Close();
                }
            }

            //---------------------------------Modulo de administracion

            //Cirugias
            if (sender == itemconsultacirugia)
            {
                ConsultaCatalogCirugias cccr = new ConsultaCatalogCirugias();
                cccr.Show();
            }
            else if(sender== itemcregistrarcirugia)  
            {
                 CatalogoCirugias rcccm = new CatalogoCirugias();
                rcccm.Show();
            }

            if (sender == itemCargarCirugia)
            {
                CargarCirugia cc = new CargarCirugia();
                cc.Show();
            }else
            {
                if (sender == itemMostrarCirugiasCargadas)
                {
                    ConsultarCirugiasAplicadas cca = new ConsultarCirugiasAplicadas();
                    cca.Show();
                }
            }

            //Cuartos
            if(sender == itemregistrarcuarto)
            {
                CatalogoCuartos catcuartor = new CatalogoCuartos();
                catcuartor.Show();
            }
            else if(sender == itemconsultarcuarto)
            {
                ConsultaCatalogoCuartos concatcuarm = new ConsultaCatalogoCuartos();
                concatcuarm.Show();
            }else
            {
                if (sender == itemCuartosDisponibles)
                {
                    CuartosDisponibles cd = new CuartosDisponibles();
                    cd.Show();
                }
            }
            //Equipo Hospital

            if (sender == itemregistrareuipoh)
            {
                CatalogoEquipoHospital cehr = new CatalogoEquipoHospital();
                cehr.Show();
            }
            else if (sender == itemconsultaequipoh)
            {
                ConsultaCatalogoEquipoHospital ccehm = new ConsultaCatalogoEquipoHospital();
                ccehm.Show();
            }

            //Especialidades Medicos

            if (sender == itemregistrarespecialidad)
            {
                CatalogoEspecialidades espr = new CatalogoEspecialidades();
                espr.Show();
            }
            else if (sender == itemconsultarespecialidad)
            {
                ConsultarCatalogoEspecialidades espc = new ConsultarCatalogoEspecialidades();
                espc.Show();
            }

            //Especialidades Enfermeras

            
                if (sender == itemregistrarespecialidadesenf)
            {
                CatalogoEspecialidadesEnfermeras esper = new CatalogoEspecialidadesEnfermeras();
                esper.Show();
            }
            else if (sender == itemconsultarespecialidadesenf)
            {
                ConsultarCatalogoEspecialidadesEnfermeras espec = new ConsultarCatalogoEspecialidadesEnfermeras();
                espec.Show();
            }
            
             //Enfermeras
            if (sender == itemNuevaEnfermera)
            {
                NuevaEnfermera enfe = new NuevaEnfermera();
                enfe.Show();
            }
            else
            {
                if (sender == itemConsultaEnfermera)
                {
                    ConsultaEnfermera conenfe = new ConsultaEnfermera();
                    conenfe.Show();
                }
            }

            //Pacientes
            if (sender == itemRegistrarPaciente)
            {
                IngresoPaciente ip = new IngresoPaciente();
                ip.Show();
            }else
            {
                if (sender == itemVisualizarPacientes)
                {
                    ConsultaPacientes cp = new ConsultaPacientes();
                    cp.Show();
                }
            }

            if (sender == itemNuevoDeposito)
            {
                RegistrarDeposito rd = new RegistrarDeposito();
                rd.Show();
            }

            //Estudios cargas
            if(sender == itemCargarEstudio)
            {
                CargarEstudios ce = new CargarEstudios();
                ce.Show();
            }else
            {
                if (sender == itemVisualizarEstudiosAplicados)
                {
                    EstudiosAplicados ea = new EstudiosAplicados();
                    ea.Show();
                }
            }

        }


        private void RadMenuItem_Click_1(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
