using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.MethodParameters.NavigateToOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.MethodParameters.WindowShowOptions.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.Interfaces;

public interface INavigationWindowService : IWindowService
{
    public Task<INavigationWindow> GetWindowAsync(string windowId);

    public Task ShowAsync(INavigationWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions);

    public Task NavigateToAsync(INavigationWindow window, INavigateToOptions navigateToOptions);
}