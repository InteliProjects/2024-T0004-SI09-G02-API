using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GTI.Dashboard.Repository;

namespace GTI.Dashboard.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly string _dbConfig;

        public LogRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<IEnumerable<LogModel>> DbLogging(LogModel logModel)
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<LogModel>(@"
                 INSERT INTO logs_security (id_usuario, status_code, classe, message, exception, data_hora)" +
                           "VALUES (@Id_usuario, @Status_Code, @Classe, @Message, @Exception, @Data_Hora)",
                new { Id_usuario = logModel.Id_usuario, logModel.Status_Code, logModel.Classe, logModel.Message, logModel.Exception, logModel.Data_Hora });
            }; 
        }

    }

}
