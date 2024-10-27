namespace GenericsLogs.API.Exceptions
{
    public class ForbiddenException : Exception
    {
        public int StatusCode { get; }
        public object Value { get; }
        public ForbiddenException() : base() { }
    }
}
