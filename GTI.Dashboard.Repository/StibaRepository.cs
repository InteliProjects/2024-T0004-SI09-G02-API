using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public class StibaRepository : IStibaRepository
    {
        private readonly string _dbConfig;

        public StibaRepository(string dbConfig)
        {  
            _dbConfig = dbConfig; 
        }
        public async Task<IEnumerable<StibaModel>> GetStibas()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<StibaModel>(@"
                    (SELECT
                        '2022' AS Ano,
                        ""Descrição UO"" AS DescricaoUO,
                        ""Elegíveis"" AS Elegiveis,
                        ""Respondentes"" AS Respondentes,
                        CAST(""% particip"" AS float) AS Participante,
                        CAST(REPLACE(""Nota Stiba"", ',', '.') AS float) AS NotaStiba,
                        ""Q01"" AS QUm,
                        ""Q02"" AS QDois,
                        ""Q03"" AS QTres,
                        ""Q04"" AS QQuatro,
                        ""Q05"" AS QCinco,
                        ""Q06"" AS QSeis,
                        ""Q07"" AS QSete,
                        ""Q08"" AS QOito,
                        ""Q09"" AS QNove,
                        ""Q10"" AS QDez,
                        ""Q11"" AS QOnze,
                        ""Q12"" AS QDoze,
                        ""Q13"" AS QTreze,
                        ""Q14"" AS QCatorze,
                        ""Q15"" AS QQuinze,
                        ""Q16"" AS QDezesseis,
                        ""Q17"" AS QDezessete,
                        ""Q18"" AS QDezoito,
                        ""Q19"" AS QDezenove,
                        ""Q20"" AS QVinte,
                        ""Q21"" AS QVinteUm,
                        ""Q22"" AS QVinteDois,
                        ""Q23"" AS QVinteTres,
                        ""Q24"" AS QVinteQuatro
                    FROM 
                        stiba_2022
                    LIMIT 100)
                    UNION ALL
                    (SELECT
                        '2023' AS Ano,
                        ""Descrição UO"" AS DescricaoUO,
                        ""Elegíveis"" AS Elegiveis,
                        ""Respondentes"" AS Respondentes,
                        CAST(""% particip"" AS float) AS Participante,
                        CAST(REPLACE(""Nota Stiba"", ',', '.') AS float) AS NotaStiba,
                        ""Q1"" AS QUm,
                        ""Q2"" AS QDois,
                        ""Q3"" AS QTres,
                        ""Q4"" AS QQuatro,
                        ""Q5"" AS QCinco,
                        ""Q6"" AS QSeis,
                        ""Q7"" AS QSete,
                        ""Q8"" AS QOito,
                        ""Q9"" AS QNove,
                        ""Q10"" AS QDez,
                        ""Q11"" AS QOnze,
                        ""Q12"" AS QDoze,
                        ""Q13"" AS QTreze,
                        ""Q14"" AS QCatorze,
                        ""Q15"" AS QQuinze,
                        ""Q16"" AS QDezesseis,
                        ""Q17"" AS QDezessete,
                        ""Q18"" AS QDezoito,
                        ""Q19"" AS QDezenove,
                        ""Q20"" AS QVinte,
                        ""Q21"" AS QVinteUm,
                        ""Q22"" AS QVinteDois,
                        ""Q23"" AS QVinteTres,
                        ""Q24"" AS QVinteQuatro
                    FROM 
                        stiba_2023
                    LIMIT 100);
                ");
            };
        }
    }
}