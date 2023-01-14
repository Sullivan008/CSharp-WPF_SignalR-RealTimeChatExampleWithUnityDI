using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;
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

    public new async Task<IDialogWindow> GetWindowAsync(string windowId)
    {
        IWindow window = await base.GetWindowAsync(windowId);

        return (IDialogWindow)window;
    }

    public async Task<TIDialogResult> ShowDialogAsync<TIDialogResult>(IDialogWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions)
        where TIDialogResult : IDialogResult
    {
        IDialogWindow window = (IDialogWindow)CreateWindow(windowShowOptions.WindowType);
        IDialogWindowViewModel windowViewModel = (IDialogWindowViewModel)CreateWindowViewModel(window, windowShowOptions.WindowViewModelType);

        InitializeWindowViewModel(windowViewModel, windowShowOptions.WindowViewModelType, windowShowOptions.WindowViewModelInitializerModel, windowShowOptions.WindowViewModelInitializerModelType);
        InitializeWindowSettingsViewModel(windowViewModel.Settings, windowShowOptions.WindowSettingsViewModelType, windowShowOptions.WindowSettingsViewModelInitializerModel, windowShowOptions.WindowSettingsViewModelInitializerModelType);

        IPresenterViewModel presenterViewModel =
            CreatePresenterViewModel(window, presenterLoadOptions.PresenterViewModelType);

        InitializePresenterViewModel(presenterViewModel, presenterLoadOptions.PresenterViewModelType, 
                                     presenterLoadOptions.PresenterViewModelInitializerModel, presenterLoadOptions.PresenterViewModelInitializerModelType);

        InitializePresenterDataViewModel(presenterViewModel.Data, presenterLoadOptions.PresenterDataViewModelType, 
                                         presenterLoadOptions.PresenterDataViewModelInitializerModel, presenterLoadOptions.PresenterDataViewModelInitializerModelType);

        SetWindowPresenter(windowViewModel, presenterViewModel);
        SetWindowDataContext(window, windowViewModel);

        OnInitWindowSettingsViewModel(windowViewModel.Settings);
        OnInitWindowViewModel(windowViewModel);

        OnInitPresenterDataViewModel(presenterViewModel.Data);
        OnInitPresenterViewModel(presenterViewModel);

        window.ShowDialog();

        TIDialogResult dialogResult = GetDialogResult<TIDialogResult>(windowViewModel);

        return await Task.FromResult(dialogResult);
    }

    private static TIDialogResult GetDialogResult<TIDialogResult>(IDialogWindowViewModel windowViewModel)
        where TIDialogResult : IDialogResult
    {
        return (TIDialogResult)windowViewModel.DialogResult;
    }

    public async Task SetDialogResult<TIDialogResult>(IDialogWindow window, TIDialogResult dialogResult)
        where TIDialogResult : IDialogResult
    {
        window.DialogResult = true;
        ((IDialogWindowViewModel)window.DataContext).DialogResult = dialogResult;

        await Task.CompletedTask;
    }

    protected override Type WindowViewModelInitializerGenericType => typeof(IDialogWindowViewModelInitializer<,>);

    protected override Type WindowSettingsViewModelInitializerGenericType => typeof(IDialogWindowSettingsViewModelInitializer<,>);
}