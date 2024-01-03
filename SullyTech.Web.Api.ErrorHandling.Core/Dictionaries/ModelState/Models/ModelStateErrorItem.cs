namespace SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.ModelState.Models;

public sealed record ModelStateErrorItem
{
    public required string Message { get; init; }
}