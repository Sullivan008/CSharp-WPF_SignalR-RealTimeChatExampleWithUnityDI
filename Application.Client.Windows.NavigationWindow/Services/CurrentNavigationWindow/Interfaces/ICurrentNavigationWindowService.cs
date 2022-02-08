using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Options.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;

public interface ICurrentNavigationWindowService : ICurrentWindowService
{
    public void NavigateContentPresenter(IContentPresenterNavigateOptions contentPresenterNavigateOptions);
}