namespace SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.Validation.Models;

public sealed record ValidationErrorItem
{
    public required string Message { get; init; }
}