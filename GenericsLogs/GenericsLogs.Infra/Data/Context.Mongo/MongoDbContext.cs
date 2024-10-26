namespace GenericsLogs.Infra.Data.Context.Mongo
{
    public class MongoDbContext
    {
        private readonly MongoDbSettings? _mongoDbSettings;
        private IMongoDatabase? _mongoDatabase;

        public MongoDbContext(IOptions<MongoDbSettings>? mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings.Value;

            #region Conexão com o banco de dados
            var client = MongoClientSettings.FromUrl(new MongoUrl(_mongoDbSettings.Host));

            if (_mongoDbSettings.IsSSL)
                client.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security
                    .Authentication.SslProtocols.None
                };

            _mongoDatabase = new MongoClient(client)
                .GetDatabase(_mongoDbSettings.Name);
            #endregion
        }

        public IMongoCollection<Log> GetCollection(string collectionName) =>
            _mongoDatabase.GetCollection<Log>(collectionName);
    }
}
