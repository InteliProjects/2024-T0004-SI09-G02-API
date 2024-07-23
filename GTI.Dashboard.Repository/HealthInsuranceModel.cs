namespace GTI.Dashboard.Repository
{
    public class HealthInsuranceModel
    {
        public int Id { get; set; }

        public string? NomeCliente { get; set; }

        public string? NomeBanco { get; set; }

        public string? NomeProduto { get; set; }

        public string? CodigoPessoa { get; set; }

        public string? NomePaciente { get; set; }

        public int CodigoPaciente { get; set; }

        public int Matricula { get; set; }

        public string? Cpf { get; set; }

        public string? DataNascimento { get; set; }

        public string? Sexo { get; set; }

        public string? Parentesco { get; set; }

        public int CodigoPlano { get; set; }

        public string? NomePlano { get; set; }

        public int GrupoFamiliar { get; set; }

        public string? DataEvento { get; set; }

        public int CodigoProcedimentoFinal { get; set; }

        public string? DescricaoProcedimentoFinal { get; set; }

        public int CodigoServico { get; set; }

        public string? DescricaoServico { get; set; }

        public string? TipoEventoCbhpm { get; set; }

        public string? TipoEventoFinal { get; set; }

        public string? TipoUtilizacao { get; set; }

        public int NumeroSubFatura { get; set; }

        public int NumeroContrato { get; set; }

        public double CodigoPrestador { get; set; }

        public string? NomePrestador { get; set; }

        public string? Especialidade { get; set; }

        public string? Sinistro { get; set; }

        public int NumeroEvento { get; set; }
        public string? Planta { get; set; }
        public int Ocorrencias { get; set; }

        public string? Ano { get; set; }
        public string? Mes { get; set;}
        public int? NumeroConsultas { get; set;}
        public string? DiaSemana { get; set; }
    }
}
