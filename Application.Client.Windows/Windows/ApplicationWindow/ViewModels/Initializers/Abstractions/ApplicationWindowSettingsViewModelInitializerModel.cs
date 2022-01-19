using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Initializers.Abstractions;

public class ApplicationWindowSettingsViewModelInitializerModel
{
    private readonly string _title = string.Empty;
    public string Title
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_title, nameof(Title));

            return _title;
        }

        init => _title = value;
    }
}