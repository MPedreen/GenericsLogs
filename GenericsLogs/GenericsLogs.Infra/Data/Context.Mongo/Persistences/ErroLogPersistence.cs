using GenericsLogs.Domain.Interfaces.Persistences;
using GenericsLogs.Domain.Models;
using MongoDB.Driver;

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

        public void Delete(Log model)
        {
            var filter = Builders<Log>.Filter.Eq(c => c.Id, model.Id);
            _mongoDbContext.GetCollection("LogsErros").DeleteOne(filter);
        }

        public List<Log> GetAll()
        {
            var filter = Builders<Log>.Filter.Where(c => true);
            return _mongoDbContext.GetCollection("LogsErros").Find(filter).ToList();
        }

        public Log GetbyId(Guid id)
        {
            var filter = Builders<Log>.Filter.Eq(c => c.Id, id);
            return _mongoDbContext.GetCollection("LogsErros").Find(filter).FirstOrDefault();
        }

        public void Update(Log model)
        {
            var filter = Builders<Log>.Filter.Eq(c => c.Id, model.Id);
            _mongoDbContext.GetCollection("LogsErros").ReplaceOne(filter, model);
        }
    }
}
