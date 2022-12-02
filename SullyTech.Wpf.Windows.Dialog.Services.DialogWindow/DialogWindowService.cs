using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Services.DialogWindow;

public class DialogWindowService : WindowService, IDialogWindowService
{
    public DialogWindowService(IServiceProvider serviceProvider) : base(serviceProvider)
    { }

    public async Task<TDialogResult> ShowDialogAsync<TDialogResult>(IDialogWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions)
        where TDialogResult : IDialogResult
    {
        IDialogWindow window = (IDialogWindow)CreateWindow(windowShowOptions.WindowType);
        IDialogWindowViewModel windowViewModel = (IDialogWindowViewModel)CreateWindowViewModel(windowShowOptions.WindowViewModelType);

        InitializeWindowViewModel(windowViewModel, windowShowOptions.WindowViewModelInitializerModel);
        InitializeWindowSettingsViewModel(windowViewModel.Settings, windowShowOptions.WindowSettingsViewModelInitializerModel);

        ICurrentDialogWindowService currentWindowService = (ICurrentDialogWindowService)CreateCurrentWindowService(window);

        IPresenterViewModel presenterViewModel =
            CreatePresenterViewModel(presenterLoadOptions.PresenterViewModelType, currentWindowService);

        InitializePresenterViewModel(presenterViewModel, presenterLoadOptions.PresenterViewModelInitializerModel);
        InitializePresenterDataViewModel(presenterViewModel.Data, presenterLoadOptions.PresenterDataViewModelInitializerModel);

        SetWindowPresenter(windowViewModel, presenterViewModel);
        SetWindowDataContext(window, windowViewModel);

        window.ShowDialog();

        TDialogResult dialogResult = GetDialogResult<TDialogResult>(windowViewModel);

        return await Task.FromResult(dialogResult);
    }

    private static TDialogResult GetDialogResult<TDialogResult>(IDialogWindowViewModel windowViewModel)
        where TDialogResult : IDialogResult
    {
        return (TDialogResult)windowViewModel.DialogResult;
    }

    protected override Type CurrentWindowServiceType => typeof(ICurrentDialogWindowService);

    protected override Type WindowViewModelInitializerGenericType => typeof(IDialogWindowViewModelInitializer<,>);

    protected override Type WindowSettingsViewModelInitializerGenericType => typeof(IDialogWindowSettingsViewModelInitializer<,>);
}