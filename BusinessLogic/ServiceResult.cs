namespace BusinessLogic
{
    public class ServiceResult<T>
    {
        public ServiceResult(StatusCode status)
        {
            Status = status;
        }

        public ServiceResult(StatusCode status, string message) : this(status)
        {
            Message = message;
        }

        public ServiceResult(StatusCode status, T item) : this(status)
        {
            Item = item;
        }

        public ServiceResult(StatusCode status, string message, T item) : this(status, message)
        {
            Item = item;
        }

        public StatusCode Status { get; }
        public string Message { get; }
        public T Item { get; }
    }
}
