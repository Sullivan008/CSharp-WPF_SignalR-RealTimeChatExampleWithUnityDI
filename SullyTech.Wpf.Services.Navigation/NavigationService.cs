using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Controls.Window.Core.Providers.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Services.Navigation.Interfaces;
using SullyTech.Wpf.Services.Navigation.Models.MethodParameters.NavigateToOptions.Interfaces;

namespace SullyTech.Wpf.Services.Navigation;

public sealed class NavigationService : INavigationService
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

    public async Task NavigateToAsync(string windowId, INavigateToOptions navigateToOptions)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId, nameof(windowId));
        Guard.Guard.ThrowIfNull(navigateToOptions, nameof(navigateToOptions));

        IWindow window = await _windowProvider.GetWindowAsync(windowId);

        switch (window)
        {
            case IStandardWindow standardWindow:
                {
                    await NavigateToAsync(standardWindow, navigateToOptions);
                    break;
                }
            case IDialogWindow dialogWindow:
                {
                    await NavigateToAsync(dialogWindow, navigateToOptions);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(NavigateToAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task NavigateToAsync(IWindow window, INavigateToOptions navigateToOptions)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));
        Guard.Guard.ThrowIfNull(navigateToOptions, nameof(navigateToOptions));

        switch (window)
        {
            case IStandardWindow standardWindow:
                {
                    await NavigateToAsync(standardWindow, navigateToOptions);
                    break;
                }
            case IDialogWindow dialogWindow:
                {
                    await NavigateToAsync(dialogWindow, navigateToOptions);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(NavigateToAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task NavigateToAsync(IStandardWindow window, INavigateToOptions navigateToOptions)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));
        Guard.Guard.ThrowIfNull(navigateToOptions, nameof(navigateToOptions));

        await ((IPresenterViewModel)((IStandardWindowViewModel)window.DataContext).Presenter.DataContext).Data.OnDestroyAsync();
        await ((IPresenterViewModel)((IStandardWindowViewModel)window.DataContext).Presenter.DataContext).OnDestroyAsync();

        IPresenter presenter = CreatePresenter(window, navigateToOptions.PresenterType);
        IPresenterViewModel presenterViewModel = CreatePresenterViewModel(window, navigateToOptions.PresenterViewModelType);

        InitializePresenterViewModels(presenterViewModel, navigateToOptions);

        await OnBeforeLoadAsync(presenter, presenterViewModel);

        SetPresenter((IWindowViewModel)window.DataContext, presenter, presenterViewModel);
    }

    public async Task NavigateToAsync(IDialogWindow window, INavigateToOptions navigateToOptions)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));
        Guard.Guard.ThrowIfNull(navigateToOptions, nameof(navigateToOptions));

        await ((IPresenterViewModel)((IDialogWindowViewModel)window.DataContext).Presenter.DataContext).Data.OnDestroyAsync();
        await ((IPresenterViewModel)((IDialogWindowViewModel)window.DataContext).Presenter.DataContext).OnDestroyAsync();

        IPresenter presenter = CreatePresenter(window, navigateToOptions.PresenterType);
        IPresenterViewModel presenterViewModel = CreatePresenterViewModel(window, navigateToOptions.PresenterViewModelType);

        InitializePresenterViewModels(presenterViewModel, navigateToOptions);

        await OnBeforeLoadAsync(presenter, presenterViewModel);

        SetPresenter((IWindowViewModel)window.DataContext, presenter, presenterViewModel);
    }

    private IPresenter CreatePresenter(IWindow window, Type presenterType)
    {
        IPresenter presenter = (IPresenter)_serviceProvider.GetRequiredService(presenterType);
        presenter.WindowId = window.Id;

        return presenter;
    }

    private IPresenterViewModel CreatePresenterViewModel(IWindow window, Type presenterViewModelType)
    {
        IPresenterViewModel presenterViewModel = (IPresenterViewModel)_serviceProvider.GetRequiredService(presenterViewModelType);
        presenterViewModel.WindowId = window.Id;

        return presenterViewModel;
    }

    private void InitializePresenterViewModels(IPresenterViewModel presenterViewModel, INavigateToOptions navigateToOptions)
    {
        InitializePresenterViewModel(presenterViewModel, navigateToOptions.PresenterViewModelType,
            navigateToOptions.PresenterViewModelInitializerModel, navigateToOptions.PresenterViewModelInitializerModelType);

        InitializePresenterDataViewModel(presenterViewModel.Data, navigateToOptions.PresenterDataViewModelType,
            navigateToOptions.PresenterDataViewModelInitializerModel, navigateToOptions.PresenterDataViewModelInitializerModelType);
    }

    private void InitializePresenterViewModel(IPresenterViewModel presenterViewModel, Type presenterViewModelType,
        IPresenterViewModelInitializerModel? presenterViewModelInitializerModel, Type? presenterViewModelInitializerModelType)
    {
        if (presenterViewModelInitializerModel is not null && presenterViewModelInitializerModelType is not null)
        {
            _mapper.Map(presenterViewModelInitializerModel, presenterViewModel,
                presenterViewModelInitializerModelType, presenterViewModelType);
        }
    }

    private void InitializePresenterDataViewModel(IPresenterDataViewModel presenterDataViewModel, Type presenterDataViewModelType,
        IPresenterDataViewModelInitializerModel? presenterDataViewModelInitializerModel, Type? presenterDataViewModelInitializerModelType)
    {
        if (presenterDataViewModelInitializerModel is not null && presenterDataViewModelInitializerModelType is not null)
        {
            _mapper.Map(presenterDataViewModelInitializerModel, presenterDataViewModel,
                presenterDataViewModelInitializerModelType, presenterDataViewModelType);
        }
    }

    private static async Task OnBeforeLoadAsync(IPresenter presenter, IPresenterViewModel presenterViewModel)
    {
        await presenterViewModel.Data.OnBeforeLoadAsync();
        await presenterViewModel.OnBeforeLoadAsync();
        await presenter.OnBeforeLoadAsync();
    }

    private static void SetPresenter(IWindowViewModel windowViewModel, IPresenter presenter, IPresenterViewModel presenterViewModel)
    {
        SetPresenterDataContext(presenter, presenterViewModel);
        SetWindowPresenter(windowViewModel, presenter);
    }

    private static void SetPresenterDataContext(IPresenter presenter, IPresenterViewModel presenterViewModel)
    {
        presenter.DataContext = presenterViewModel;
    }

    private static void SetWindowPresenter(IWindowViewModel windowViewModel, IPresenter presenter)
    {
        windowViewModel.Presenter = presenter;
    }
}