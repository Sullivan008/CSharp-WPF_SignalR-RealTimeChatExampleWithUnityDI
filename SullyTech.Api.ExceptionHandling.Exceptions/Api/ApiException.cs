using SullyTech.Api.ExceptionHandling.Exceptions.Api.Models;

namespace SullyTech.Api.ExceptionHandling.Exceptions.Api;

public class ApiException : Exception
{
    public ErrorDetails ErrorDetails { get; }

    public ApiException(ErrorDetails errorDetails) : base(errorDetails.Message)
    {
        ErrorDetails = errorDetails;
    }

    public ApiException(ErrorDetails errorDetails, Exception innerException) : base(errorDetails.Message, innerException)
    {
        ErrorDetails = errorDetails;
    }
}