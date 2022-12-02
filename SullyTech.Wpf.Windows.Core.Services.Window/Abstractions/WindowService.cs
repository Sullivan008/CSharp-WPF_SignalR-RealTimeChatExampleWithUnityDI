using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Services.CurrentWindow.Interfaces;
using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Windows.Core.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Core.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Core.Services.Window.Abstractions;

public abstract class WindowService
{
    protected readonly IServiceProvider ServiceProvider;

    protected WindowService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    protected virtual IWindow CreateWindow(Type windowType)
    {
        return (IWindow)ServiceProvider.GetRequiredService(windowType);
    }

    protected virtual IWindowViewModel CreateWindowViewModel(Type windowViewModelTtype)
    {
        return (IWindowViewModel)ServiceProvider.GetRequiredService(windowViewModelTtype);
    }
    
    protected virtual void InitializeWindowViewModel(IWindowViewModel windowViewModel, IWindowViewModelInitializerModel? windowViewModelInitializerModel)
    {
        if (windowViewModelInitializerModel is not null)
        {
            Type windowViewModelType = windowViewModel.GetType();
            Type windowViewModelInitializerModelType = windowViewModelInitializerModel.GetType();

            Type windowViewModelInitializerType =
                WindowViewModelInitializerGenericType.MakeGenericType(windowViewModelType, windowViewModelInitializerModelType);

            MethodInfo windowViewModelInitializerInitializeMethodInfo = windowViewModelInitializerType.GetInterfaces()
                                                                                                      .Single()
                                                                                                      .GetMethods()
                                                                                                      .Single();

            object windowViewModelInitializer = ServiceProvider.GetRequiredService(windowViewModelInitializerType);

            windowViewModelInitializerInitializeMethodInfo
                .Invoke(windowViewModelInitializer, new object[] { windowViewModel, windowViewModelInitializerModel });
        }
    }

    protected virtual void InitializeWindowSettingsViewModel(IWindowSettingsViewModel windowSettingsViewModel, IWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel)
    {
        if (windowSettingsViewModelInitializerModel is not null)
        {
            Type windowSettingsViewModelType = windowSettingsViewModel.GetType();
            Type windowSettingsViewModelInitializerModelType = windowSettingsViewModelInitializerModel.GetType();

            Type windowSettingsViewModelInitializerType =
                WindowSettingsViewModelInitializerGenericType.MakeGenericType(windowSettingsViewModelType, windowSettingsViewModelInitializerModelType);

            MethodInfo windowSettingsViewModelInitializerInitializeMethodInfo = windowSettingsViewModelInitializerType.GetInterfaces()
                                                                                                                      .Single()
                                                                                                                      .GetMethods()
                                                                                                                      .Single();

            object windowSettingsViewModelInitializer = ServiceProvider.GetRequiredService(windowSettingsViewModelInitializerType);

            windowSettingsViewModelInitializerInitializeMethodInfo
                .Invoke(windowSettingsViewModelInitializer, new object[] { windowSettingsViewModel, windowSettingsViewModelInitializerModel });
        }
    }

    protected virtual ICurrentWindowService CreateCurrentWindowService(IWindow window)
    {
        Type windowType = window.GetType();
        Type currentWindowServiceFactoryType = typeof(Func<,>).MakeGenericType(windowType, CurrentWindowServiceType);

        MethodInfo currentWindowServiceFactoryInvokeMethodInfo = currentWindowServiceFactoryType
            .GetMethods()
            .Single(x => x.Name == nameof(MethodInfo.Invoke));

        object currentWindowServiceFactory = ServiceProvider.GetRequiredService(currentWindowServiceFactoryType);

        return (ICurrentWindowService)currentWindowServiceFactoryInvokeMethodInfo.Invoke(currentWindowServiceFactory, new object[] { window })!;
    }

