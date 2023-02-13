using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiFluentModelStateValidation.Models;

namespace SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiFluentModelStateValidation;

public class ApiFluentModelStateValidationException : Exception
{
    public ErrorDetails ErrorDetails { get; }

    public ApiFluentModelStateValidationException(ErrorDetails errorDetails) : base(errorDetails.Message)
    {
        ErrorDetails = errorDetails;
    }

    public ApiFluentModelStateValidationException(ErrorDetails errorDetails, Exception innerException) : base(errorDetails.Message, innerException)
    {
        ErrorDetails = errorDetails;
    }
}