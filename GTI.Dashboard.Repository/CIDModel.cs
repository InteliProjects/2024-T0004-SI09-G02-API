using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public class CIDModel
    {
        public string? Mes {  get; set; }
        public int N_pessoal { get; set; }
        public int Atestados { get; set; }
        public string? Dias { get; set; }
        public string? Diretoria { get; set; }
        public string? Unidade { get; set; }
        public string? Genero { get; set; }
        public string? Categoria { get; set; }
        public string? Cid { get; set; }
        public string? DescricaoDetalhada { get; set; }
        public string? DescricaoResumida { get; set; }
        public string? DiagnosticoAtestadoInicial { get; set; }
        public string? CausaRaiz { get; set; }
        public string? Outros { get; set; }
        public string? Jornada { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeAtestados { get; set; }
        public int QuantidadeAfastamentos { get; set; }

    }
}
