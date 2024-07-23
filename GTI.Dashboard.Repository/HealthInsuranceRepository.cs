using Dapper;
using Npgsql;

namespace GTI.Dashboard.Repository
{
    public class HealthInsuranceRepository : IHealthInsuranceRepository
    {
        private readonly string _dbConfig;

        public HealthInsuranceRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<HealthInsuranceModel> GetHealthInsuranceById(int id)
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<HealthInsuranceModel>(@"
                    SELECT
                        nome_cliente AS NomeCliente,
                        nome_banco AS NomeBanco,
                        nome_produto AS NomeProduto,
                        codigopessoa AS CodigoPessoa,
                        nome_paciente AS NomePaciente,
                        codigo_paciente AS CodigoPaciente,
                        matricula AS Matricula,
                        cpf AS Cpf,
                        data_nascimento AS DataNascimento,
                        sexo AS Sexo,
                        parentesco AS Parentesco,
                        codigo_plano AS CodigoPlano,
                        nome_plano AS NomePlano,
                        grupo_familiar AS GrupoFamiliar,
                        data_evento AS DataEvento,
                        codigoprocedimentofinal AS CodigoProcedimentoFinal,
                        descricaoprocedimentofinal AS DescricaoProcedimentoFinal,
                        codigo_servico AS CodigoServico,
                        descricao_servico AS DescricaoServico,
                        tipoeventocbhpm AS TipoEventoCBHPM,
                        tipoeventofinal AS TipoEventoFinal,
                        tipo_utilizacao AS TipoUtilizacao,
                        numero_subfatura AS NumeroSubFatura,
                        numero_contrato AS NumeroContrato,
                        codigo_prestador AS CodigoPrestador,
                        nome_prestador AS NomePrestador,
                        especialidade AS Especialidade,
                        sinistro AS Sinistro,
                        numero_evento AS NumeroEvento,
                        planta AS Planta
                    FROM
                        ps_amil
                    WHERE
                        id = @IdHealthInsurance
                    LIMIT 100;
                ", new { IdHealthInsurance = id });
            }
        }

        public async Task<IEnumerable<HealthInsuranceModel>> GetHealthInsurances()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<HealthInsuranceModel>(@"
                    SELECT
                        nome_cliente AS NomeCliente,
                        nome_banco AS NomeBanco,
                        nome_produto AS NomeProduto,
                        codigopessoa AS CodigoPessoa,
                        nome_paciente AS NomePaciente,
                        codigo_paciente AS CodigoPaciente,
                        matricula AS Matricula,
                        cpf AS Cpf,
                        data_nascimento AS DataNascimento,
                        sexo AS Sexo,
                        parentesco AS Parentesco,
                        codigo_plano AS CodigoPlano,
                        nome_plano AS NomePlano,
                        grupo_familiar AS GrupoFamiliar,
                        data_evento AS DataEvento,
                        codigoprocedimentofinal AS CodigoProcedimentoFinal,
                        descricaoprocedimentofinal AS DescricaoProcedimentoFinal,
                        codigo_servico AS CodigoServico,
                        descricao_servico AS DescricaoServico,
                        tipoeventocbhpm AS TipoEventoCBHPM,
                        tipoeventofinal AS TipoEventoFinal,
                        tipo_utilizacao AS TipoUtilizacao,
                        numero_subfatura AS NumeroSubFatura,
                        numero_contrato AS NumeroContrato,
                        codigo_prestador AS CodigoPrestador,
                        nome_prestador AS NomePrestador,
                        especialidade AS Especialidade,
                        sinistro AS Sinistro,
                        numero_evento AS NumeroEvento,
                        planta AS Planta
                    FROM
                        ps_amil
                    LIMIT 100;
                ");
            };
        }

        public async Task<IEnumerable<HealthInsuranceModel>> GetEventOccurrences()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<HealthInsuranceModel>(@"
                    SELECT DataEvento, COUNT(*) AS Ocorrencias
FROM (
    SELECT TO_DATE(data_evento, 'DD/MM/YYYY') AS DataEvento FROM ps_amil
    UNION ALL 
    SELECT TO_DATE(data_evento, 'DD/MM/YYYY') AS DataEvento FROM ps_unimed
    UNION ALL 
    SELECT TO_DATE(data_evento, 'DD/MM/YYYY') AS DataEvento FROM ps_midservice
) AS combined_tables
GROUP BY DataEvento
ORDER BY DataEvento;

                ");
            };
        }

        public async Task<IEnumerable<HealthInsuranceModel>> GetAppointmentsQuantity()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<HealthInsuranceModel>(@"
                    SELECT especialidade, Ano, Mes, COUNT(*) AS NumeroConsultas
                    FROM (
                        SELECT EXTRACT(YEAR FROM TO_DATE(data_evento, 'DD/MM/YYYY')) AS Ano, EXTRACT(MONTH FROM TO_DATE(data_evento, 'DD/MM/YYYY')) AS Mes, especialidade FROM ps_amil
                        UNION ALL
                        SELECT EXTRACT(YEAR FROM TO_DATE(data_evento, 'DD/MM/YYYY')), EXTRACT(MONTH FROM TO_DATE(data_evento, 'DD/MM/YYYY')), especialidade FROM ps_midservice
                        UNION ALL
                        SELECT EXTRACT(YEAR FROM TO_DATE(data_evento, 'DD/MM/YYYY')), EXTRACT(MONTH FROM TO_DATE(data_evento, 'DD/MM/YYYY')), especialidade FROM ps_unimed
                    ) AS subquery
                    GROUP BY Ano, Mes, especialidade
                    ORDER BY Ano, Mes, especialidade;
                ");
            };
        }


        public async Task<IEnumerable<HealthInsuranceModel>> GetDaysAppointment()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<HealthInsuranceModel>(@"
                    SELECT
                        EXTRACT(YEAR FROM TO_DATE(data_evento, 'DD/MM/YYYY')) AS Ano,
                        TRIM(TO_CHAR(TO_DATE(data_evento, 'DD/MM/YYYY'), 'TMDay')) AS DiaSemana,
                        COUNT(*) AS NumeroConsultas
                    FROM
                        (SELECT data_evento FROM ps_amil
                         UNION ALL
                         SELECT data_evento FROM ps_unimed
                         UNION ALL
                         SELECT data_evento FROM ps_midservice) AS sub
                    WHERE
                        EXTRACT(YEAR FROM TO_DATE(data_evento, 'DD/MM/YYYY')) IN (2022, 2023)
                    GROUP BY
                        Ano, DiaSemana
                ");
            };
        }

        public async Task<IEnumerable<HealthInsuranceModel>> GetAppointmentSpeciality()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<HealthInsuranceModel>(@"
                   SELECT
                        TO_CHAR(TO_DATE(data_evento, 'DD/MM/YYYY'), 'Month') AS Mes,
                        LOWER(especialidade) AS Especialidade,
                        COUNT(*) AS NumeroConsultas
                    FROM
                        (SELECT data_evento, especialidade FROM ps_amil
                         UNION ALL
                         SELECT data_evento, especialidade FROM ps_unimed
                         UNION ALL
                         SELECT data_evento, especialidade FROM ps_midservice) AS sub
                    WHERE
                        LOWER(especialidade) IN ('psiquiatria', 'psicologia')
                    GROUP BY
                        Mes, Especialidade
                    ORDER BY
                        Mes, Especialidade;
                ");
            };
        }


        public Task<string> GetPlanByCodigoPaciente(int CodigoPaciente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HealthInsuranceModel>> GetProcedures()
        {
            throw new NotImplementedException();
        }
    }
}