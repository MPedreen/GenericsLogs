using GenericsLogs.Domain.Interfaces.Persistences;
using GenericsLogs.Domain.Models;

namespace GenericsLogs.Infra.Data.Context.Mongo.Persistences
{
    public class ActionLogPersistence : IActionLogPersistence
    {
        private readonly MongoDbContext? _mongoDbContext;

        public ActionLogPersistence(MongoDbContext? mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task AddAsync(Log model)
            => await _mongoDbContext.GetCollection("LogsActions").InsertOneAsync(model);
    }
}
