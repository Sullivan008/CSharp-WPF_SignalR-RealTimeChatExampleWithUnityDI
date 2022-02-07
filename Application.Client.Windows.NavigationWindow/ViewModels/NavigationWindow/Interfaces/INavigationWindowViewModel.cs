using Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;

public interface INavigationWindowViewModel : IWindowViewModel
{
    public IContentPresenterViewModel CurrentPage { get; set; }

    internal ICurrentNavigationWindowService CurrentNavigationWindowService { get; }
}