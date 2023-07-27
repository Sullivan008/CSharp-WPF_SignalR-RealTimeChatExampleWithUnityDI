using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.Message.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializer.Models.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Message.Services.MessageDialog.Interfaces;

public interface IMessageDialogService
{
    public Task<IMessageDialogResult> ShowDialogAsync(IMessageDialogWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null,
        IMessageDialogPresenterViewModelInitializerModel? presenterViewModelInitializerModel = null, IMessageDialogPresenterDataViewModelInitializerModel? presenterDataViewModelInitializerModel = null);
}