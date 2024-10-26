namespace GenericsLogs.Infra.Data.Context.Mongo.Persistences
{
    public class ActionLogPersistence : IActionLogPersistence
    {
        private readonly MongoDbContext? _mongoDbContext;

        public ActionLogPersistence(MongoDbContext? mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public void Add(Log model)
            => _mongoDbContext.GetCollection("LogsActions").InsertOne(model);

        public async Task AddAsync(Log model)
            => await _mongoDbContext.GetCollection("LogsActions").InsertOneAsync(model);

        public void Delete(Log model)
        {
            var filter = Builders<Log>.Filter.Eq(c => c.Id, model.Id);
            _mongoDbContext.GetCollection("LogsActions").DeleteOne(filter);
        }

        public List<Log> GetAll()
        {
            var filter = Builders<Log>.Filter.Where(c => true);
            return _mongoDbContext.GetCollection("LogsActions").Find(filter).ToList();
        }

        public Log GetbyId(Guid id)
        {
            var filter = Builders<Log>.Filter.Eq(c => c.Id, id);
            return _mongoDbContext.GetCollection("LogsActions").Find(filter).FirstOrDefault();
        }

        public void Update(Log model)
        {
            var filter = Builders<Log>.Filter.Eq(c => c.Id, model.Id);
            _mongoDbContext.GetCollection("LogsActions").ReplaceOne(filter, model);
        }
    }
}
