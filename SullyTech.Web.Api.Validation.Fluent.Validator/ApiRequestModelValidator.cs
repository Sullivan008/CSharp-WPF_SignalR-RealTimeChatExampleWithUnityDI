using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SullyTech.Web.Api.Contracts.Interfaces.RequestModels;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiRequestModelValidation;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiRequestModelValidation.Models;

namespace SullyTech.Web.Api.Validation.Fluent.Validator;

public abstract class ApiRequestModelValidator<TApiRequestModel> : AbstractValidator<TApiRequestModel>, IValidatorInterceptor
    where TApiRequestModel : IApiRequestModel
{
    public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
    {
        return commonContext;
    }

    public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult validationResult)
    {
        if (!validationResult.IsValid)
        {
            validationResult.Errors.ForEach(validationFailure =>
            {
                ErrorDetails errorDetails = MapValidationFailureToErrorDetails(validationFailure);

                if (!actionContext.ModelState.TryAddModelException(errorDetails.Code.ToString(), new ApiRequestModelValidationException(errorDetails)))
                {
                    throw new InvalidOperationException(
                        $"Failed to add {nameof(ApiRequestModelValidationException)} to {nameof(actionContext.ModelState)}. Error Details - Code: {errorDetails.Code}");
                }
            });
        }


        return validationResult;
    }
    
    private static ErrorDetails MapValidationFailureToErrorDetails(ValidationFailure validationFailure)
    {
        return new ErrorDetails
        {
            Code = int.Parse(validationFailure.ErrorCode),
            Message = validationFailure.ErrorMessage
        };
    }
}