using GenericsLogs.Domain.DTOs;
using GenericsLogs.Domain.Models;

namespace GenericsLogs.Domain.Interfaces.Services
{
    public interface IErroLogService
    {
        Log Add(LogDTO log);
    }
}
