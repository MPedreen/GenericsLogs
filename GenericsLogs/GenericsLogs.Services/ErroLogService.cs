using GenericsLogs.Domain.DTOs;
using GenericsLogs.Domain.Interfaces.Persistences;
using GenericsLogs.Domain.Interfaces.Services;
using GenericsLogs.Domain.Models;

namespace GenericsLogs.Service
{
    public class ErroLogService : IErroLogService
    {
        private readonly IErroLogPersistence _erroLogPersistence;

        public ErroLogService(IErroLogPersistence erroLogPersistence)
        {
            _erroLogPersistence = erroLogPersistence;
        }

        public Log Add(LogDTO logDTO)
        {
            Log log = new Log();
            log.Id = logDTO.Id;
            log.Date = logDTO.Date;
            log.UserEmail = logDTO.UserEmail;
            log.Controller = logDTO.Controller;
            log.Action = logDTO.Action;
            log.StatusCode = logDTO.StatusCode;
            log.StackTrace = logDTO.StackTrace;
            log.Message = logDTO.Message;
            log.App = logDTO.App;
            log.Environment = logDTO.Environment;

            _erroLogPersistence.Add(log);
            return log;
        }
    }
}