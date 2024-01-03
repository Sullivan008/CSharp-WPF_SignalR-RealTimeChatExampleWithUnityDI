using SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.ModelState.Models;

namespace SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.ModelState;

public sealed class ModelStateErrorDictionary : Dictionary<string, ICollection<ModelStateErrorItem>>
{
    public void AddError(string key, ModelStateErrorItem error)
    {
        Guard.Guard.ThrowIfNull(error);
        Guard.Guard.ThrowIfNullOrWhitespace(key);

        if (TryGetValue(key, out ICollection<ModelStateErrorItem>? errors))
        {
            errors.Add(error);
        }
        else
        {
            Add(key, new List<ModelStateErrorItem> { error });
        }
    }

    public void AddError(string key, string message)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(key);
        Guard.Guard.ThrowIfNullOrWhitespace(message);

        if (TryGetValue(key, out ICollection<ModelStateErrorItem>? errors))
        {
            errors.Add(new ModelStateErrorItem { Message = message });
        }
        else
        {
            Add(key, new List<ModelStateErrorItem> { new() { Message = message } });
        }
    }
}