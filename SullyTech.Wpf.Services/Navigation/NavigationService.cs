using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Initializers.Models;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Standard.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window;
using SullyTech.Wpf.Providers.Window.Interfaces;
using SullyTech.Wpf.Services.Navigation.Interfaces;

namespace SullyTech.Wpf.Services.Navigation;

internal sealed class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;


    private readonly IMapper _mapper;

    private readonly IWindowProvider _windowProvider;

    public NavigationService(IServiceProvider serviceProvider, IMapper mapper, IWindowProvider windowProvider)
    {
        _serviceProvider = serviceProvider;

        _mapper = mapper;
        _windowProvider = windowProvider;
    }

    public async Task NavigateToAsync<TPresenter, TPresenterViewModel>(string windowId, PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TPresenter : Controls.Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId);

        Controls.Window.Core.UserControls.Window window = _windowProvider.GetWindow(windowId);

        switch (window)
        {
            case StandardWindow standardWindow:
                {
                    await NavigateToAsync<TPresenter, TPresenterViewModel>(standardWindow, presenterViewModelInitializerModel);
                    break;
                }
            case DialogWindow dialogWindow:
                {
                    await NavigateToAsync<TPresenter, TPresenterViewModel>(dialogWindow, presenterViewModelInitializerModel);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(NavigateToAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task NavigateToAsync<TPresenter, TPresenterViewModel>(Controls.Window.Core.UserControls.Window window, PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TPresenter : Controls.Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        Guard.Guard.ThrowIfNull(window);

        switch (window)
        {
            case StandardWindow standardWindow:
            {
                await NavigateToAsync<TPresenter, TPresenterViewModel>(standardWindow, presenterViewModelInitializerModel);
                break;
            }
            case DialogWindow dialogWindow:
            {
                await NavigateToAsync<TPresenter, TPresenterViewModel>(dialogWindow, presenterViewModelInitializerModel);
                break;
            }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(NavigateToAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task NavigateToAsync<TPresenter, TPresenterViewModel>(StandardWindow window, PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TPresenter : Controls.Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        Guard.Guard.ThrowIfNull(window);

        await ((PresenterViewModel)((StandardWindowViewModel)window.DataContext).Presenter.DataContext).OnDestroyAsync();

        TPresenter presenter = CreatePresenter<TPresenter>(window);
        TPresenterViewModel presenterViewModel = CreatePresenterViewModel<TPresenterViewModel>(window);

        if (presenterViewModelInitializerModel is not null)
        {
            InitializePresenterViewModel(presenterViewModel, presenterViewModelInitializerModel);
        }

        await OnBeforeLoadAsync(presenter, presenterViewModel);

        SetPresenter((WindowViewModel)window.DataContext, presenter, presenterViewModel);
    }

    public async Task NavigateToAsync<TPresenter, TPresenterViewModel>(DialogWindow window, PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TPresenter : Controls.Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        Guard.Guard.ThrowIfNull(window);

        await ((PresenterViewModel)((DialogWindowViewModel)window.DataContext).Presenter.DataContext).OnDestroyAsync();

        TPresenter presenter = CreatePresenter<TPresenter>(window);
        TPresenterViewModel presenterViewModel = CreatePresenterViewModel<TPresenterViewModel>(window);

        if (presenterViewModelInitializerModel is not null)
        {
            InitializePresenterViewModel(presenterViewModel, presenterViewModelInitializerModel);
        }

        await OnBeforeLoadAsync(presenter, presenterViewModel);

        SetPresenter((WindowViewModel)window.DataContext, presenter, presenterViewModel);
    }

    private TPresenter CreatePresenter<TPresenter>(Controls.Window.Core.UserControls.Window window)
        where TPresenter : Controls.Presenter.Core.UserControls.Presenter.Presenter
    {
        TPresenter presenter = (TPresenter)_serviceProvider.GetRequiredService(typeof(TPresenter));
        presenter.WindowId = window.Id;

        return presenter;
    }

    private TPresenterViewModel CreatePresenterViewModel<TPresenterViewModel>(Controls.Window.Core.UserControls.Window window)
        where TPresenterViewModel : PresenterViewModel
    {
        TPresenterViewModel presenterViewModel = (TPresenterViewModel)_serviceProvider.GetRequiredService(typeof(TPresenterViewModel));
        presenterViewModel.WindowId = window.Id;

        return presenterViewModel;
    }

    private void InitializePresenterViewModel<TPresenterViewModel>(TPresenterViewModel presenterViewModel, PresenterViewModelInitializerModel presenterViewModelInitializerModel)
        where TPresenterViewModel : PresenterViewModel
    {
        _mapper.Map(presenterViewModelInitializerModel, presenterViewModel,
            presenterViewModelInitializerModel.GetType(), typeof(TPresenterViewModel));
    }

    private static async Task OnBeforeLoadAsync<TPresenter, TPresenterViewModel>(TPresenter presenter, TPresenterViewModel presenterViewModel)
        where TPresenter : Controls.Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        await presenterViewModel.OnBeforeLoadAsync();
        await presenter.OnBeforeLoadAsync();
    }

    private static void SetPresenter<TPresenter, TPresenterViewModel>(WindowViewModel windowViewModel, TPresenter presenter, TPresenterViewModel presenterViewModel)
        where TPresenter : Controls.Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel
    {
        presenter.DataContext = presenterViewModel;
        windowViewModel.Presenter = presenter;
    }
}