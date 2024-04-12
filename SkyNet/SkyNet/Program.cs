using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyNet
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            while (Menu());
            Console.ReadKey();
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("1. Ingresar Terminator");
            Console.WriteLine("2. Buscar Terminator");
            Console.WriteLine("3. Mostrar Terminators");
            Console.WriteLine("q. Salir");

            switch (Console.ReadLine().Trim())
            {
                case "1":
                    IngresarTerminator();
                    break;
                case "2":
                    BuscarTerminator();
                    break;
                case "3":
                    MostrarTerminators();
                    break;
                case "q":
                    Console.WriteLine("Programa finalizado.\nPresione cualquier tecla para salir...");
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            return continuar;
        }

    }
}
