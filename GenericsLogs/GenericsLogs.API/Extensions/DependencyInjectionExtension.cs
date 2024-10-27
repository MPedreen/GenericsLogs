using GenericsLogs.Domain.Interfaces.Persistences;
using GenericsLogs.Domain.Interfaces.Services;
using GenericsLogs.Infra.Data.Context.Mongo;
using GenericsLogs.Infra.Data.Context.Mongo.Persistences;
using GenericsLogs.Service;

namespace GenericsLogs.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IActionLogPersistence, ActionLogPersistence>();
            services.AddTransient<IErroLogPersistence, ErroLogPersistence>();
            services.AddTransient<IActionLogService, ActionLogService>();
            services.AddTransient<IErroLogService, ErroLogService>();

            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
            services.AddTransient<MongoDbContext>();

            return services;
        }
    }
}
