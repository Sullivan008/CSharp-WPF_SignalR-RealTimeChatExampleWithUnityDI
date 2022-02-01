using Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;

public interface ICurrentNavigationWindowService : ICurrentApplicationWindowService
{
    internal INavigationWindow NavigationWindow { get; }

    public void Navigate(IPageViewNavigationOptions pageViewNavigationOptions);

    public void ReInitializeWindowSettings(Func<INavigationWindowSettingsViewModelInitializerModel> navigationWindowSettingsViewModelInitializerModelFactory);
}