using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Services.CurrentWindow.Abstractions;
using SullyTech.Wpf.Windows.Core.Services.CurrentWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.MethodParameters.NavigateToOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindow;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow;

public sealed class CurrentNavigationWindowService : CurrentWindowService, ICurrentNavigationWindowService
{
    private readonly IServiceProvider _serviceProvider;

    public CurrentNavigationWindowService(INavigationWindow window, IServiceProvider serviceProvider) : base(window)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task NavigateToAsync(INavigateToOptions navigateToOptions)
    {
        IPresenterViewModel presenterViewModel =
            CreatePresenterViewModel(navigateToOptions.PresenterViewModelType, this);

        InitializePresenterViewModel(presenterViewModel, navigateToOptions.PresenterViewModelInitializerModel);
        InitializePresenterDataViewModel(presenterViewModel.Data, navigateToOptions.PresenterDataViewModelInitializerModel);

        SetPresenter((INavigationWindowViewModel)Window.DataContext, presenterViewModel);

        await Task.CompletedTask;
    }

    private IPresenterViewModel CreatePresenterViewModel(Type presenterViewModelType, ICurrentNavigationWindowService currentWindowService)
    {
        Type presenterViewModelFactoryType =
            typeof(Func<,,>).MakeGenericType(typeof(IPresenterDataViewModel), typeof(ICurrentWindowService), presenterViewModelType);

        Func<IPresenterDataViewModel, ICurrentWindowService, IPresenterViewModel> presenterViewModelFactory =
            (Func<IPresenterDataViewModel, ICurrentWindowService, IPresenterViewModel>)_serviceProvider.GetRequiredService(presenterViewModelFactoryType);

        IPresenterDataViewModel presenterDataViewModel = CreatePresenterDataViewModel(presenterViewModelType);

        return presenterViewModelFactory(presenterDataViewModel, currentWindowService);
    }

    private IPresenterDataViewModel CreatePresenterDataViewModel(Type presenterViewModelType)
    {
        Type presenterDataViewModelType = presenterViewModelType.BaseType!.GenericTypeArguments.Single();

        return (IPresenterDataViewModel)_serviceProvider.GetRequiredService(presenterDataViewModelType);
    }

    private void InitializePresenterViewModel(IPresenterViewModel presenterViewModel, IPresenterViewModelInitializerModel? presenterViewModelInitializerModel)
    {
        if (presenterViewModelInitializerModel is not null)
        {
            Type presenterViewModelType = presenterViewModel.GetType();
            Type presenterViewModelInitializerModelType = presenterViewModelInitializerModel.GetType();

            Type presenterViewModelInitializerType =
                typeof(IPresenterViewModelInitializer<,>).MakeGenericType(presenterViewModelType, presenterViewModelInitializerModelType);

            MethodInfo presenterViewModelInitializerInitializeMethodInfo = presenterViewModelInitializerType.GetMethods()
                                                                                                            .Single();

            object contentPresenterViewModelInitializer = _serviceProvider.GetRequiredService(presenterViewModelInitializerType);

            presenterViewModelInitializerInitializeMethodInfo
                .Invoke(contentPresenterViewModelInitializer, new object[] { presenterViewModel, presenterViewModelInitializerModel });
        }
    }

    private void InitializePresenterDataViewModel(IPresenterDataViewModel presenterDataViewModel, IPresenterDataViewModelInitializerModel? presenterDataViewModelInitializerModel)
    {
        if (presenterDataViewModelInitializerModel is not null)
        {
            Type presenterDataViewModelType = presenterDataViewModel.GetType();
            Type presenterDataViewModelInitializerModelType = presenterDataViewModelInitializerModel.GetType();

            Type presenterDataViewModelInitializerType =
                typeof(IPresenterDataViewModelInitializer<,>).MakeGenericType(presenterDataViewModelType, presenterDataViewModelInitializerModelType);

            MethodInfo presenterDataViewModelInitializerInitializeMethodInfo = presenterDataViewModelInitializerType.GetMethods()
                                                                                                                    .Single();

            object presenterDataViewModelInitializer = _serviceProvider.GetRequiredService(presenterDataViewModelInitializerType);

            presenterDataViewModelInitializerInitializeMethodInfo
                .Invoke(presenterDataViewModelInitializer, new object[] { presenterDataViewModel, presenterDataViewModelInitializerModel });
        }
    }

    private static void SetPresenter(INavigationWindowViewModel windowViewModel, IPresenterViewModel presenterViewModel)
    {
        windowViewModel.Presenter = presenterViewModel;
    }
}