using Medica2.Administracion;
using Medica2.Administracion.Cirugias;
using Medica2.Administracion.ConsultasMedicas;
using Medica2.Administracion.Cuartos;
using Medica2.Administracion.Cuentas;
using Medica2.Administracion.Depositos;
using Medica2.Administracion.Empleados;
using Medica2.Administracion.Enfermeras;
using Medica2.Administracion.EquipoHospital;
using Medica2.Administracion.Especialidades;
using Medica2.Administracion.EspecialidadesEnfermeras;
using Medica2.Administracion.Estudios;
using Medica2.Administracion.HonorarioMedicos;
using Medica2.Administracion.Medicos;
using Medica2.Administracion.Pacientes;
using Medica2.Administracion.Reportes;
using Medica2.Administracion.Usuarios;
using Medica2.Enfermeria.Pacientes;
using Medica2.Enfermeria.Suministros;
using Medica2.Farmacia;
using Medica2.Farmacia.Compras;
using Medica2.Farmacia.Compras.Reportes;
using Medica2.Farmacia.Conversion;
using Medica2.Farmacia.Devoluciones;
using Medica2.Farmacia.Materiales;
using Medica2.Farmacia.Materiales.Reportes;
using Medica2.Farmacia.Medicamentos;
using Medica2.Farmacia.Medicamentos.Reportes;
using Medica2.Farmacia.Proveedores;
using Medica2.Farmacia.Proveedores.Reportes;
using Medica2.Farmacia.Ventas;
using Medica2.Farmacia.Ventas.Reportes;
using System;
using System.Windows;
using Telerik.Windows.Controls;

