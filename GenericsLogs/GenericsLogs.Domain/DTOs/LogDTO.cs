namespace GenericsLogs.Domain.DTOs
{
    public class LogDTO
    {
        public DateTime Date { get; set; }
        public string UserEmail { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public string App { get; set; }
        public string Environment { get; set; }
    }
}
