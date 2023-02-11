using SullyTech.Api.ExceptionHandling.Exceptions.ApiInternalModelStateValidation.Models;

namespace SullyTech.Api.ExceptionHandling.Exceptions.ApiInternalModelStateValidation;

public class ApiInternalModelStateValidationException : Exception
{
    public ErrorDetails ErrorDetails { get; }

    public ApiInternalModelStateValidationException(ErrorDetails errorDetails) : base(errorDetails.Message)
    {
        ErrorDetails = errorDetails;
    }

    public ApiInternalModelStateValidationException(ErrorDetails errorDetails, Exception innerException) : base(errorDetails.Message, innerException)
    {
        ErrorDetails = errorDetails;
    }
}