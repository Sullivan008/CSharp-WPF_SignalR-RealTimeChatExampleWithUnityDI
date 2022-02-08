using Application.Client.Common.ViewModels;
using Application.Client.Windows.Core.ViewModels.WindowSettings.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Core.ViewModels.WindowSettings;

public class WindowSettingsViewModel : ViewModelBase, IWindowSettingsViewModel
{
    private string _title = string.Empty;
    public string Title
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_title, nameof(Title));

            return _title;
        }

        set
        {
            Guard.ThrowIfNullOrWhitespace(value, nameof(Title));
            _title = value;

            OnPropertyChanged();
        }
    }
}