using Application.Client.Common.ViewModels;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Abstractions;

public abstract class ApplicationWindowSettingsViewModelBase : ViewModelBase
{
    private string _title = string.Empty;
    public string Title
    {
        get => _title;
        set
        {
            Guard.ThrowIfNullOrWhitespace(value, nameof(Title));
            _title = value;

            OnPropertyChanged();
        }
    }
}