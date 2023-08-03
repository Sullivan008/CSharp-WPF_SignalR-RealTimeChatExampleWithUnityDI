using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiRequestModelValidation;

namespace SullyTech.Web.Api.Validation.Fluent.Filters.ActionFilters;

public sealed class ApiFluentValidationActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        ModelError? modelError = context.ModelState.Values.SelectMany(x => x.Errors.Where(y => y.Exception is ApiRequestModelValidationException))
                                                          .FirstOrDefault();

        if (modelError?.Exception is not null)
        {
            throw modelError.Exception;
        }

        await next();
    }
}