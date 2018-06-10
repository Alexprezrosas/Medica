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

namespace Medica2.Administracion.Estudios
{
    /// <summary>
    /// Lógica de interacción para EstudiosAplicados.xaml
    /// </summary>
    public partial class EstudiosAplicados : Window
    {
        public EstudiosAplicados()
        {
            InitializeComponent();
            VistaEstudiosAplicados();
        }

        public void VistaEstudiosAplicados()
        {
            rgvEstudiosAplicados.ItemsSource = (from ESTUDIOS in BaseDatos.GetBaseDatos().ESTUDIOS
                                                join ce in BaseDatos.GetBaseDatos().CATALOGO_ESTUDIOS
                                                on ESTUDIOS.CATALOGO_ESTUDIOS_ID equals ce.CATALOGO_ESTUDIO_ID
                                                join med in BaseDatos.GetBaseDatos().MEDICOS
                                                on ESTUDIOS.MEDICOID equals med.ID_MEDICO
                                                join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                                on ESTUDIOS.CUENTAID equals cuenta.ID_CUENTA
                                                join paci in BaseDatos.GetBaseDatos().PACIENTES
                                                on cuenta.PACIENTEID equals paci.ID_PACIENTE
                                                join usu in BaseDatos.GetBaseDatos().USUARIOS
                                                on ESTUDIOS.USUARIOID equals usu.ID_USUARIO
                                                select new
                                                {
                                                    //ID_PACIENTE = paci.ID_PACIENTE,
                                                    ID_ESTUDIO = ESTUDIOS.ID_ESTUDIO,
                                                    ID_MEDICO = med.ID_MEDICO,
                                                    ID_CAT_ESTUDIO = ce.CATALOGO_ESTUDIO_ID,
                                                    MEDICOSOL = med.PERSONA.NOMBRE,
                                                    PACIENTENOM = paci.PERSONA.NOMBRE,
                                                    ESTUDIONOM = ce.NOMBRE,
                                                    COSTO = ce.COSTO,
                                                    CUENTAA = cuenta.TOTAL,
                                                    SALDO = cuenta.SALDO,
                                                    FAPLICACION = ESTUDIOS.FECHA_CREACION,
                                                    USUARIO = usu.EMPLEADO.PERSONA.NOMBRE
                                                }).ToList();
        }

    }
}
