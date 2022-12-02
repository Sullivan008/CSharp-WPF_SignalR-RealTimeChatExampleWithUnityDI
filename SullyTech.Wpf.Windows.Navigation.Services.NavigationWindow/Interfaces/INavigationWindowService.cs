using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Core.Services.Window.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.WindowShowOptions.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;

public interface INavigationWindowService : IWindowService
{
    public Task ShowAsync(INavigationWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions);
}