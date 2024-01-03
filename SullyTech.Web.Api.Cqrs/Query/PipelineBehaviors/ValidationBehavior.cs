using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SullyTech.Extensions.Enumerable;
using SullyTech.Web.Api.Cqrs.Core;
using SullyTech.Web.Api.Cqrs.Core.Interfaces;
using SullyTech.Web.Api.Cqrs.Query.Interfaces;
using SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.Validation;
using SullyTech.Web.Api.ErrorHandling.Core.Models;

namespace SullyTech.Web.Api.Cqrs.Query.PipelineBehaviors;

public sealed class ValidationBehavior<TRequest> : IPipelineBehavior<TRequest, IResult>
    where TRequest : IQuery
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<IResult> Handle(TRequest request, RequestHandlerDelegate<IResult> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            ValidationResult[] validationResults = await Validate(request, cancellationToken);

            if (validationResults.Any(x => !x.IsValid))
            {
                ValidationError validationError = ToValidationError(validationResults);

                return new Result().Error(validationError);
            }
        }

        return await next();
    }

    private async Task<ValidationResult[]> Validate(TRequest request, CancellationToken cancellationToken)
    {
        ValidationContext<TRequest> validationContext = new(request);

        return await Task.WhenAll(_validators.Select(x => x.ValidateAsync(validationContext, cancellationToken)));
    }

    private static ValidationError ToValidationError(ValidationResult[] validationResults)
    {
        IReadOnlyCollection<ValidationFailure> validationFailures = validationResults.Where(x => !x.IsValid)
                                                                                     .SelectMany(x => x.Errors)
                                                                                     .ToList();

        ValidationErrorDictionary validationErrorDictionary = new();

        validationFailures.ForEach(validationFailure =>
        {
            validationErrorDictionary.AddError(validationFailure.PropertyName, validationFailure.ErrorMessage);
        });

        return new ValidationError
        {
            Errors = validationErrorDictionary
        };
    }
}