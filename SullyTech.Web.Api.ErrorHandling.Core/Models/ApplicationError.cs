namespace SullyTech.Web.Api.ErrorHandling.Core.Models;

public sealed record ApplicationError
{
    public required string Title { get; init; }

    public required string Detail { get; init; }
}