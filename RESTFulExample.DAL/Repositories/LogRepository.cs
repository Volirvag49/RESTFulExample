using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Interfaces;
using RESTFulExample.DAL.Mongo;
using System;
using MongoDB.Bson;

namespace RESTFulExample.DAL.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly LogContext _context = null;

        public LogRepository(IOptions<LogSettings> settings)
        {
            _context = new LogContext(settings);
        }

        public LogRepository(LogSettings settings)
        {
            _context = new LogContext(settings);
        }

        public async Task<IEnumerable<Log>> GetAllLogsAsync()
        {
            try
            {
                return await _context.Logs
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     

        public async Task AddLog(Log log)
        {
            try
            {
                await _context.Logs.InsertOneAsync(log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public async Task<bool> RemoveAllLogs()
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Logs.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
