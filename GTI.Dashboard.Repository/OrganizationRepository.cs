using Npgsql;
using Dapper;

namespace GTI.Dashboard.Repository
{
    public class OrganizationRepository : IOrganizationRepository

    {
        private readonly string _dbConfig;

        public OrganizationRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<IEnumerable<OrganizationModel>> GetOrganizations()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<OrganizationModel>(@"
                    SELECT
                        area_diretoria AS AreaDiretoria,
                        nome_vp AS NomeVps,
                        nota_stiba_2022 AS NotaStiba2022,
                        nota_stiba_2023 AS NotaStiba2023,
                        nota_empresa_2022 AS NotaEmpresa2022,
                        nota_empresa_2023 AS NotaEmpresa2023,
                        nota_gptw_2022 AS NotaGPTW2022,
                        nota_gptw_2023 AS NotaGPTW2023
                    FROM
                        notas_diretorias
                    WHERE
                        area_diretoria NOT IN ('B-OA Unidade Anchieta', 'B-OC Unidade Curitiba', 'B-OP Unidade Sao Carlos', 'B-OT Unidade Taubate')
                    LIMIT 100;"
                );
            }
        }

        public async Task<IEnumerable<OrganizationModel>> GetOrganizationsUnits()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<OrganizationModel>(@"
                    SELECT
                        area_diretoria AS UnidadeUO,
                        nome_vp AS NomeUnidade,
                        nota_stiba_2022 AS NotaStiba2022,
                        nota_stiba_2023 AS NotaStiba2023,
                        nota_empresa_2022 AS NotaEmpresa2022,
                        nota_empresa_2023 AS NotaEmpresa2023,
                        nota_gptw_2022 AS NotaGPTW2022,
                        nota_gptw_2023 AS NotaGPTW2023
                    FROM
                        notas_diretorias
                    WHERE
                        area_diretoria IN ('B-OA Unidade Anchieta', 'B-OC Unidade Curitiba', 'B-OP Unidade Sao Carlos', 'B-OT Unidade Taubate')
                    LIMIT 100;"
                );
            }
        }
    }
}