using GenericsLogs.Domain.DTOs;
using GenericsLogs.Domain.Interfaces.Persistences;
using GenericsLogs.Domain.Interfaces.Services;
using GenericsLogs.Domain.Models;

namespace GenericsLogs.Service
{
    public class ActionLogService : IActionLogService
    {
        private readonly IActionLogPersistence _actionLogPersistence;

        public ActionLogService(IActionLogPersistence actionLogPersistence)
        {
            _actionLogPersistence = actionLogPersistence;
        }

        public async Task<Log> AddAsync(LogDTO logDTO)
        {
            Log log = new Log();
            log.Date = logDTO.Date;
            log.UserEmail = logDTO.UserEmail;
            log.Controller = logDTO.Controller;
            log.Action = logDTO.Action;
            log.StatusCode = logDTO.StatusCode;
            log.StackTrace = logDTO.StackTrace;
            log.Message = logDTO.Message;
            log.App = logDTO.App;
            log.Environment = logDTO.Environment;

            await _actionLogPersistence.AddAsync(log);
            return log;
        }
    }
}
