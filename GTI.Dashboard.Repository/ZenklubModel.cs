using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public class ZenklubModel
    {
        public string? Periodo { get; set; }
        public int Mes { get; set; }
        public string? Nome { get; set; }
        public int NPessoal { get; set; }
        public long CodigoValidacao { get; set; }
        public string? Departamento { get; set; }
        public int TotalSessoes { get; set; }

    }
}
