namespace GenericsLogs.API.Exceptions
{
    public class AppException : Exception
    {
        public int StatusCode { get; }
        public object Value { get; }
        public AppException() : base() { }
    }
}
