using GenericsLogs.Domain.Interfaces.Persistences;
using GenericsLogs.Domain.Models;

namespace GenericsLogs.Infra.Data.Context.Mongo.Persistences
{
    public class ErroLogPersistence : IErroLogPersistence
    {
        private readonly MongoDbContext? _mongoDbContext;

        public ErroLogPersistence(MongoDbContext? mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public void Add(Log model)
            => _mongoDbContext.GetCollection("LogsErros").InsertOne(model);
    }
}
