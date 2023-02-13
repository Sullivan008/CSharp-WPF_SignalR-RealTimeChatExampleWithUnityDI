using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiFluentModelStateValidation;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiFluentModelStateValidation.Models;

namespace SullyTech.Web.Api.Validation.Fluent.Validator;

public abstract class ApiRequestModelValidator<TApiRequestModel> : AbstractValidator<TApiRequestModel>, IValidatorInterceptor
{
    public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
    {
        return commonContext;
    }

    public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
    {
        if (HasAnyValidationError(result))
        {
            result.Errors.ForEach(validationFailure =>
            {
                ErrorDetails errorDetails = MapValidationFailureToErrorDetails(validationFailure);

                if (!actionContext.ModelState.TryAddModelException(errorDetails.Code.ToString(), new ApiFluentModelStateValidationException(errorDetails)))
                {
                    throw new InvalidOperationException(
                        $"Failed to add {nameof(ApiFluentModelStateValidationException)} to {nameof(actionContext.ModelState)}. Error Details - Code: {errorDetails.Code}");
                }
            });
        }

        return result;
    }

    private static bool HasAnyValidationError(ValidationResult validationResult)
    {
        return !validationResult.IsValid && validationResult.Errors.Any();
    }

    private static ErrorDetails MapValidationFailureToErrorDetails(ValidationFailure validationFailure)
    {
        return new ErrorDetails
        {
            Code = int.TryParse(validationFailure.ErrorCode, out int code) ? code : 0,
            Message = validationFailure.ErrorMessage
        };
    }
}