using SullyTech.Wpf.Dialogs.MessageDialog.Services.MessageDialog.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.MethodParameters.WindowShowOptions;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Services.MessageDialog;

public sealed class MessageDialogService : IMessageDialogService
{
    private readonly IDialogWindowService _dialogWindowService;

    public MessageDialogService(IDialogWindowService dialogWindowService)
    {
        _dialogWindowService = dialogWindowService;
    }

    public async Task<IMessageDialogResult> ShowDialogAsync(IMessageDialogWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null,
        IMessageDialogViewModelInitializerModel? presenterViewModelInitializerModel = null, IMessageDialogDataViewModelInitializerModel? presenterDataViewModelInitializerModel = null)
    {
        IDialogWindowShowOptions windowShowOptions = new DialogWindowShowOptions<IMessageDialogWindow, IMessageDialogWindowViewModel, IMessageDialogWindowSettingsViewModel>
        {
            WindowSettingsViewModelInitializerModel = windowSettingsViewModelInitializerModel
        };

        IPresenterLoadOptions presenterLoadOptions = new PresenterLoadOptions<IMessageDialogViewModel, IMessageDialogDataViewModel>
        {
            PresenterViewModelInitializerModel = presenterViewModelInitializerModel,
            PresenterDataViewModelInitializerModel = presenterDataViewModelInitializerModel
        };

        return await _dialogWindowService.ShowDialogAsync<IMessageDialogResult>(windowShowOptions, presenterLoadOptions);
    }
}