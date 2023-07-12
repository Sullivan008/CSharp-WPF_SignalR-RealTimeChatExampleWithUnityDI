using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Service.ExceptionDialog.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.Exception.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Exception.Service.ExceptionDialog;

public sealed class ExceptionDialogService : IExceptionDialogService
{
    private readonly IDialogWindowService _dialogWindowService;

    public ExceptionDialogService(IDialogWindowService dialogWindowService)
    {
        _dialogWindowService = dialogWindowService;
    }

    public async Task<IExceptionDialogResult> ShowDialogAsync(IExceptionDialogWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel = null,
        IExceptionDialogPresenterDataViewModelInitializerModel? presenterDataViewModelInitializerModel = null)
    {
        IDialogWindowShowOptions windowShowOptions = new DialogWindowShowOptions<IExceptionDialogWindow, IExceptionDialogWindowViewModel, IExceptionDialogWindowSettingsViewModel>
        {
            WindowSettingsViewModelInitializerModel = windowSettingsViewModelInitializerModel
        };

        IPresenterLoadOptions presenterLoadOptions = new PresenterLoadOptions<IExceptionDialogPresenter, IExceptionDialogPresenterViewModel, IExceptionDialogPresenterDataViewModel>
        {
            PresenterDataViewModelInitializerModel = presenterDataViewModelInitializerModel
        };

        return await _dialogWindowService.ShowDialogAsync<IExceptionDialogResult>(windowShowOptions, presenterLoadOptions);
    }
}