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
            double a = 0.7666, b = 1051;
            Random r = new Random();
            y = r.NextDouble();

            x = a * Math.Pow(- Math.Log(1 - y), 1 / b);

            return x;
        }

        public static double getTiempoAtencionSaliente()
        {
            double x, y;
            double a = 1.1352, b = 5.6551;
            Random r = new Random();
            y = r.NextDouble();

            double argRaiz = (1/y) - 1;
            x = b / Math.Pow(argRaiz, 1 / a);

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

        internal static bool arrepentimiento(double tiempoEspera)
        {
            bool arrepentimiento;
            // e > 5min
            if (tiempoEspera >= (60 * 5))
            {
                arrepentimiento = true;
            }
            else
            {
                if (tiempoEspera <= (2 * 60))
                {
                    arrepentimiento = false;
                }
                else
                {
                    Random r = new Random();
                    if (r.NextDouble() <= 0.4)
                    {
                        arrepentimiento = false;
                    }
                    else
                    {
                        arrepentimiento = true;
                    }
                }
            }
            return arrepentimiento;

        }
    }
}
