using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ViewModels.WindowSettings.Interfaces;

namespace Application.Client.Windows.Core.ViewModels.Window.Interfaces;

public interface IWindowViewModel
{
    public IContentPresenterViewModel ContentPresenter { get; set; }

    internal IWindowSettingsViewModel WindowSettings { get; }
}