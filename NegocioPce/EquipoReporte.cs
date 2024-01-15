using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioPce
{
    public class EquipoReporte
    {
        public int ReporteEquiposFemeninos()
        {
            return Convert.ToInt32(CommonPce.ModelEquipo.spObtenerCantidadEquiposFemeninos().First().Value);
        }

        public int ReporteEquiposMasculinos()
        {
            return Convert.ToInt32(CommonPce.ModelEquipo.spObtenerCantidadEquiposMasculinos().First().Value);
        }
    }
}
