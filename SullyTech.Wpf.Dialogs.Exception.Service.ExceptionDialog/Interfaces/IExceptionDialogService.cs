using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.Exception.Service.ExceptionDialog.Interfaces;

public interface IExceptionDialogService
{
    public Task<IExceptionDialogResult> ShowDialogAsync(IExceptionDialogWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null,
        IExceptionDialogPresenterDataViewModelInitializerModel? presenterDataViewModelInitializerModel = null);
}