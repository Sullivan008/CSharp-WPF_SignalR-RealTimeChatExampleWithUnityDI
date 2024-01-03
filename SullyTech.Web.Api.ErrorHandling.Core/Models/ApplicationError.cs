using SullyTech.Web.Api.ErrorHandling.Core.Models.Abstractions;

namespace SullyTech.Web.Api.ErrorHandling.Core.Models;

public sealed record ApplicationError : Error
{
    public required string Title { get; init; }

    public required string Detail { get; init; }
}