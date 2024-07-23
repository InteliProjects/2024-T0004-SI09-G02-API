using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GTI.Dashboard.Repository;
using GTI.Dashboard.Services.Logging;
using Serilog;

namespace GTI.Dashboard.Services.Logs
{
    public class LogsService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogsService(ILogRepository logRepository)
        {
            _logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
        }

        public async Task LogEntry(LogModel logModel)
        {
            try
            {
                await _logRepository.DbLogging(logModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging data: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<LogModel> GetHardcodedLogEntries()
        {
            var logEntries = new List<LogModel>
            {
                new LogModel
                {
                    Id_usuario = 1,
                    Status_Code = 200,
                    Classe = "ClasseTeste",
                    Message = "Recebido com sucesso",
                    Exception = "",
                    Data_Hora = DateTime.Now
                },
                new LogModel
                {
                    Id_usuario = 2,
                    Status_Code = 404,
                    Classe = "ClasseTesteErrado",
                    Message = "Error message",
                    Exception = "Exception: Error while processing data; Generic error",
                    Data_Hora = DateTime.Now
                }
            };

            return logEntries;
        }

        public async Task<IEnumerable<string>> GetLogColumnValues(LogModel logModel)
        {
            List<string> columnValues = new List<string>();

            var logEntries = await _logRepository.DbLogging(logModel);

            foreach (var entry in logEntries)
            {
                columnValues.Add(entry.Id_usuario.ToString());
                columnValues.Add(entry.Status_Code.ToString());
                columnValues.Add(entry.Classe);
                columnValues.Add(entry.Message);
                columnValues.Add(entry.Exception);
                columnValues.Add(entry.Data_Hora.ToString());
            }

            return columnValues;
        }

        public Task Logging_Business(LogModel logModel)
        {
            throw new NotImplementedException();
        }
    }
}
