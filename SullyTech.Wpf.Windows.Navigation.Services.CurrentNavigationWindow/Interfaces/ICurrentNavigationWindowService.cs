using SullyTech.Wpf.Windows.Core.Services.CurrentWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.MethodParameters.NavigateToOptions.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;

public interface ICurrentNavigationWindowService : ICurrentWindowService
{
    public Task NavigateToAsync(INavigateToOptions navigateToOptions);
}