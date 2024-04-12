using SkyNetModel.DTO;
using SkyNetModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyNet
{
    public partial class Program
    {
        static void IngresarTerminator()
        {
            string numeroSerie;
            string tipo;
            string prioridadBaseStr;
            string objetivo;
            string destinoStr;

            int prioridadBase = default(int);
            int prioridad = default(int);
            Int32 destino = default(Int32);

            bool valido = false;
            TerminatorDAL terminatorDal = new TerminatorDAL();
            do
            {
                Console.WriteLine("Ingrese número de serie del Terminator.");
                numeroSerie = Console.ReadLine().Trim();

                List<string> numerosSerie = new TerminatorDAL().ObtenerNumerosSerie();
                if (numeroSerie.Length == 7 && !numerosSerie.Contains(numeroSerie))
                {
                    valido = true;
                } else if (numerosSerie.Contains(numeroSerie))
                {
                    Console.WriteLine("Número de serie en uso. Ingrese otro.");
                }
            } while (!valido);

            

            do
            {
                Console.WriteLine("Ingrese tipo del Terminator.");
                tipo = Console.ReadLine().Trim();
                if (!terminatorDal.tiposValidos.Contains(tipo))
                {
                    Console.WriteLine("Tipo inválido.");
                }
            } while (!terminatorDal.tiposValidos.Contains(tipo));

            do
            {
                Console.WriteLine("Ingrese prioridad base del Terminator.");
                prioridadBaseStr = Console.ReadLine().Trim();
            } while (!int.TryParse(prioridadBaseStr, out prioridadBase));

            Console.WriteLine("Ingrese objetivo del Terminator.");
            objetivo = Console.ReadLine().Trim();

            valido = false;
            do
            {
                Console.WriteLine("Ingrese año de destino del Terminator.");
                destinoStr = Console.ReadLine().Trim();
                if (Int32.TryParse(destinoStr, out destino) && destino > 1997 && destino < 3000)
                {
                    valido = true;
                }

            } while (!valido);

            Terminator t = new Terminator()
            {
                NumeroSerie = numeroSerie,
                Tipo = tipo,
                PrioridadBase = prioridadBase,
                Prioridad = (objetivo == "Sarah Connor") ? 999 : prioridadBase,
                Objetivo = objetivo,
                Destino = destino
            };

            terminatorDal.AgregarTerminator(t);

        }

        static void BuscarTerminator()
        {
            Console.WriteLine("Ingrese modelo del Terminator a buscar");
            string filtroModelo = Console.ReadLine().Trim();

            Console.WriteLine("Ingrese año de destino del Terminator a buscar");
            string filtroDestino = Console.ReadLine().Trim();

            List<Terminator> lista = new TerminatorDAL().FiltrarTerminators(filtroModelo, filtroDestino);
            ImprimirTerminatorsDesdeLista(lista);
        }

        static void MostrarTerminators()
        {
            List<Terminator> lista = new TerminatorDAL().ObtenerTerminators();
            ImprimirTerminatorsDesdeLista(lista);
        }

        static void ImprimirTerminatorsDesdeLista(List<Terminator> lista)
        {
            foreach (Terminator t in lista)
            {
                Console.WriteLine(t.NumeroSerie + " " + t.Tipo + " " + t.Objetivo);
            }
        }
    }
}
