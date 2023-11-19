using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Providers.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Result.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow;

public class DialogWindowService : WindowService, IDialogWindowService
{
    private readonly IWindowProvider _windowProvider;

    public DialogWindowService(IServiceProvider serviceProvider, IWindowProvider windowProvider) : base(serviceProvider)
    {
        _windowProvider = windowProvider;
    }

    public async Task<TIDialogResult> ShowDialogAsync<TIDialogResult>(IDialogWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions)
        where TIDialogResult : IDialogResult
    {
        IDialogWindow window = (IDialogWindow)CreateWindow(windowShowOptions.WindowType);
        IDialogWindowViewModel windowViewModel = (IDialogWindowViewModel)CreateWindowViewModel(window, windowShowOptions.WindowViewModelType);

        IPresenter presenter = CreatePresenter(window, presenterLoadOptions.PresenterType);
        IPresenterViewModel presenterViewModel = CreatePresenterViewModel(window, presenterLoadOptions.PresenterViewModelType);

        InitializeWindowViewModels(windowViewModel, windowShowOptions);
        InitializePresenterViewModels(presenterViewModel, presenterLoadOptions);

        SetWindow(window, windowViewModel, presenter, presenterViewModel);

        await OnBeforeLoadAsync(windowViewModel, presenter, presenterViewModel);

        window.ShowDialog();

        TIDialogResult dialogResult = GetDialogResult<TIDialogResult>(windowViewModel);

        return dialogResult;
    }

    private void InitializeWindowViewModels(IWindowViewModel windowViewModel, IDialogWindowShowOptions windowShowOptions)
    {
        InitializeWindowViewModel(windowViewModel, windowShowOptions.WindowViewModelType,
                                  windowShowOptions.WindowViewModelInitializerModel, windowShowOptions.WindowViewModelInitializerModelType);

        InitializeWindowSettingsViewModel(windowViewModel.Settings, windowShowOptions.WindowSettingsViewModelType,
                                          windowShowOptions.WindowSettingsViewModelInitializerModel, windowShowOptions.WindowSettingsViewModelInitializerModelType);
    }

    private void InitializePresenterViewModels(IPresenterViewModel presenterViewModel, IPresenterLoadOptions presenterLoadOptions)
    {
        InitializePresenterViewModel(presenterViewModel, presenterLoadOptions.PresenterViewModelType,
                                     presenterLoadOptions.PresenterViewModelInitializerModel, presenterLoadOptions.PresenterViewModelInitializerModelType);

        InitializePresenterDataViewModel(presenterViewModel.Data, presenterLoadOptions.PresenterDataViewModelType,
                                         presenterLoadOptions.PresenterDataViewModelInitializerModel, presenterLoadOptions.PresenterDataViewModelInitializerModelType);
    }

    private void SetWindow(IDialogWindow window, IDialogWindowViewModel windowViewModel, IPresenter presenter, IPresenterViewModel presenterViewModel)
    {
        SetPresenterDataContext(presenter, presenterViewModel);
        SetWindowPresenter(windowViewModel, presenter);
        SetWindowDataContext(window, windowViewModel);
    }

    private static async Task OnBeforeLoadAsync(IDialogWindowViewModel windowViewModel, IPresenter presenter, IPresenterViewModel presenterViewModel)
    {
        await presenterViewModel.Data.OnBeforeLoadAsync();
        await presenterViewModel.OnBeforeLoadAsync();
        await presenter.OnBeforeLoadAsync();

        await windowViewModel.Settings.OnBeforeLoadAsync();
        await windowViewModel.OnBeforeLoadAsync();
    }

    private static TIDialogResult GetDialogResult<TIDialogResult>(IDialogWindowViewModel windowViewModel)
        where TIDialogResult : IDialogResult
    {
        return (TIDialogResult)windowViewModel.DialogResult;
    }

    public async Task SetDialogResultAsync<TIDialogResult>(string windowId, TIDialogResult dialogResult)
        where TIDialogResult : IDialogResult
    {
        IDialogWindow window = (IDialogWindow)await _windowProvider.GetWindowAsync(windowId);

        window.DialogResult = true;
        ((IDialogWindowViewModel)window.DataContext).DialogResult = dialogResult;
    }
}