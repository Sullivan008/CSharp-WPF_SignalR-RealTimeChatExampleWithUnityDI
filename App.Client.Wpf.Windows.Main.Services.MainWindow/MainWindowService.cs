using App.Client.Wpf.Windows.Main.Services.MainWindow.Interfaces;
using App.Client.Wpf.Windows.Main.Window.Interfaces;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.MethodParameters.WindowShowOptions;

namespace App.Client.Wpf.Windows.Main.Services.MainWindow;

public sealed class MainWindowService : IMainWindowService
{
    private readonly IStandardWindowService _standardWindowService;

    public MainWindowService(IStandardWindowService standardWindowService)
    {
        _standardWindowService = standardWindowService;
    }

    public async Task ShowAsync(IPresenterLoadOptions presenterLoadOptions, IMainWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null)
    {
        await _standardWindowService.ShowWindowAsync(
            windowShowOptions: new StandardWindowShowOptions<IMainWindow, IMainWindowViewModel, IMainWindowSettingsViewModel>
            {
                WindowSettingsViewModelInitializerModel = windowSettingsViewModelInitializerModel
            },
            presenterLoadOptions: presenterLoadOptions);
    }
}