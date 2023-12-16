namespace DotNetRPG.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; } = true;

        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;

        public string Message { get; set; } = string.Empty;

    }
}