using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Guid.Interfaces;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Initializers.Models;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window.Initializers.Models;
using SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow;

public sealed class StandardWindowService : IStandardWindowService
{
    private readonly IServiceProvider _serviceProvider;


    private readonly IGuid _guid;

    private readonly IMapper _mapper;

    public StandardWindowService(IServiceProvider serviceProvider, IGuid guid, IMapper mapper)
    {
        _serviceProvider = serviceProvider;

        _guid = guid;
        _mapper = mapper;
    }

    public async Task ShowWindowAsync<TStandardWindow, TStandardWindowViewModel,
                                      TPresenter, TPresenterViewModel>(StandardWindowViewModelInitializerModel? windowViewModelInitializerModel = null,
                                                                       PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TStandardWindow : Core.UserControls.StandardWindow
        where TStandardWindowViewModel : StandardWindowViewModel
        where TPresenter : Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        TStandardWindow window = CreateWindow<TStandardWindow>();
        TStandardWindowViewModel windowViewModel = CreateWindowViewModel<TStandardWindow, TStandardWindowViewModel>(window);

        TPresenter presenter = CreatePresenter<TStandardWindow, TPresenter>(window);
        TPresenterViewModel presenterViewModel = CreatePresenterViewModel<TStandardWindow, TPresenterViewModel>(window);

        InitializeWindowViewModels(windowViewModel, windowViewModelInitializerModel);
        InitializePresenterViewModels(presenterViewModel, presenterViewModelInitializerModel);

        SetWindow(window, windowViewModel, presenter, presenterViewModel);

        await OnBeforeLoadAsync(windowViewModel, presenter, presenterViewModel);

        window.Show();
    }

    private TStandardWindow CreateWindow<TStandardWindow>()
        where TStandardWindow : Core.UserControls.StandardWindow
    {
        TStandardWindow window = (TStandardWindow)_serviceProvider.GetRequiredService(typeof(TStandardWindow));

        window.Id = _guid.NewGuid()
                         .ToString();

        return window;
    }

    private TStandardWindowViewModel CreateWindowViewModel<TStandardWindow, TStandardWindowViewModel>(TStandardWindow window)
        where TStandardWindow : Core.UserControls.StandardWindow
        where TStandardWindowViewModel : StandardWindowViewModel
    {
        TStandardWindowViewModel windowViewModel = (TStandardWindowViewModel)_serviceProvider.GetRequiredService(typeof(TStandardWindowViewModel));
        windowViewModel.Id = window.Id;

        return windowViewModel;
    }

    private TPresenter CreatePresenter<TStandardWindow, TPresenter>(TStandardWindow window)
        where TStandardWindow : Core.UserControls.StandardWindow
        where TPresenter : Presenter.Core.UserControls.Presenter.Presenter
    {
        TPresenter presenter = (TPresenter)_serviceProvider.GetRequiredService(typeof(TPresenter));
        presenter.WindowId = window.Id;

        return presenter;
    }

    private TPresenterViewModel CreatePresenterViewModel<TStandardWindow, TPresenterViewModel>(TStandardWindow window)
        where TStandardWindow : Core.UserControls.StandardWindow
        where TPresenterViewModel : PresenterViewModel
    {
        TPresenterViewModel presenterViewModel = (TPresenterViewModel)_serviceProvider.GetRequiredService(typeof(TPresenterViewModel));
        presenterViewModel.WindowId = window.Id;

        return presenterViewModel;
    }

    private void InitializeWindowViewModels<TStandardWindowViewModel>(TStandardWindowViewModel windowViewModel, StandardWindowViewModelInitializerModel? windowViewModelInitializerModel = null)
        where TStandardWindowViewModel : StandardWindowViewModel
    {
        if (windowViewModelInitializerModel is not null)
        {
            _mapper.Map(windowViewModelInitializerModel, windowViewModel,
                        windowViewModelInitializerModel.GetType(), typeof(TStandardWindowViewModel));
        }
    }

    private void InitializePresenterViewModels<TPresenterViewModel>(TPresenterViewModel presenterViewModel, PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TPresenterViewModel : PresenterViewModel
    {
        if (presenterViewModelInitializerModel is not null)
        {
            _mapper.Map(presenterViewModelInitializerModel, presenterViewModel,
                        presenterViewModelInitializerModel.GetType(), typeof(TPresenterViewModel));
        }
    }

    private static void SetWindow<TStandardWindow, TStandardWindowViewModel,
                                  TPresenter, TPresenterViewModel>(TStandardWindow window, TStandardWindowViewModel windowViewModel,
                                                                   TPresenter presenter, TPresenterViewModel presenterViewModel)
        where TStandardWindow : Core.UserControls.StandardWindow
        where TStandardWindowViewModel : StandardWindowViewModel
        where TPresenter : Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        presenter.DataContext = presenterViewModel;
        windowViewModel.Presenter = presenter;
        window.DataContext = windowViewModel;
    }

    private static async Task OnBeforeLoadAsync<TStandardWindowViewModel,
                                                TPresenter, TPresenterViewModel>(TStandardWindowViewModel windowViewModel, TPresenter presenter, TPresenterViewModel presenterViewModel)
        where TStandardWindowViewModel : StandardWindowViewModel
        where TPresenter : Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        await presenterViewModel.OnBeforeLoadAsync();
        await presenter.OnBeforeLoadAsync();

        await windowViewModel.OnBeforeLoadAsync();
    }
}