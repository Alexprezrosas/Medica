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

namespace Medica2.Administracion.Cuentas
{
    /// <summary>
    /// Lógica de interacción para VizualizarCuentas.xaml
    /// </summary>
    public partial class VizualizarCuentas : Window
    {
        public VizualizarCuentas()
        {
            InitializeComponent();
            //rgvcuentas.ItemsSource = BaseDatos.GetBaseDatos().CUENTAS.ToList();
            CargarVista();
        }
        void CargarVista()
        {
            rgvcuentas.ItemsSource = (from PERSONA in BaseDatos.GetBaseDatos().PERSONAS
                                      join e in BaseDatos.GetBaseDatos().PACIENTES
                                      on PERSONA.ID_PERSONA equals e.PERSONAID
                                      join f in BaseDatos.GetBaseDatos().FAM_RESPONSABLES
                                      on e.ID_PACIENTE equals f.PACIENTEID
                                      join cuenta in BaseDatos.GetBaseDatos().CUENTAS
                                      on e.ID_PACIENTE equals cuenta.PACIENTEID
                                      join estado in BaseDatos.GetBaseDatos().ESTADOS
                                      on PERSONA.ESTADO equals estado.id
                                      select new
                                      {
                                          ID_PACIENTE = e.ID_PACIENTE,
                                          ID_FAMILIAR = f.ID_FAM_RESPOSABLE,
                                          NOMBRE = PERSONA.NOMBRE,
                                          APATERNO = PERSONA.A_PATERNO,
                                          AMATERNO = PERSONA.A_MATERNO,
                                          F_NACIMIENTO = PERSONA.F_NACIMIENTO,
                                          CALLE = PERSONA.CALLE,
                                          ESTADO = estado.nombre,
                                          CURP = PERSONA.CURP,
                                          TIPOPACIENTE = e.TIPO_PACIENTE,
                                          RESPONSABLE = f.PERSONA.NOMBRE,
                                          TELEFONO = f.PERSONA.T_CELULAR,
                                          PARENTESCO = f.PARENTESCO,
                                          CUENTAA = cuenta.TOTAL,
                                          SALDO = cuenta.SALDO,
                                          ESTADOO = cuenta.ESTADO,
                                          FECHA_CREACIONN = cuenta.FECHA_CREACION,
                                      }).ToList();
        }


    }
}
