using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiFluentModelStateValidation.Models;

namespace SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiFluentModelStateValidation;

public class ApiFluentModelStateValidation : Exception
{
    public ErrorDetails ErrorDetails { get; }

    public ApiFluentModelStateValidation(ErrorDetails errorDetails) : base(errorDetails.Message)
    {
        ErrorDetails = errorDetails;
    }

    public ApiFluentModelStateValidation(ErrorDetails errorDetails, Exception innerException) : base(errorDetails.Message, innerException)
    {
        ErrorDetails = errorDetails;
    }
}