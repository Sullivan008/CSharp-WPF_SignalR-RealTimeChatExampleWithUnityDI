using SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.Validation;

namespace SullyTech.Web.Api.ErrorHandling.Core.Models;

public sealed record ValidationError
{
    public string Title => "One or more validation errors occurred!";

    public required ValidationErrorDictionary Errors { get; init; }
}