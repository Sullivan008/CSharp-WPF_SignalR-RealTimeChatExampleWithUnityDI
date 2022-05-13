using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Options.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Interfaces;

public interface ICurrentNavigationWindowService : ICurrentWindowService
{
    public void NavigateTo(IContentPresenterNavigateOptions contentPresenterNavigateOptions);

    public Task CloseWindow();
}