using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiValidation.Models;

namespace SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiValidation;

public class ApiValidationException : Exception
{
    public ErrorDetails ErrorDetails { get; }

    public ApiValidationException(ErrorDetails errorDetails) : base(errorDetails.Message)
    {
        ErrorDetails = errorDetails;
    }

    public ApiValidationException(ErrorDetails errorDetails, Exception innerException) : base(errorDetails.Message, innerException)
    {
        ErrorDetails = errorDetails;
    }
}