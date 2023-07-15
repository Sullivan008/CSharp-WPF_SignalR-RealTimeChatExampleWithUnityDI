using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiModelStateValidation.Models;

namespace SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiModelStateValidation;

public class ApiModelStateValidationException : Exception
{
    public ErrorDetails ErrorDetails { get; }

    public ApiModelStateValidationException(ErrorDetails errorDetails) : base(errorDetails.Message)
    {
        ErrorDetails = errorDetails;
    }

    public ApiModelStateValidationException(ErrorDetails errorDetails, Exception innerException) : base(errorDetails.Message, innerException)
    {
        ErrorDetails = errorDetails;
    }
}