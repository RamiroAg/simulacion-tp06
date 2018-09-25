using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_TP06
{
    public class Services
    {
        public static double getIntervaloEntreLlamadas()
        {
            double x, y;
            double a = 0.67736, b = 10.099;
            Random r = new Random();
            y = r.NextDouble();

            x = a * Math.Pow(Math.Log(1 - y), 1 / b);

            return x;
        }

        public static double getTiempoAtencionSaliente()
        {
            double x, y;
            double a = 4.0361, b = 1.4677, k = 0.16281;
            Random r = new Random();
            y = r.NextDouble();

            double argRaiz = -k - (k / Math.Pow(y - 1, 1 / a));
            x = Math.Pow(argRaiz, 1 / b);

            return x;
        }

        internal static double getTiempoAtencionEntrante()
        {
            double x, y;
            double a = 0.64608, b = 233.91;
            Random r = new Random();
            y = r.NextDouble();

            double argRaiz = (1 - y) / y;
            x = a * Math.Pow(argRaiz, 1 / b);

            return x;
        }

        internal static bool arrepentimiento(object p)
        {
            throw new NotImplementedException();
        }
    }
}
