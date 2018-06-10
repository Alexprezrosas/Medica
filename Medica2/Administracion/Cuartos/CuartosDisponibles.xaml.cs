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

namespace Medica2.Administracion.Cuartos
{
    /// <summary>
    /// Lógica de interacción para CuartosDisponibles.xaml
    /// </summary>
    public partial class CuartosDisponibles : Window
    {
        public CuartosDisponibles()
        {
            InitializeComponent();
            vistaRadGrid();
        }

        void vistaRadGrid()
        {
            rgvCuartosDisponibles.ItemsSource = (from CATALOGO_CUARTOS in BaseDatos.GetBaseDatos().CATALOGO_CUARTOS
                                        where CATALOGO_CUARTOS.ESTADO == "Libre"
                                        select new
                                        {
                                            ID_CUARTO = CATALOGO_CUARTOS.ID_CATALOGO_CUARTO,
                                            NOMBRE_CUARTO = CATALOGO_CUARTOS.NOMBRE_CUARTO,
                                            DESCRIPCION = CATALOGO_CUARTOS.DESCRIPCION,
                                            COSTO = CATALOGO_CUARTOS.COSTO,
                                            ESTADO = CATALOGO_CUARTOS.ESTADO,
                                            MAX_PACIENTES = CATALOGO_CUARTOS.MAX_PACIENTES
                                        }).ToList();
        }

    }
}
