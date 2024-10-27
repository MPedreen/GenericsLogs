using GenericsLogs.Domain.DTOs;
using GenericsLogs.Domain.Models;

namespace GenericsLogs.Domain.Interfaces.Services
{
    public interface IActionLogService
    {
        Task<Log> AddAsync(LogDTO logDTO);
    }
}
