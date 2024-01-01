using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Guid.Interfaces;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Initializers.Models;
using SullyTech.Wpf.Controls.Window.Dialog.Core.Results;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window.Initializers.Models;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Providers.Window.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow;

internal sealed class DialogWindowService : IDialogWindowService
{
    private readonly IServiceProvider _serviceProvider;


    private readonly IGuid _guid;

    private readonly IMapper _mapper;


    private readonly IWindowProvider _windowProvider;

    public DialogWindowService(IServiceProvider serviceProvider, IGuid guid, IMapper mapper, IWindowProvider windowProvider)
    {
        _serviceProvider = serviceProvider;

        _guid = guid;
        _mapper = mapper;

        _windowProvider = windowProvider;
    }

    public async Task<TDialogResult> ShowDialogAsync<TDialogWindow, TDialogResult,
                                                     TDialogWindowViewModel, TPresenter, TPresenterViewModel>(DialogWindowViewModelInitializerModel? windowViewModelInitializerModel = null,
                                                                                                              PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TDialogWindow : Core.UserControls.DialogWindow
        where TDialogResult : DialogResult
        where TDialogWindowViewModel : DialogWindowViewModel
        where TPresenter : Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        TDialogWindow window = CreateWindow<TDialogWindow>();
        TDialogWindowViewModel windowViewModel = CreateWindowViewModel<TDialogWindow, TDialogWindowViewModel>(window);

        TPresenter presenter = CreatePresenter<TDialogWindow, TPresenter>(window);
        TPresenterViewModel presenterViewModel = CreatePresenterViewModel<TDialogWindow, TPresenterViewModel>(window);

        if (windowViewModelInitializerModel is not null)
        {
            InitializeWindowViewModels(windowViewModel, windowViewModelInitializerModel);
        }

        if (presenterViewModelInitializerModel is not null)
        {
            InitializePresenterViewModels(presenterViewModel, presenterViewModelInitializerModel);
        }

        SetWindow(window, windowViewModel, presenter, presenterViewModel);

        await OnBeforeLoadAsync(windowViewModel, presenter, presenterViewModel);

        window.ShowDialog();

        TDialogResult? dialogResult = GetDialogResult<TDialogWindow, TDialogResult>(window);
        Guard.Guard.ThrowIfNull(dialogResult);

        return dialogResult!;
    }

    private TDialogWindow CreateWindow<TDialogWindow>()
        where TDialogWindow : Core.UserControls.DialogWindow
    {
        TDialogWindow window = (TDialogWindow)_serviceProvider.GetRequiredService(typeof(TDialogWindow));

        window.Id = _guid.NewGuid()
                         .ToString();

        return window;
    }

    private TDialogWindowViewModel CreateWindowViewModel<TDialogWindow, TDialogWindowViewModel>(TDialogWindow window)
        where TDialogWindow : Core.UserControls.DialogWindow
        where TDialogWindowViewModel : DialogWindowViewModel
    {
        TDialogWindowViewModel windowViewModel = (TDialogWindowViewModel)_serviceProvider.GetRequiredService(typeof(TDialogWindowViewModel));
        windowViewModel.Id = window.Id;

        return windowViewModel;
    }

    private TPresenter CreatePresenter<TDialogWindow, TPresenter>(TDialogWindow window)
        where TDialogWindow : Core.UserControls.DialogWindow
        where TPresenter : Presenter.Core.UserControls.Presenter.Presenter
    {
        TPresenter presenter = (TPresenter)_serviceProvider.GetRequiredService(typeof(TPresenter));
        presenter.WindowId = window.Id;

        return presenter;
    }

    private TPresenterViewModel CreatePresenterViewModel<TDialogWindow, TPresenterViewModel>(TDialogWindow window)
        where TDialogWindow : Core.UserControls.DialogWindow
        where TPresenterViewModel : PresenterViewModel
    {
        TPresenterViewModel presenterViewModel = (TPresenterViewModel)_serviceProvider.GetRequiredService(typeof(TPresenterViewModel));
        presenterViewModel.WindowId = window.Id;

        return presenterViewModel;
    }

    private void InitializeWindowViewModels<TDialogWindowViewModel>(TDialogWindowViewModel windowViewModel, DialogWindowViewModelInitializerModel windowViewModelInitializerModel)
        where TDialogWindowViewModel : DialogWindowViewModel
    {
        _mapper.Map(windowViewModelInitializerModel, windowViewModel,
                    windowViewModelInitializerModel.GetType(), typeof(TDialogWindowViewModel));
    }

    private void InitializePresenterViewModels<TPresenterViewModel>(TPresenterViewModel presenterViewModel, PresenterViewModelInitializerModel presenterViewModelInitializerModel)
        where TPresenterViewModel : PresenterViewModel
    {
        _mapper.Map(presenterViewModelInitializerModel, presenterViewModel,
                    presenterViewModelInitializerModel.GetType(), typeof(TPresenterViewModel));
    }

    private static void SetWindow<TDialogWindow, TDialogWindowViewModel,
                                  TPresenter, TPresenterViewModel>(TDialogWindow window, TDialogWindowViewModel windowViewModel,
                                                                   TPresenter presenter, TPresenterViewModel presenterViewModel)
        where TDialogWindow : Core.UserControls.DialogWindow
        where TDialogWindowViewModel : DialogWindowViewModel
        where TPresenter : Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        presenter.DataContext = presenterViewModel;
        windowViewModel.Presenter = presenter;
        window.DataContext = windowViewModel;
    }

    private static async Task OnBeforeLoadAsync<TDialogWindowViewModel,
                                                TPresenter, TPresenterViewModel>(TDialogWindowViewModel windowViewModel, TPresenter presenter, TPresenterViewModel presenterViewModel)
        where TDialogWindowViewModel : DialogWindowViewModel
        where TPresenter : Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        await presenterViewModel.OnBeforeLoadAsync();
        await presenter.OnBeforeLoadAsync();

        await windowViewModel.OnBeforeLoadAsync();
    }

    private static TDialogResult? GetDialogResult<TDialogWindow, TDialogResult>(TDialogWindow window)
        where TDialogWindow : Core.UserControls.DialogWindow
        where TDialogResult : DialogResult
    {
        return window.Result as TDialogResult;
    }

    public void SetDialogResult<TDialogWindow, TDialogResult>(string windowId, TDialogResult result)
        where TDialogWindow : Core.UserControls.DialogWindow
        where TDialogResult : DialogResult
    {
        TDialogWindow window = (TDialogWindow)_windowProvider.GetWindow(windowId);

        window.DialogResult = true;
        window.Result = result;
    }
}