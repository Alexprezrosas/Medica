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

namespace Medica2.Administracion.HonorarioMedicos
{
    /// <summary>
    /// Lógica de interacción para VizualizarHonorariosCargados.xaml
    /// </summary>
    public partial class VizualizarHonorariosCargados : Window
    {
        public VizualizarHonorariosCargados()
        {
            InitializeComponent();
            VistaCirugiasAplicadas();
        }
        public void VistaCirugiasAplicadas()
        {
            rgvVHonorariosc.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                           join e in BaseDatos.GetBaseDatos().PACIENTES
                                           on PERSONA.ID_PERSONA equals e.PERSONAID
                                           join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                           on e.ID_PACIENTE equals cuenta.PACIENTEID
                                           select new
                                           {
                                               ID_PACIENTE = e.ID_PACIENTE,
                                               NOMBRE = PERSONA.NOMBRE,
                                               APATERNO = PERSONA.A_PATERNO,
                                               CUENTAA = cuenta.TOTAL,
                                               ID_CUENTA = cuenta.ID_CUENTA
                                           }).ToList();
        }

    }
}
