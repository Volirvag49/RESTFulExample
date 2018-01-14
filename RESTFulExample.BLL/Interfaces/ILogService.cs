using RESTFulExample.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Interfaces
{
    public interface ILogService
    {
        Task<IEnumerable<LogDTO>> GetAllLogsAsync();
        Task AddLog(LogDTO log);
        Task RemoveAllLogs();
    }
}