namespace Medica2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int idusuario;
        int iduu;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(int idusu)
        {
            InitializeComponent();
            idusuario = idusu;
            var usuario = BaseDatos.GetBaseDatos().USUARIOS.Find(idusuario);
            if (usuario.EMPLEADO.PUESTO == "Administrador")
            {
                MenuAdministracion.IsEnabled = true;
                MenuFarmacia.IsEnabled = true;
                MenuEnfermeria.IsEnabled = true;
                
            }else
            {
                if (usuario.EMPLEADO.PUESTO == "Farmaceutico")
                {
                    MenuAdministracion.Visibility = Visibility.Hidden;
                    SubAdministracion.Visibility = Visibility.Hidden;
                    MenuEnfermeria.Visibility = Visibility.Hidden;
                    SubEnfermeria.Visibility = Visibility.Hidden;
                }else
                {
                    if (usuario.EMPLEADO.PUESTO == "Enfermeria")
                    {
                        MenuAdministracion.Visibility = Visibility.Hidden;
                        SubAdministracion.Visibility = Visibility.Hidden;
                        MenuFarmacia.Visibility = Visibility.Hidden;
                        SubFarmacia.Visibility = Visibility.Hidden;
                        itemVisualizarSuministros.Visibility = Visibility.Hidden;
                    }else
                    {
                        if (usuario.EMPLEADO.PUESTO == "Recepcionista")
                        {
                            MenuEnfermeria.Visibility = Visibility.Hidden;
                            SubEnfermeria.Visibility = Visibility.Hidden;
                            MenuFarmacia.Visibility = Visibility.Hidden;
                            SubFarmacia.Visibility = Visibility.Hidden;
                            apartadoMedicos.Visibility = Visibility.Hidden;
                            apartadoMedicos.Visibility = Visibility.Hidden;
                        }else
                        {
                            if (usuario.EMPLEADO.PUESTO == "Medico")
                            {
                                MenuEnfermeria.Visibility = Visibility.Hidden;
                                SubEnfermeria.Visibility = Visibility.Hidden;
                                MenuFarmacia.Visibility = Visibility.Hidden;
                                SubFarmacia.Visibility = Visibility.Hidden;
                                apartadoPacientes.Visibility = Visibility.Hidden;
                                apartadoEmpleados.Visibility = Visibility.Hidden;
                                apartadoCatalogos.Visibility = Visibility.Hidden;
                                apartadoCuentas.Visibility = Visibility.Hidden;
                                subEstudios.Visibility = Visibility.Hidden;
                                subCirugias.Visibility = Visibility.Hidden;
                                subEquipoHospital.Visibility = Visibility.Hidden;
                                subHonorarios.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                }
            }
        }

        private void RadMenuItem_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {

            if (sender == itemReporteMedicamentos)
            {
                RporteMedicamentos rm = new RporteMedicamentos();
                rm.Show();
            }

            if (sender == itemReporteCompras)
            {
                RCompras rc = new RCompras();
                rc.Show();
            }

            if (sender == itemReporteProveedor)
            {
                RProveedores rp = new RProveedores();
                rp.Show();
            }

            if (sender == itemReporteMateriales)
            {
                RMateriales rm = new RMateriales();
                rm.Show();
            }

            if (sender == itemReportesSolicitudesEnfermeras)
            {
                RSolicitudEnfermeras rpe = new RSolicitudEnfermeras();
                rpe.Show();
            }

            if (sender == itemReportesSolicitudesMedicos)
            {
                RMaterMedicos rmm = new RMaterMedicos();
                rmm.Show();
            }
            if (sender == itemReporteVentas)
            {
                RVentasGenerales rvg = new RVentasGenerales();
                rvg.Show();
            }

            //Enfermeria
            if (sender == itemEnfermerasPacientes)
            {
                MostrarPacientes mp = new MostrarPacientes(idusuario);
                mp.Show();
            }else
            {
                if (sender == itemSalirEnfermeria)
                {
                    Login l = new Login();
                    l.Show();
                    this.Close();
                }
            }

            //Devoluciones
            if (sender == itemDevolucion)
            {
                DevolucionPacientes dp = new DevolucionPacientes(idusuario);
                dp.Show();
            }else
            {
                if (sender == itemVisualizarDevoluciones)
                {
                    ConsultarDevoluciones cd = new ConsultarDevoluciones();
                    cd.Show();
                }else
                {
                    if (sender == itemVisualizarSuministros)
                    {
                        VisualizarSuministros vs = new VisualizarSuministros(idusuario);
                        vs.Show();
                    }
                }
            }

            // Proveedores
            if (sender == addProveedor) {
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
            if (sender == itemConsultarMaterial)
            {
                ConsultaMaterial mat = new ConsultaMaterial();
                mat.Show();
            }
            else
            {
                if (sender == itemMaterialEnfermera)
                {
                    SolicitudEnfermera solenf = new SolicitudEnfermera(idusuario);
                    solenf.Show();
                }
                else
                {
                    if (sender == itemMaterialDoctor)
                    {
                        SolicitudDoctor soldoc = new SolicitudDoctor(idusuario);
                        soldoc.Show();
                    } else
                    {
                        if (sender == itemConsultarSolicitudMaterialEnfermera)
                        {
                            ConsultarSolicitudEnfermera cd = new ConsultarSolicitudEnfermera(idusuario);
                            cd.Show();
                        } else
                        {
                            if (sender == itemConsultarSolicitudMaterialDoctor)
                            {
                                ConsultarSolicitudDoctor cdoc = new ConsultarSolicitudDoctor(idusuario);
                                cdoc.Show();
                            }
                        }
                    }
                }
            }
            //}

            //Medicamentos
            if (sender == itemNuevoMedicamentos)
            {
                RegistroMedicamento nmedi = new RegistroMedicamento();
                nmedi.Show();
            } else
            {
                if (sender == itemShowMedi)
                {
                    ConsultaMedicamentos cmed = new ConsultaMedicamentos(idusuario);
                    cmed.Show();
                } else
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
                NuevaCompra rcom = new NuevaCompra(idusuario, iduu);
                rcom.Show();
            }
            else
            {
                if (sender == itemComprasdelDia)
                {
                    ConsultaCompras mcom = new ConsultaCompras(idusuario);
                    mcom.Show();
                }
            }

            //Ventas
            if (sender == itemNuevaVenta)
            {
                RegistrarVenta rg = new RegistrarVenta(idusuario, iduu);
                rg.Show();
            } else
            {
                if (sender == itemConsultarVentas)
                {
                    ConsultaVentas cv = new ConsultaVentas(idusuario);
                    cv.Show();
                }
            }


            //Cerrar Sesion

            if (sender == itemFarmaciaSalir)
            {
                Login l = new Login();
                l.Show();
                this.Close();
            } else
            {
                if (sender == itemSalirEnfermeria)
                {
                    this.Close();
                    Login l = new Login();
                    l.Show();
                }
            }

            //---------------------------------Modulo de administracion

            //Cirugias
            if (sender == itemconsultacirugia)
            {
                ConsultaCatalogCirugias cccr = new ConsultaCatalogCirugias();
                cccr.Show();
            }
            else if (sender == itemcregistrarcirugia)
            {
                CatalogoCirugias rcccm = new CatalogoCirugias();
                rcccm.Show();
            }

            if (sender == itemCargarCirugia)
            {
                CargarCirugia cc = new CargarCirugia(idusuario);
                cc.Show();
            }
            else
            {
                if (sender == itemMostrarCirugiasCargadas)
                {
                    ConsultarCirugiasAplicadas cca = new ConsultarCirugiasAplicadas(idusuario);
                    cca.Show();
                }
            }
            if (sender == itemReporteciruCargadas)
            {
                R_Cirugias_Aplicadas rgc = new R_Cirugias_Aplicadas();
                rgc.Show();
            }

            //Cuartos
            if (sender == itemregistrarcuarto)
            {
                NuevoCuarto catcuartor = new NuevoCuarto();
                catcuartor.Show();
            }
            else if (sender == itemconsultarcuarto)
            {
                ConsultaCatalogoCuartos concatcuarm = new ConsultaCatalogoCuartos();
                concatcuarm.Show();
            }
            else
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
                //Para catalogo equipo Hospital
                ConsultaEquipoHospital ccehm = new ConsultaEquipoHospital();
                ccehm.Show();
            }
            //CargarEquipoHospital
            if (sender == itemcargarequipoh)
            {
                CargarEquipoHospital obj = new CargarEquipoHospital(idusuario);
                obj.Show();
            }
            if (sender == itemVisualizarEquipoHospitalCargado)
            {
                //para vizualizar equipo h aplicados
                VerEquipoHospitalCargado cc = new VerEquipoHospitalCargado(idusuario);
                cc.Show();
            }


            if (sender == itemReportecargaequipoh)
            {
                R_Equipo_Hcargado obj = new R_Equipo_Hcargado();
                obj.Show();
            }
            //Medicos

            if (sender == itemNuevoMedico)
            {
                NuevoMedico nmed = new NuevoMedico();
                nmed.Show();
            }
            else if (sender == itemitemConsultaMedicos)
            {
                MostrarMedicos mmed = new MostrarMedicos(idusuario);
                mmed.Show();
            }
            if (sender == itemitemReporteMedicos)
            {
                M_A_R o = new M_A_R();
                o.Show();
            }

            //Especialidades Medicos

            if (sender == itemregistrarespecialidad)
            {
                NuevaEspecialidadMedico espr = new NuevaEspecialidadMedico();
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
                    ConsultaEnfermera conenfe = new ConsultaEnfermera(idusuario);
                    conenfe.Show();
                }
            }
            if (sender == itemRéporteEnfermera)
            {
                Reporte_Enfermeras o = new Reporte_Enfermeras();
                o.Show();
            }

            //Estudios
            if (sender == itemregistrarestudio)
            {
                NuevoEstudio nestudio = new NuevoEstudio();
                nestudio.Show();
            }
            else
            if (sender == itemconsultarestudio)
            {
                MostrarEstudios mestu = new MostrarEstudios();
                mestu.Show();
            }
            if (sender == itemReporteEstudiosAplicados)
            {
                R_Estu_Cargado o = new R_Estu_Cargado();
                o.Show();
            }

            // Registro Pacientes
            if (sender == itemRegistrarPaciente)
            {
                IngresoPaciente ip = new IngresoPaciente();
                ip.Show();
            }
            else
            {
                if (sender == itemVisualizarPacientes)
                {
                    ConsultaPacientes cp = new ConsultaPacientes(idusuario);
                    cp.Show();
                }
            }
            if (sender == itemReporte)
            {
                R_Pacientes_H obj = new R_Pacientes_H();
                obj.Show();
            }

            //-----REgistro de Empleados(Usuarios)
            if (sender == itemRegistrarUsuario)
            {
                RegistroEmpleados obj = new RegistroEmpleados();
                obj.Show();
            }
            else
            {
                if (sender == itemVizualizarUsuarios)
                {
                    MostrarEmpleados obj = new MostrarEmpleados(idusuario);
                    obj.Show();
                }
            }
            if (sender == itemReporteUsuarios)
            {
                R_Empleados o = new R_Empleados();
                o.Show();
            }

            //Depositos
            if (sender == itemNuevoDeposito)
            {
                RegistrarDeposito rd = new RegistrarDeposito(idusuario);
                rd.Show();
            }
            else
            {
                if (sender == itemConsultarDepositosAplicados)
                {
                    ConsultarDepositosAplicados cda = new ConsultarDepositosAplicados();
                    cda.Show();
                }
            }
            if (sender == itemreporteDeposito)
            {
                Re_Depositos o = new Re_Depositos();
                o.Show();
            }

            //Cargar estudios
            if (sender == itemCargarEstudio)
            {
                CargarEstudios ce = new CargarEstudios(idusuario);
                ce.Show();
            }
            else
            {
                if (sender == itemVisualizarEstudiosAplicados)
                {
                    EstudiosAplicados ea = new EstudiosAplicados(idusuario);
                    ea.Show();
                }
            }

            //Carga de Honorarios
            if (sender == itemcargarHonorarios)
            {
                CargarHonorarioMedico obj = new CargarHonorarioMedico(idusuario);
                obj.Show();
            }
            else if (sender == itemvizualizarHonorarios)
            {
                VizualizarHonorariosCargados obj = new VizualizarHonorariosCargados(idusuario);
                obj.Show();
            }
            if (sender == itemReporteHonorarios)
            {
                R_Honorarios_Med hon = new R_Honorarios_Med();
                hon.Show();
            }

            //Consultas
            if (sender == itemregistrarConsultas)
            {
                RegistrarConsulta obj = new RegistrarConsulta(idusuario);
                obj.Show();
            }
            else
                if (sender == itemvizualizarconsultas)
            {
                VisualizarConsultas obj = new VisualizarConsultas(idusuario);
                obj.Show();
            }
            if (sender == itemReporteconsultas)
            {
                R_Consultas_realzadas obj = new R_Consultas_realzadas();
                obj.Show();
            }

            //Cuentas
            if (sender == itemvizualizacuentas)
            {
                VizualizarCuentas obj = new VizualizarCuentas();
                obj.Show();
            }
            else
            {
                if (sender == itemREPORTEcuentas)
                {
                    R_Cuentas obj = new R_Cuentas();
                    obj.Show();

                }
            }

        }


        private void RadMenuItem_Click_1(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

       
    }
}