    protected virtual IPresenterViewModel CreatePresenterViewModel(Type presenterViewModelType, ICurrentWindowService currentWindowService)
    {
        Type presenterViewModelFactoryType =
            typeof(Func<,,>).MakeGenericType(typeof(IPresenterDataViewModel), typeof(ICurrentWindowService), presenterViewModelType);

        Func<IPresenterDataViewModel, ICurrentWindowService, IPresenterViewModel> presenterViewModelFactory =
            (Func<IPresenterDataViewModel, ICurrentWindowService, IPresenterViewModel>)ServiceProvider.GetRequiredService(presenterViewModelFactoryType);

        IPresenterDataViewModel presenterViewDataViewModel = CreatePresenterDataViewModel(presenterViewModelType);
        IPresenterViewModel presenterViewModel = presenterViewModelFactory(presenterViewDataViewModel, currentWindowService);

        return presenterViewModel;
    }

    protected virtual IPresenterDataViewModel CreatePresenterDataViewModel(Type presenterViewModelType)
    {
        Type presenterDataViewModelType = presenterViewModelType.BaseType!.GenericTypeArguments.Single();

        return (IPresenterDataViewModel)ServiceProvider.GetRequiredService(presenterDataViewModelType);
    }

    protected virtual void InitializePresenterViewModel(IPresenterViewModel presenterViewModel, IPresenterViewModelInitializerModel? presenterViewModelInitializerModel)
    {
        if (presenterViewModelInitializerModel is not null)
        {
            Type presenterViewModelType = presenterViewModel.GetType();
            Type presenterViewModelInitializerModelType = presenterViewModelInitializerModel.GetType();

            Type presenterViewModelInitializerType =
                typeof(IPresenterViewModelInitializer<,>).MakeGenericType(presenterViewModelType, presenterViewModelInitializerModelType);

            MethodInfo presenterViewModelInitializerInitializeMethodInfo = presenterViewModelInitializerType.GetMethods()
            .Single();

            object presenterViewModelInitializer = ServiceProvider.GetRequiredService(presenterViewModelInitializerType);

            presenterViewModelInitializerInitializeMethodInfo
                .Invoke(presenterViewModelInitializer, new object[] { presenterViewModel, presenterViewModelInitializerModel });
        }
    }

    protected virtual void InitializePresenterDataViewModel(IPresenterDataViewModel presenterDataViewModel, IPresenterDataViewModelInitializerModel? presenterDataViewModelInitializerModel)
    {
        if (presenterDataViewModelInitializerModel is not null)
        {
            Type presenterDataViewModelType = presenterDataViewModel.GetType();
            Type presenterDataViewModelInitializerModelType = presenterDataViewModelInitializerModel.GetType();

            Type presenterDataViewModelInitializerType =
                typeof(IPresenterDataViewModelInitializer<,>).MakeGenericType(presenterDataViewModelType, presenterDataViewModelInitializerModelType);

            MethodInfo presenterDataViewModelInitializerInitializeMethodInfo = presenterDataViewModelInitializerType.GetMethods()
                                                                                                                    .Single();

            object presenterDataViewModelInitializer = ServiceProvider.GetRequiredService(presenterDataViewModelInitializerType);
            presenterDataViewModelInitializerInitializeMethodInfo
                .Invoke(presenterDataViewModelInitializer, new object[] { presenterDataViewModel, presenterDataViewModelInitializerModel });
        }
    }

    protected virtual void SetWindowPresenter(IWindowViewModel windowViewModel, IPresenterViewModel presenterViewModel)
    {
        windowViewModel.Presenter = presenterViewModel;
    }

    protected virtual void SetWindowDataContext(IWindow window, IWindowViewModel windowViewModel)
    {
        window.DataContext = windowViewModel;
    }

    protected abstract Type CurrentWindowServiceType { get; }

    protected abstract Type WindowViewModelInitializerGenericType { get; }

    protected abstract Type WindowSettingsViewModelInitializerGenericType { get; }
}