using GenericsLogs.API.Exceptions;
using GenericsLogs.Domain.DTOs;
using GenericsLogs.Domain.Interfaces.Services;
using GenericsLogs.Domain.Models;
using System.Net;

namespace GenericsLogs.API.Middlewares
{
    public class LogsHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IErroLogService _erroLogService;
        private readonly IActionLogService _actionLogService;
        private readonly IWebHostEnvironment _environment;

        public LogsHandlerMiddleware(
            RequestDelegate next,
            ILogger<LogsHandlerMiddleware> logger,
            IErroLogService erroLogService,
            IActionLogService actionLogService,
            IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _erroLogService = erroLogService;
            _actionLogService = actionLogService;
            _environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await HandleActionAsync(context);

                await _next(context);
            }
            catch (Exception error)
            {
                await HandleErrorAsync(context, error);
            }
        }

        private async Task HandleErrorAsync(HttpContext context, Exception error)
        {
            var response = context.Response;
            User userHttpContext = (User)context.Items["User"];
            response.StatusCode = ReturnStatusCodeError(error);

            LogDTO logDTO = new();
            logDTO.Id = Guid.NewGuid();
            logDTO.Date = DateTime.Now;
            logDTO.UserEmail = userHttpContext?.Email;
            logDTO.App = "GenericsLogs";
            logDTO.Controller = context.Request.Path;
            logDTO.Action = context.Request.Method;
            logDTO.StatusCode = response.StatusCode.ToString();
            logDTO.StackTrace = error?.StackTrace;
            logDTO.Message = error?.Message;
            logDTO.Environment = _environment.EnvironmentName;

            _erroLogService.Add(logDTO);
        }

        private int ReturnStatusCodeError(Exception error)
        {
            return error switch
            {
                AppException => (int)HttpStatusCode.BadRequest,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                ForbiddenException => (int)HttpStatusCode.Forbidden,
                _ => LogAndReturnInternalServerError(error)
            };
        }

        private int LogAndReturnInternalServerError(Exception error)
        {
            _logger.LogError(error, error.Message);
            return (int)HttpStatusCode.InternalServerError;
        }

        private async Task HandleActionAsync(HttpContext context)
        {
            var response = context.Response;

            if (response.StatusCode is not 404)
            {
                User userHttpContext = (User)context.Items["User"];

                LogDTO logDTO = new();
                logDTO.Id = Guid.NewGuid();
                logDTO.Date = DateTime.Now;
                logDTO.UserEmail = userHttpContext?.Email;
                logDTO.App = "GenericsLogs";
                logDTO.Controller = context.Request.Path;
                logDTO.Action = context.Request.Method;
                logDTO.StatusCode = response.StatusCode.ToString();
                logDTO.Environment = _environment.EnvironmentName;

                await _actionLogService.AddAsync(logDTO);
            }
        }
    }
}
