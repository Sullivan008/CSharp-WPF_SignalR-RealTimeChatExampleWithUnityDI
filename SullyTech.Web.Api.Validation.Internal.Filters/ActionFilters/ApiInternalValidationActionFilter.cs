using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiInternalModelStateValidation;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiInternalModelStateValidation.Models;

namespace SullyTech.Web.Api.Validation.Internal.Filters.ActionFilters;

public sealed class ApiInternalValidationActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        CheckModelStateExceptions(context.ModelState);

        if (!context.ModelState.IsValid)
        {
            if (context.ModelState.ErrorCount > 0)
            {
                IReadOnlyCollection<string> internalModelStateErrors = context.ModelState.Values
                    .Where(x => x.Errors.Count > 0)
                    .SelectMany(x => x.Errors)
                    .Where(x => !string.IsNullOrWhiteSpace(x.ErrorMessage))
                    .Select(x => x.ErrorMessage)
                    .ToList();

                IReadOnlyCollection<ApiInternalModelStateValidationException> modelStateValidationExceptions =
                    internalModelStateErrors.Select(x => new ApiInternalModelStateValidationException(new ErrorDetails { Message = x }))
                                            .ToList();

                throw new ApiInternalModelStateValidationAggregateException(modelStateValidationExceptions);
            }

            throw new InvalidOperationException("The operation is not allowed! The model state is invalid, but does not contain any errors!");
        }

        await next();
    }

    private static void CheckModelStateExceptions(ModelStateDictionary modelStateDictionary)
    {
        ModelError? modelError = modelStateDictionary.Values
            .SelectMany(x => x.Errors.Where(y => y.Exception != null))
            .FirstOrDefault();

        if (modelError is not null && modelError.Exception is not null)
        {
            throw modelError.Exception;
        }
    }
}