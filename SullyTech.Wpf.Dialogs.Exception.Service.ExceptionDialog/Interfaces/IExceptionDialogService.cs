using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.Exception.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializer.Models.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Exception.Service.ExceptionDialog.Interfaces;

public interface IExceptionDialogService
{
    public Task<IExceptionDialogResult> ShowDialogAsync(IExceptionDialogWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null,
        IExceptionDialogPresenterDataViewModelInitializerModel? presenterDataViewModelInitializerModel = null);
}