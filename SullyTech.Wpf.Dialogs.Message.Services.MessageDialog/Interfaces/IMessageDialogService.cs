using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Services.MessageDialog.Interfaces;

public interface IMessageDialogService
{
    public Task<IMessageDialogResult> ShowDialogAsync(IMessageDialogWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null,
        IMessageDialogPresenterViewModelInitializerModel? presenterViewModelInitializerModel = null, IMessageDialogPresenterDataViewModelInitializerModel? presenterDataViewModelInitializerModel = null);
}