using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;

public interface ICurrentNavigationWindowService
{
    internal INavigationWindow NavigationWindow { get; }

    public void ReInitializeWindowSettings(Func<INavigationWindowSettingsViewModelInitializerModel> navigationWindowSettingsViewModelInitializerModelFactory);
}