using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Services.MessageDialog.Interfaces;

public interface IMessageDialogService
{
    public Task<IMessageDialogResult> ShowDialogAsync(IMessageDialogWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null,
        IMessageDialogViewModelInitializerModel? presenterViewModelInitializerModel = null, IMessageDialogDataViewModelInitializerModel? presenterDataViewModelInitializerModel = null);
}