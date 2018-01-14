using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RESTFulExample.DAL.Entities;
namespace RESTFulExample.DAL.Mongo
{
    public class LogContext
    {
        private readonly IMongoDatabase _database = null;

        public LogContext(IOptions<LogSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public LogContext(LogSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Database);
        }

        public IMongoCollection<Log> Logs
        {
            get
            {
                return _database.GetCollection<Log>("Log");
            }
        }
    }
}
