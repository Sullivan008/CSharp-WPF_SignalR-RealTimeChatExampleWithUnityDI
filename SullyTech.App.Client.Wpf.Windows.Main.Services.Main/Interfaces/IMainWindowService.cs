using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.App.Client.Wpf.Windows.Main.Services.Main.Interfaces;

public interface IMainWindowService
{
    public Task ShowAsync<TIPresenterViewModel, TIPresenterDataViewModel>(IMainWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null)
        where TIPresenterViewModel : IPresenterViewModel
        where TIPresenterDataViewModel : IPresenterDataViewModel;
}