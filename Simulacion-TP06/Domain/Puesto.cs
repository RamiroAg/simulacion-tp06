using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_TP06.Domain
{
    public class Puesto
    {
        public double tiempoComprometido { get; set; }

        public double sumTiempoOcioso { get; set; }

        public int NS { get; set; }

        public int NArrepentidos { get; set; }

        public int NArrepentidosConPerdidas { get; set; }

        public double NT { get; set; }

        public double sumatoriaTE { get; set; }


        public Puesto()
        {
            tiempoComprometido = 0;
            sumTiempoOcioso = 0;
            NS = 0;
            NArrepentidos = 0;
            NArrepentidosConPerdidas = 0;
            NT = 0;
        }

        public static Puesto GetPuestoMenorTC(Puesto[] puestos)
        {
            return puestos.OrderBy(p => p.tiempoComprometido)
                    .FirstOrDefault();
        }
    }
}
