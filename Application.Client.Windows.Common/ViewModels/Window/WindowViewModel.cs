using Application.Client.Common.ViewModels;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window.Interfaces;
using Application.Client.Windows.Core.ViewModels.WindowSettings.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Core.ViewModels.Window;

public class WindowViewModel<TWindowSettingsViewModel> : ViewModelBase, IWindowViewModel 
    where TWindowSettingsViewModel : IWindowSettingsViewModel, new()
{
    private TWindowSettingsViewModel _windowSettings = new();
    public TWindowSettingsViewModel WindowSettings
    {
        get => _windowSettings;
        set
        {
            Guard.ThrowIfNull(value, nameof(WindowSettings));
            _windowSettings = value;

            OnPropertyChanged();
        }
    }

    private IContentPresenterViewModel? _contentPresenter;
    public IContentPresenterViewModel ContentPresenter
    {
        get
        {
            Guard.ThrowIfNull(_contentPresenter, nameof(ContentPresenter));

            return _contentPresenter!;
        }

        set
        {
            Guard.ThrowIfNull(value, nameof(ContentPresenter));
            _contentPresenter = value;

            OnPropertyChanged();
        }
    }
}