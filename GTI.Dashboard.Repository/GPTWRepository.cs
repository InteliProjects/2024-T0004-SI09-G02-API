using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public class GPTWRepository : IGPTWRepository
    {
        private readonly string _dbConfig;

        public GPTWRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }
        public async Task<IEnumerable<GPTWModel>> GetGPTWs()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<GPTWModel>(@"
                SELECT
                    nniveis AS Nniveis,
                    uo_abrev AS UoAbrev,
                    ""1nvel"" AS Umnvel,
                    ""2nvel"" AS Doisnvel,
                    ""3nvel"" AS Tresnvel,
                    ""4nvel"" AS Quartanvel,
                    ""5nvel"" AS Quintanvel,
                    ""6nvel"" AS Sextanvel,
                    ""7nvel"" AS Setenvel,
                    ""8nvel"" AS Oitonvel,
                    npess AS Npess,
                    rrh AS Rrh,
                    local AS Local,
                    empr AS Empr,
                    gremp AS Gremp,
                    grpempregados AS Grpempregados,
                    sgemp AS Sgemp,
                    centrocst AS Centrocst,
                    unidorg AS Unidorg,
                    descr_uo AS DescrUo,
                    ""uo_abrev.1"" AS UoAbrevUm,
                    idadedoempregado AS Idadedoempregado,
                    gn AS Gn,
                    tpausp AS Tpausp,
                    txttipopresenaausn AS Txttipopresenaausn,
                    incio AS Incio,
                    fim AS Fim,
                    cargo AS Cargo,
                    ""cargo.1"" AS CargoUM,
                    data_adm AS DataAdm
                FROM
                    gptw
                LIMIT 100;"
                );
            };
        }
        public async Task<IEnumerable<GPTWModel>> GetEngagement()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<GPTWModel>(@"
                SELECT
                    year AS Ano,
                    engagement_percent AS EngajamentoPorcentagem,
                    trust_index AS IndexVerdade,
                    culture_audit AS AuditCultura
                FROM
                    gptw_engage
                LIMIT 100;"
                );
            };
        }
        public async Task<IEnumerable<GPTWModel>> GetQuestions()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<GPTWModel>(@"
                SELECT
                  q.escala AS Escala,
                  q.pergunta AS Pergunta,
                  (
                    COALESCE(CAST(ct.""1"" AS double precision), 0) +
                    COALESCE(CAST(ct.""2"" AS double precision), 0) +
                    COALESCE(CAST(ct.""3"" AS double precision), 0) +
                    COALESCE(CAST(ct.""4"" AS double precision), 0) +
                    COALESCE(CAST(ct.""5"" AS double precision), 0) +
                    COALESCE(CAST(ct.""6"" AS double precision), 0) +
                    COALESCE(CAST(ct.""7"" AS double precision), 0) +
                    COALESCE(CAST(ct.""8"" AS double precision), 0) +
                    COALESCE(CAST(ct.""9"" AS double precision), 0) +
                    COALESCE(CAST(ct.""10"" AS double precision), 0) +
                    COALESCE(CAST(ct.""11"" AS double precision), 0) +
                    COALESCE(CAST(ct.""12"" AS double precision), 0) +
                    COALESCE(CAST(ct.""13"" AS double precision), 0) +
                    COALESCE(CAST(ct.""14"" AS double precision), 0) +
                    COALESCE(CAST(ct.""15"" AS double precision), 0) +
                    COALESCE(CAST(ct.""16"" AS double precision), 0) +
                    COALESCE(CAST(ct.""17"" AS double precision), 0) +
                    COALESCE(CAST(ct.""18"" AS double precision), 0) +
                    COALESCE(CAST(ct.""19"" AS double precision), 0) +
                    COALESCE(CAST(ct.""20"" AS double precision), 0) +
                    COALESCE(CAST(ct.""21"" AS double precision), 0) +
                    COALESCE(CAST(ct.""22"" AS double precision), 0) +
                    COALESCE(CAST(ct.""23"" AS double precision), 0) +
                    COALESCE(CAST(ct.""24"" AS double precision), 0) +
                    COALESCE(CAST(ct.""25"" AS double precision), 0) +
                    COALESCE(CAST(ct.""26"" AS double precision), 0) +
                    COALESCE(CAST(ct.""27"" AS double precision), 0) +
                    COALESCE(CAST(ct.""28"" AS double precision), 0) +
                    COALESCE(CAST(ct.""29"" AS double precision), 0) +
                    COALESCE(CAST(ct.""30"" AS double precision), 0) +
                    COALESCE(CAST(ct.""31"" AS double precision), 0) +
                    COALESCE(CAST(ct.""32"" AS double precision), 0) +
                    COALESCE(CAST(ct.""33"" AS double precision), 0) +
                    COALESCE(CAST(ct.""34"" AS double precision), 0) +
                    COALESCE(CAST(ct.""35"" AS double precision), 0) +
                    COALESCE(CAST(ct.""36"" AS double precision), 0) +
                    COALESCE(CAST(ct.""37"" AS double precision), 0) +
                    COALESCE(CAST(ct.""38"" AS double precision), 0) +
                    COALESCE(CAST(ct.""39"" AS double precision), 0) +
                    COALESCE(CAST(ct.""40"" AS double precision), 0) +
                    COALESCE(CAST(ct.""41"" AS double precision), 0) +
                    COALESCE(CAST(ct.""42"" AS double precision), 0) +
                    COALESCE(CAST(ct.""43"" AS double precision), 0) +
                    COALESCE(CAST(ct.""44"" AS double precision), 0) +
                    COALESCE(CAST(ct.""45"" AS double precision), 0) +
                    COALESCE(CAST(ct.""46"" AS double precision), 0) +
                    COALESCE(CAST(ct.""47"" AS double precision), 0) +
                    COALESCE(CAST(ct.""48"" AS double precision), 0) +
                    COALESCE(CAST(ct.""49"" AS double precision), 0) +
                    COALESCE(CAST(ct.""50"" AS double precision), 0) +
                    COALESCE(CAST(ct.""51"" AS double precision), 0) +
                    COALESCE(CAST(ct.""52"" AS double precision), 0) +
                    COALESCE(CAST(ct.""53"" AS double precision), 0) +
                    COALESCE(CAST(ct.""54"" AS double precision), 0) +
                    COALESCE(CAST(ct.""55"" AS double precision), 0) +
                    COALESCE(CAST(ct.""56"" AS double precision), 0) +
                    COALESCE(CAST(ct.""57"" AS double precision), 0) +
                    COALESCE(CAST(ct.""58"" AS double precision), 0) +
                    COALESCE(CAST(ct.""59"" AS double precision), 0) +
                    COALESCE(CAST(ct.""60"" AS double precision), 0)
                  ) / 60 AS AverageScore
                FROM
                  gptw_company_t ct
                JOIN
                  gptw_questions q ON CAST(q.""N"" AS text) = ct.""Q""
                ORDER BY
                  q.pergunta, q.escala DESC
                LIMIT 5;"
                );
            };
        }
    }
}
