using Simulacion_TP06.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_TP06
{
    class Program
    {
        static void Main(string[] args)
        {
            double t = 0, tpll = 0, ill, ta, endTime, na = 0;
            endTime = 10;

            Random random = new Random();

            Console.WriteLine("Simulación - TP 06");
            Console.WriteLine("Ingrese la cantidad de puestos de atención: ");
            int.TryParse(Console.ReadLine(), out int n);
            Console.WriteLine("La simulación se realizará con {0} puestos de atención", n);
            

            //Inicializo array de puestos
            Puesto[] puestos = new Puesto[n];
            for (int i = 0; i < n; i++)
            {
                puestos[i] = new Puesto();
            }

            Puesto puestoI;
            int r = 0;

            do
            {
                t = tpll;
                ill = Services.getIntervaloEntreLlamadas();
                tpll = t + ill;
                puestoI = Puesto.GetPuestoMenorTC(puestos);

                r = random.Next(0, 100);
                if (r < 90)
                {
                    ta = Services.getTiempoAtencionSaliente();
                }
                else
                {
                    ta = Services.getTiempoAtencionEntrante();
                }


                if (t <= puestoI.tiempoComprometido)
                {
                    if (Services.arrepentimiento(puestoI.tiempoComprometido - t))
                    {
                         na++;
                    }
                    else
                    {
                        puestoI.sumatoriaTE += (puestoI.tiempoComprometido - t);
                        puestoI.tiempoComprometido += ta;
                    }
                }
                else
                {
                    puestoI.sumTiempoOcioso += (t - puestoI.tiempoComprometido);
                    puestoI.tiempoComprometido = t + ta;
                }

                puestoI.NT++;

            } while (t <= endTime);


            //Cálculo de resultados

            //Impresión de resultados


            Console.Read();
        }
    }
}
