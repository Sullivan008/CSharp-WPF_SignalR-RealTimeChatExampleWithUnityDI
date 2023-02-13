using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiFluentModelStateValidation;

namespace SullyTech.Web.Api.Validation.Fluent.Filters.ActionFilters;

public sealed class ApiFluentValidationActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        ModelError? modelError = 
            context.ModelState.Values.SelectMany(x => x.Errors.Where(y => y.Exception != null && y.Exception is ApiFluentModelStateValidationException))
                                     .FirstOrDefault();

        if (modelError is not null && modelError.Exception is not null)
        {
            throw modelError.Exception;
        }

        await next();
    }
}