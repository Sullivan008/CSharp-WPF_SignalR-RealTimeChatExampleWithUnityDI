using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Services.ExceptionDialog.Interfaces;

public interface IExceptionDialogService
{
    public Task<IExceptionDialogResult> ShowDialogAsync(IExceptionDialogWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null,
        IExceptionDialogDataViewModelInitializerModel? presenterDataViewModelInitializerModel = null);
}