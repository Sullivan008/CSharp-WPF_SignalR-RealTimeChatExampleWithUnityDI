namespace Application.Client.Infrastructure.ErrorHandling.Models
{
    public class ErrorModel
    {
        public string Message { get; init; } = string.Empty;

        public string Exception { get; init; } = string.Empty;
    }
}