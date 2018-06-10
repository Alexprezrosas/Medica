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

namespace Medica2.Administracion.Cirugias
{
    /// <summary>
    /// Lógica de interacción para ConsultarCirugiasAplicadas.xaml
    /// </summary>
    public partial class ConsultarCirugiasAplicadas : Window
    {
        public ConsultarCirugiasAplicadas()
        {
            InitializeComponent();
            VistaCirugiasAplicadas();
        }

        public void VistaCirugiasAplicadas()
        {
            rgvCirugiasAplicadas.ItemsSource = (from CIRUGIA in BaseDatos.GetBaseDatos().CIRUGIAS
                                                join cc in BaseDatos.GetBaseDatos().CATALOGO_CIRUGIAS
                                                on CIRUGIA.CATALOGO_CIRUGIAID equals cc.ID_CATALOGO_CIRUGIA
                                                join med in BaseDatos.GetBaseDatos().MEDICOS
                                                on CIRUGIA.MEDICOID equals med.ID_MEDICO
                                                join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                                on CIRUGIA.CUENTAID equals cuenta.ID_CUENTA
                                                join paci in BaseDatos.GetBaseDatos().PACIENTES
                                                on cuenta.PACIENTEID equals paci.ID_PACIENTE
                                                select new
                                                {
                                                    //ID_PACIENTE = paci.ID_PACIENTE,
                                                    ID_CIRUGIA = CIRUGIA.ID_CIRUGIA,
                                                    ID_MEDICO = med.ID_MEDICO,
                                                    ID_CAT_CIRUGIA = cc.ID_CATALOGO_CIRUGIA,
                                                    MEDICOSOL = med.PERSONA.NOMBRE,
                                                    PACIENTENOM = paci.PERSONA.NOMBRE,
                                                    CIRUGIANOM = cc.NOMBRE_CIRUGIA,
                                                    COSTO = cc.COSTO,
                                                    CUENTAA = cuenta.TOTAL,
                                                    SALDO = cuenta.SALDO,
                                                    FAPLICACION = CIRUGIA.FECHA_CREACION
                                                }).ToList();
        }

    }
}
