using Medica2.Administracion;
using Medica2.Administracion.Cirugias;
using Medica2.Administracion.Cuartos;
using Medica2.Administracion.Enfermeras;
using Medica2.Administracion.EquipoHospital;
using Medica2.Administracion.Especialidades;
using Medica2.Administracion.EspecialidadesEnfermeras;
using Medica2.Farmacia;
using Medica2.Farmacia.Materiales;
using Medica2.Farmacia.Medicamentos;
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
           

            // Proveedores
            if(sender == addProveedor){
                Proveedores prov = new Proveedores();
                prov.Show();
            }
            else
            {
                if (sender == conProveedor)
                {
                    ConsultaProveedores cprov = new ConsultaProveedores();
                    cprov.Show();
                }
                
                
            }

            //Materiales
            if (sender == itemNuevoMaterial)
            {
                NuevoMaterial nuMat = new NuevoMaterial();
                nuMat.Show();
            }else
            {
                if (sender == itemConsultarMaterial)
                {
                    VizualizarMateriales vmat = new VizualizarMateriales();
                    vmat.Show();
                }
            }

            //Medicamentos
            if(sender == itemNuevoMedicamentos)
            {
                NuevoMedicamento nmedi = new NuevoMedicamento();
                nmedi.Show();
            }
            

            //Cerrar Sesion

            if (sender == itemSalir)
            {
                this.Close();
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

        }


        private void RadMenuItem_Click_1(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
