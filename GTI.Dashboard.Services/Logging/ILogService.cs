using GTI.Dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Services.Logging
{
    public interface ILogService
    {
        Task LogEntry(LogModel logModel);
        IEnumerable<LogModel> GetHardcodedLogEntries();
       // Task<IEnumerable<string>> GetLogColumnValues(LogModel logModel);
    }
}
