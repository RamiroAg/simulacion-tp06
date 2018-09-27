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
            double t = 0, tpll = 0, ill, ta, endTime;
            endTime = 10;
            Boolean esEntrante = false;        
     
            Random random = new Random();

            Console.WriteLine("Simulación - TP 06");
            Console.Write("Ingrese la cantidad de puestos de atención: ");
            int.TryParse(Console.ReadLine(), out int n);
            Console.Write("Ingrese la duración de la simulación (en horas): ");
            int.TryParse(Console.ReadLine(), out int tiempoSimulacion);
            endTime = tiempoSimulacion * 3600;

            Console.WriteLine();
            Console.WriteLine("Simulación en proceso...");
            Console.WriteLine();

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
                    if (random.Next(0,100) < 50)
                    {
                        if (random.Next(0, 100) < 70)
                        {
                            puestoI.NS++;
                        }
                    }      
                    esEntrante = false;
                }
                else
                {
                    ta = Services.getTiempoAtencionEntrante();
                    esEntrante = true;
                    puestoI.cantEntrantes++;
                }


                if (t <= puestoI.tiempoComprometido)
                {
                    if (esEntrante && Services.arrepentimiento(puestoI.tiempoComprometido - t))
                    {
                         puestoI.NArrepentidos++;
                        puestoI.cantEntrantes--;
                        if (random.Next(0,100) < 30)
                        {
                            puestoI.NArrepentidosConPerdidas++;
                        }
                    }
                    else
                    {
                        if (esEntrante)
                        {
                            puestoI.sumatoriaTE += (puestoI.tiempoComprometido - t);
                        }
                       
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
            //PTO(i): porcentaje de tiempo ocioso de cada puesto(Segundos)
            //PTE: promedio de tiempo de espera por puesto(Segundos)
            //PPA: porcentaje de personas arrepentidas(número de personas) respecto al total
            double totalArrepentidos = 0, NTTotal = 0;
            double ganancias = 0, perdidas = 0, gastos = n * 20000/20;


            Console.WriteLine();
            Console.WriteLine(" - CUADRO DE RESULTADOS");
            for (int j = 0; j < puestos.Length; j++)
            {

                Console.WriteLine("PUESTO {0}", j);
                Console.WriteLine(" - PTO{0}: {1} %", j, puestos[j].sumTiempoOcioso * 100 / t);
                Console.WriteLine(" - PTE{0}: {1}", j, puestos[j].sumatoriaTE / puestos[j].cantEntrantes);
                Console.WriteLine();
                ganancias += puestos[j].NS * random.Next(300/12, 20000/12);
                perdidas += puestos[j].NArrepentidosConPerdidas * random.Next(300/6, 20000/6);          

                totalArrepentidos += puestos[j].NArrepentidos;
                NTTotal += puestos[j].NT;
            }

            Console.WriteLine("TOTAL LLAMADAS PROCESADAS: {0}", NTTotal);
            Console.WriteLine("PORCENTAJE DE PERSONAS ARREPENTIDAS: {0} %", totalArrepentidos * 100 / NTTotal);
            Console.WriteLine("INGRESOS: {0}", ganancias - gastos - perdidas);
            Console.WriteLine("Presione cualquier tecla para finalizar");


            //Impresión de resultados


            Console.Read();
        }
    }
}
