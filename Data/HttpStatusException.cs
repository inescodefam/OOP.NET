
namespace DataHandler
{
    [Serializable]
    internal class HttpStatusException : Exception
    {
        public HttpStatusException()
        {
        }

        public HttpStatusException(string? message) : base(message)
        {
        }

        public HttpStatusException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}