using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiRequestModelValidation.Models;

namespace SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiRequestModelValidation;

public class ApiRequestModelValidationException : Exception
{
    public ErrorDetails ErrorDetails { get; }

    public ApiRequestModelValidationException(ErrorDetails errorDetails) : base(errorDetails.Message)
    {
        ErrorDetails = errorDetails;
    }

    public ApiRequestModelValidationException(ErrorDetails errorDetails, Exception innerException) : base(errorDetails.Message, innerException)
    {
        ErrorDetails = errorDetails;
    }
}