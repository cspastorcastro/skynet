using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyNetModel.DTO
{
    public class Terminator
    {
        public string NumeroSerie { get; set; } // 7 caracteres, único
        public string Tipo { get; set; } // T-1, T-800, T-1000, T-3000
        public int PrioridadBase { get; set; }
        public int Prioridad { get; set; }
        public string Objetivo { get; set; } // Si el objetivo es Sarah Connor, prioridad = 999, si no, prioridad = prioridadBase
        public Int32 Destino { get; set; } // > 1997 && < 3000
    }
}
