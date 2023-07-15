namespace SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiModelStateValidation;

public class ApiModelStateValidationAggregateException : AggregateException
{
    public ApiModelStateValidationAggregateException(IReadOnlyCollection<ApiModelStateValidationException> exceptions)
        : base(exceptions)
    { }

    public ApiModelStateValidationAggregateException(string message, IReadOnlyCollection<ApiModelStateValidationException> exceptions)
        : base(message, exceptions)
    { }
}