using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SullyTech.Extensions.Enumerable;
using SullyTech.Web.Api.Controllers.Api;
using SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.ModelState;
using SullyTech.Web.Api.ErrorHandling.Core.Models;

namespace SullyTech.Web.Api.ErrorHandling.Filters.ActionFilters;

public sealed class ModelStateErrorHandlingFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ModelState.IsValid)
        {
            await next();
        }
        else
        {
            ModelStateError error = ToModelStateError(context.ModelState);

            context.Result = ((ApiController)context.Controller).ProblemWithErrors(error);
        }
    }

    private static ModelStateError ToModelStateError(ModelStateDictionary modelState)
    {
        ModelStateErrorDictionary modelStateErrorDictionary = new();

        modelState.Where(x => x.Value is not null)
                  .ForEach(modelStateEntry =>
                  {
                      modelStateEntry.Value!.Errors.ForEach(modelStateError =>
                      {
                          modelStateErrorDictionary.AddError(modelStateEntry.Key, modelStateError.ErrorMessage);
                      });
                  });

        return new ModelStateError
        {
            Errors = modelStateErrorDictionary
        };
    }
}