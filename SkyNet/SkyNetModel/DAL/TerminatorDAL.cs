using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyNetModel.DTO;

namespace SkyNetModel.DAL
{
    public class TerminatorDAL
    {
        private static List<Terminator> terminators = new List<Terminator>();
        public string[] tiposValidos = { "T-1", "T-800", "T-1000", "T-3000" };

        public void AgregarTerminator(Terminator t)
        {
            terminators.Add(t);
        }

        public List<Terminator> ObtenerTerminators()
        {
            return terminators;
        }

        public List<Terminator> FiltrarTerminators(string tipo, string destinoStr)
        {
            Int32 destino = Int32.Parse(destinoStr);
            return terminators.FindAll(t => t.Tipo == tipo && t.Destino == destino);
        }

        public List<string> ObtenerNumerosSerie()
        {
            List<string> numerosSerie = new List<string>();
            foreach (Terminator t in terminators)
            {
                numerosSerie.Add(t.NumeroSerie);
            }
            return numerosSerie;
        }
    }
}
