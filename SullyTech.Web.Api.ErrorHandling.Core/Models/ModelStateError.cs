using SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.ModelState;
using SullyTech.Web.Api.ErrorHandling.Core.Models.Abstractions;

namespace SullyTech.Web.Api.ErrorHandling.Core.Models;

public sealed record ModelStateError : Error
{
    public string Title => "An error occurred during 'Model Binding' or the 'Model state' is invalid!";

    public required ModelStateErrorDictionary Errors { get; init; }
}