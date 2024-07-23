using Dapper;
using Npgsql;

namespace GTI.Dashboard.Repository
{
    public class ZenklubRepository : IZenklubRepository
    {
        private readonly string _dbConfig;

        public ZenklubRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<IEnumerable<ZenklubModel>> GetDepartment()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<ZenklubModel>(@"
                    SELECT
                        periodo AS Periodo,
                        mes AS Mes,
                        nome AS Nome,
                        n_pessoal AS NPessoal,
                        codigo_validacao AS CodigoValidacao,
                        departamento AS Departamento,
                        total_sessoes AS TotalSessoes
                    FROM
                        zenklub

                    LIMIT 100;
                ");
            };
        }

        public async Task<IEnumerable<ZenklubModel>> GetTotalSessionsByDepartment()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<ZenklubModel>(@"
                    SELECT
                        mes AS Mes,
                        departamento AS Departamento,
                        SUM(total_sessoes) AS TotalSessoes
                    FROM
                        zenklub
                    GROUP BY
                        Mes, Departamento
                    LIMIT 100;
                ");
            };
        }
    }
}
