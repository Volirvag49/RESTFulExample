using RESTFulExample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RESTFulExample.DAL.Interfaces
{
    public interface ILogRepository
    {
        Task<IEnumerable<Log>> GetAllLogsAsync();
        Task AddLog(Log log);
        Task<bool> RemoveAllLogs();
    }
}
