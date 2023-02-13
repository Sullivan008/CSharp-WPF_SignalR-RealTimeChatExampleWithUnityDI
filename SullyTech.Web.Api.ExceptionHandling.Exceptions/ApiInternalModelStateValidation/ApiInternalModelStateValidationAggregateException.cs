namespace SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiInternalModelStateValidation;

public class ApiInternalModelStateValidationAggregateException : AggregateException
{
    public ApiInternalModelStateValidationAggregateException(IReadOnlyCollection<ApiInternalModelStateValidationException> exceptions)
        : base(exceptions)
    { }

    public ApiInternalModelStateValidationAggregateException(string message, IReadOnlyCollection<ApiInternalModelStateValidationException> exceptions)
        : base(message, exceptions)
    { }
}