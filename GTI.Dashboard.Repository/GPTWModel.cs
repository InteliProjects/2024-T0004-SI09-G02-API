using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public class GPTWModel
    {
        public int Nniveis { get; set; }
        public string? UoAbrev { get; set; }
        public string? UmNvel { get; set; }
        public string? DoisNvel { get; set; }
        public string? TresNvel { get; set; }
        public string? QuatroNvel { get; set; }
        public string? CincoNvel { get; set; }
        public string? SeisNvel { get; set; }
        public string? SeteNvel { get; set; }
        public string? OitoNvel { get; set; }
        public int Npess { get; set; }
        public string? Rrh{ get; set; }
        public string? Local { get; set; }
        public int Empr { get; set; }
        public int Gremp { get; set; }
        public string? Grempregados { get; set; }
        public string? Sgemp { get; set; }
        public int Centrocst { get; set; }
        public int Unidorg { get; set; }
        public string? DescrUo { get; set; }
        public string? UoAbrevUm { get; set; }
        public int Idadedoempregado { get; set; }
        public int gn { get; set; }
        public string? Tpausp { get; set; }
        public string? Txttipopresenaausn { get; set; }
        public string? Incio { get; set; }
        public string? Fim { get; set; }
        public  int Cargo { get; set; }
        public string? CargoUm { get; set; }
        public string? DataAdm{ get; set; }
        public string? Ano { get; set; }
        public string? EngajamentoPorcentagem { get; set; }
        public string? IndexVerdade { get; set; }
        public string? AuditCultura { get; set; }
        public string? Escala { get; set; }
        public string? Pergunta { get; set; }
        public double AverageScore { get; set; }
    }
}