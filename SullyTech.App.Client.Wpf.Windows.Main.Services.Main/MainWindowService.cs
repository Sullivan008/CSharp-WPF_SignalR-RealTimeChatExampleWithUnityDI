using SullyTech.App.Client.Wpf.Windows.Main.Services.Main.Interfaces;
using SullyTech.App.Client.Wpf.Windows.Main.Window.Interfaces;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.MethodParameters.WindowShowOptions;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.MethodParameters.WindowShowOptions.Interfaces;

namespace SullyTech.App.Client.Wpf.Windows.Main.Services.Main;

public sealed class MainWindowService : IMainWindowService
{
    private readonly INavigationWindowService _navigationWindowService;

    public MainWindowService(INavigationWindowService navigationWindowService)
    {
        _navigationWindowService = navigationWindowService;
    }

    public async Task ShowAsync<TIPresenterViewModel, TIPresenterDataViewModel>(IMainWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null)
        where TIPresenterViewModel : IPresenterViewModel
        where TIPresenterDataViewModel : IPresenterDataViewModel
    {
        INavigationWindowShowOptions windowShowOptions = new NavigationWindowShowOptions<IMainWindow, IMainWindowViewModel, IMainWindowSettingsViewModel>
        {
            WindowSettingsViewModelInitializerModel = windowSettingsViewModelInitializerModel
        };

        IPresenterLoadOptions presenterLoadOptions = new PresenterLoadOptions<TIPresenterViewModel, TIPresenterDataViewModel>();

        await _navigationWindowService.ShowAsync(windowShowOptions, presenterLoadOptions);
    }
}