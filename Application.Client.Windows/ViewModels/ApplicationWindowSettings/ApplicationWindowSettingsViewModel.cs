using Application.Client.Common.ViewModels;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings;

public class ApplicationWindowSettingsViewModel : ViewModelBase, IApplicationWindowSettingsViewModel
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