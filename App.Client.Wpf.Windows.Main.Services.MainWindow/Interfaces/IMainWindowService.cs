using App.Client.Wpf.Windows.Main.Window.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;

namespace App.Client.Wpf.Windows.Main.Services.MainWindow.Interfaces;

public interface IMainWindowService
{
    public Task ShowAsync(IPresenterLoadOptions presenterLoadOptions, IMainWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null);
}