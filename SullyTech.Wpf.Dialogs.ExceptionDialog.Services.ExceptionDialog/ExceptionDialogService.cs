using SullyTech.Wpf.Dialogs.ExceptionDialog.Services.ExceptionDialog.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.MethodParameters.WindowShowOptions;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Services.ExceptionDialog;

public sealed class ExceptionDialogService : IExceptionDialogService
{
    private readonly IDialogWindowService _dialogWindowService;

    public ExceptionDialogService(IDialogWindowService dialogWindowService)
    {
        _dialogWindowService = dialogWindowService;
    }

    public async Task<IExceptionDialogResult> ShowDialogAsync(IExceptionDialogWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null,
        IExceptionDialogDataViewModelInitializerModel? presenterDataViewModelInitializerModel = null)
    {
        IDialogWindowShowOptions windowShowOptions = new DialogWindowShowOptions<IExceptionDialogWindow, IExceptionDialogWindowViewModel, IExceptionDialogWindowSettingsViewModel>
        {
            WindowSettingsViewModelInitializerModel = windowSettingsViewModelInitializerModel
        };

        IPresenterLoadOptions presenterLoadOptions = new PresenterLoadOptions<IExceptionDialogViewModel, IExceptionDialogDataViewModel>
        {
            PresenterDataViewModelInitializerModel = presenterDataViewModelInitializerModel
        };

        return await _dialogWindowService.ShowDialogAsync<IExceptionDialogResult>(windowShowOptions, presenterLoadOptions);
    }
}