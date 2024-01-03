using SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.Validation;
using SullyTech.Web.Api.ErrorHandling.Core.Models.Abstractions;

namespace SullyTech.Web.Api.ErrorHandling.Core.Models;

public sealed record ValidationError : Error
{
    public static string Title => "One or more validation errors occurred!";

    public required ValidationErrorDictionary Errors { get; init; }
}