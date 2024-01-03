using SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.Validation.Models;

namespace SullyTech.Web.Api.ErrorHandling.Core.Dictionaries.Validation;

public sealed class ValidationErrorDictionary : Dictionary<string, ICollection<ValidationErrorItem>>
{
    public void AddError(string key, ValidationErrorItem error)
    {
        Guard.Guard.ThrowIfNull(error);
        Guard.Guard.ThrowIfNullOrWhitespace(key);

        if (TryGetValue(key, out ICollection<ValidationErrorItem>? errors))
        {
            errors.Add(error);
        }
        else
        {
            Add(key, new List<ValidationErrorItem> { error });
        }
    }

    public void AddError(string key, string message)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(key);
        Guard.Guard.ThrowIfNullOrWhitespace(message);

        if (TryGetValue(key, out ICollection<ValidationErrorItem>? errors))
        {
            errors.Add(new ValidationErrorItem { Message = message });
        }
        else
        {
            Add(key, new List<ValidationErrorItem> { new() { Message = message } });
        }
    }
}