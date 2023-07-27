using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Services.MessageDialog.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.Message.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Message.Services.MessageDialog;

public sealed class MessageDialogService : IMessageDialogService
{
    private readonly IDialogWindowService _dialogWindowService;

    public MessageDialogService(IDialogWindowService dialogWindowService)
    {
        _dialogWindowService = dialogWindowService;
    }

    public async Task<IMessageDialogResult> ShowDialogAsync(IMessageDialogWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null,
        IMessageDialogPresenterViewModelInitializerModel? presenterViewModelInitializerModel = null, IMessageDialogPresenterDataViewModelInitializerModel? presenterDataViewModelInitializerModel = null)
    {
        IDialogWindowShowOptions windowShowOptions = new DialogWindowShowOptions<IMessageDialogWindow, IMessageDialogWindowViewModel, IMessageDialogWindowSettingsViewModel>
        {
            WindowSettingsViewModelInitializerModel = windowSettingsViewModelInitializerModel
        };

        IPresenterLoadOptions presenterLoadOptions = new PresenterLoadOptions<IMessageDialogPresenter, IMessageDialogPresenterViewModel, IMessageDialogPresenterDataViewModel>
        {
            PresenterViewModelInitializerModel = presenterViewModelInitializerModel,
            PresenterDataViewModelInitializerModel = presenterDataViewModelInitializerModel
        };

        return await _dialogWindowService.ShowDialogAsync<IMessageDialogResult>(windowShowOptions, presenterLoadOptions);
    }
}