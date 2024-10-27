using GenericsLogs.Domain.DTOs;
using GenericsLogs.Domain.Models;

namespace GenericsLogs.Domain.Interfaces.Persistences
{
    public interface IActionLogPersistence
    {
        Task AddAsync(Log model);
    }
}
