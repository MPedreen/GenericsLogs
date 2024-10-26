namespace GenericsLogs.Domain.Interfaces.Persistences
{
    public interface IActionLogPersistence : IBasePersistence<Log, Guid>
    {
        Task AddAsync(Log model);
    }
}
