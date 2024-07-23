using Dapper;
using Npgsql;

namespace GTI.Dashboard.Repository
{
    public class CIDRepository : ICIDRepository

    {
       private readonly string _dbConfig;

        public CIDRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }


        public async Task<IEnumerable<CIDModel>> GetCauseByHealthUnit(string unidade)
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<CIDModel>(@"
                    SELECT
                        unidade AS Unidade,
                        causa_raiz AS CausaRaiz,
                        COUNT(*) AS Quantidade
                    FROM
                        cid_f_2023_geral
                    WHERE
                        unidade = @Unidade  -- Filtrando os resultados pela unidade específica
                    GROUP BY
                        unidade, causa_raiz
                    ORDER BY
                        quantidade DESC
                    LIMIT 100;",
                    new { Unidade = unidade }
                );
            };
        }

        public async Task<IEnumerable<CIDModel>> GetCID()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<CIDModel>(@"
                    SELECT
                        mes AS Mes,
                        n_pessoal AS N_pessoal,
                        atestados AS Atestados,
                        dias AS Dias,
                        diretoria AS Diretoria,
                        unidade AS Unidade,
                        genero AS Genero,
                        categoria AS Categoria,
                        cid AS Cid,
                        descricao_detalhada AS DescricaoDetalhada,
                        descricao_resumida AS DescricaoResumida,
                        diagnostico_atestado_inicial AS DiagnosticoAtestadoInicial,
                        causa_raiz AS CausaRaiz,
                        outros AS Outros,
                        jornada AS Jornada
                    FROM
                        cid_f_2023_geral
                    LIMIT 100;"
                );
            };
        }

        public async Task<IEnumerable<CIDModel>> GetDoctorCertificateQuantity()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<CIDModel>(@"
                  SELECT 
                    diretoria, 
                    COUNT(atestados) AS QuantidadeAtestados, 
                    SUM(REPLACE(dias, ',', '.')::float) AS QuantidadeAfastamentos
                FROM cid_f_2023
                GROUP BY diretoria;"
                );
            };
        }


        public Task<int> InsertEmployee(CIDModel cidModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateEmployee(CIDModel cidModel)
        {
            throw new NotImplementedException();
        }
    }
}
