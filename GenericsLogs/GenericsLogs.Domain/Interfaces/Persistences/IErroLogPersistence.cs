using GenericsLogs.Domain.Models;

namespace GenericsLogs.Domain.Interfaces.Persistences
{
    public interface IErroLogPersistence
    {
        void Add(Log model);
    }
}
