using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.Services.WindowService.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.Services.NavigationWindow.Options.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Core.Services.NavigationWindow.Interfaces;

public interface INavigationWindowService : IWindowService
{
    public Task ShowAsync(INavigationWindowShowOptionsModel navigationWindowOptions, IContentPresenterLoadOptions contentPresenterLoadOptions);
}