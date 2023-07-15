using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiModelStateValidation;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiModelStateValidation.Models;

namespace SullyTech.Web.Api.Validation.ModelState.Filters.ActionFilters;

public sealed class ApiModelStateValidationActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        CheckModelStateExceptions(context.ModelState);

        if (!context.ModelState.IsValid)
        {
            IReadOnlyCollection<string> internalModelStateErrors = context.ModelState.Values
                .Where(x => x.Errors.Count > 0)
                .SelectMany(x => x.Errors)
                .Where(x => !string.IsNullOrWhiteSpace(x.ErrorMessage))
                .Select(x => x.ErrorMessage)
                .ToList();

            IReadOnlyCollection<ApiModelStateValidationException> modelStateValidationExceptions =
                internalModelStateErrors.Select(x => new ApiModelStateValidationException(new ErrorDetails { Message = x }))
                                        .ToList();

            throw new ApiModelStateValidationAggregateException(modelStateValidationExceptions);
        }

        await next();
    }

    private static void CheckModelStateExceptions(ModelStateDictionary modelStateDictionary)
    {
        ModelError? modelError = modelStateDictionary.Values
            .SelectMany(x => x.Errors.Where(y => y.Exception != null))
            .FirstOrDefault();

        if (modelError?.Exception != null)
        {
            throw modelError.Exception;
        }
    }
}