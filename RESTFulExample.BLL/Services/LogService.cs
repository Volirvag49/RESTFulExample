using System.Collections.Generic;
using System.Threading.Tasks;
using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Interfaces;
using RESTFulExample.DAL.Interfaces;
using RESTFulExample.DAL.Entities;
using AutoMapper;
using RESTFulExample.BLL.Infrastructure;

namespace RESTFulExample.BLL.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<IEnumerable<LogDTO>> GetAllLogsAsync()
        {
            var logs = await Mapper.Map<Task<IEnumerable<Log>>, Task<IEnumerable<LogDTO>>>(_logRepository.GetAllLogsAsync());
            return logs;
        }
    

        public async Task AddLog(LogDTO logDTO)
        {
            if (logDTO == null)
            {
                throw new BusinessLogicException("Требуется лог", "");
            }

            Log log = new Log()
            {
                Event_date = logDTO.Event_date,
                Exception = logDTO.Exception,
                Method_name = logDTO.Method_name

            };
            await _logRepository.AddLog(log);
        }     

        public async Task RemoveAllLogs()
        {
            await _logRepository.RemoveAllLogs();
        }

    }
}
