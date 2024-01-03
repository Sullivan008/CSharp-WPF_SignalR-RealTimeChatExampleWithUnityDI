using SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.ModelState;
using SullyTech.Web.Api.ErrorHandling.Core.Models.Abstractions;

namespace SullyTech.Web.Api.ErrorHandling.Core.Models;

public sealed record ModelStateError : Error
{
    public string Title => "An error occurred during model binding or the model stat is invalid!";

    public required ModelStateErrorDictionary Errors { get; init; }
}