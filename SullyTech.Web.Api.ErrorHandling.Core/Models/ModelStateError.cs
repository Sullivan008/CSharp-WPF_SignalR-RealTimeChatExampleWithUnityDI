using SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.ModelState;

namespace SullyTech.Web.Api.ErrorHandling.Core.Models;

public sealed record ModelStateError
{
    public string Title => "An error occurred during model binding or the model stat is invalid!";

    public required ModelStateErrorDictionary Errors { get; init; }
}