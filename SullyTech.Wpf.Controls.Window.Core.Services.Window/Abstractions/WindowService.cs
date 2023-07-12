using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions;

public abstract class WindowService : IWindowService
{
    protected readonly IServiceProvider ServiceProvider;

    protected WindowService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    protected abstract Type WindowViewModelInitializerGenericType { get; }

    protected abstract Type WindowSettingsViewModelInitializerGenericType { get; }

    protected virtual IWindow CreateWindow(Type windowType)
    {
        return (IWindow)ServiceProvider.GetRequiredService(windowType);
    }

    protected virtual IWindowViewModel CreateWindowViewModel(IWindow window, Type windowViewModelType)
    {
        IWindowViewModel windowViewModel = (IWindowViewModel)ServiceProvider.GetRequiredService(windowViewModelType);
        windowViewModel.WindowId = window.Id;

        return windowViewModel;
    }

    protected virtual IPresenter CreatePresenter(IWindow window, Type presenterType)
    {
        IPresenter presenter = (IPresenter)ServiceProvider.GetRequiredService(presenterType);
        presenter.WindowId = window.Id;

        return presenter;
    }

    protected virtual IPresenterViewModel CreatePresenterViewModel(IWindow window, Type presenterViewModelType)
    {
        IPresenterViewModel presenterViewModel = (IPresenterViewModel)ServiceProvider.GetRequiredService(presenterViewModelType);
        presenterViewModel.WindowId = window.Id;

        return presenterViewModel;
    }

    protected virtual void InitializeWindowViewModel(IWindowViewModel windowViewModel, Type windowViewModelType,
        IWindowViewModelInitializerModel? windowViewModelInitializerModel, Type? windowViewModelInitializerModelType)
    {
        if (windowViewModelInitializerModel is not null && windowViewModelInitializerModelType is not null)
        {
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

    protected virtual void InitializeWindowSettingsViewModel(IWindowSettingsViewModel windowSettingsViewModel, Type windowSettingsViewModelType,
        IWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel, Type? windowSettingsViewModelInitializerModelType)
    {
        if (windowSettingsViewModelInitializerModel is not null && windowSettingsViewModelInitializerModelType is not null)
        {
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

    protected virtual void InitializePresenterViewModel(IPresenterViewModel presenterViewModel, Type presenterViewModelType,
        IPresenterViewModelInitializerModel? presenterViewModelInitializerModel, Type? presenterViewModelInitializerModelType)
    {
        if (presenterViewModelInitializerModel is not null && presenterViewModelInitializerModelType is not null)
        {
            Type presenterViewModelInitializerType =
                typeof(IPresenterViewModelInitializer<,>).MakeGenericType(presenterViewModelType, presenterViewModelInitializerModelType);

            MethodInfo presenterViewModelInitializerInitializeMethodInfo = presenterViewModelInitializerType.GetMethods()
                                                                                                            .Single();

            object presenterViewModelInitializer = ServiceProvider.GetRequiredService(presenterViewModelInitializerType);

            presenterViewModelInitializerInitializeMethodInfo
                .Invoke(presenterViewModelInitializer, new object[] { presenterViewModel, presenterViewModelInitializerModel });
        }
    }

    protected virtual void InitializePresenterDataViewModel(IPresenterDataViewModel presenterDataViewModel, Type presenterDataViewModelType,
        IPresenterDataViewModelInitializerModel? presenterDataViewModelInitializerModel, Type? presenterDataViewModelInitializerModelType)
    {
        if (presenterDataViewModelInitializerModel is not null && presenterDataViewModelInitializerModelType is not null)
        {
            Type presenterDataViewModelInitializerType =
                typeof(IPresenterDataViewModelInitializer<,>).MakeGenericType(presenterDataViewModelType, presenterDataViewModelInitializerModelType);

            MethodInfo presenterDataViewModelInitializerInitializeMethodInfo = presenterDataViewModelInitializerType.GetMethods()
                                                                                                                    .Single();

            object presenterDataViewModelInitializer = ServiceProvider.GetRequiredService(presenterDataViewModelInitializerType);

            presenterDataViewModelInitializerInitializeMethodInfo
                .Invoke(presenterDataViewModelInitializer, new object[] { presenterDataViewModel, presenterDataViewModelInitializerModel });
        }
    }

    protected virtual void SetPresenterDataContext(IPresenter presenter, IPresenterViewModel presenterViewModel)
    {
        presenter.DataContext = presenterViewModel;
    }

    protected virtual void SetWindowPresenter(IWindowViewModel windowViewModel, IPresenter presenter)
    {
        windowViewModel.Presenter = presenter;
    }

    protected virtual void SetWindowDataContext(IWindow window, IWindowViewModel windowViewModel)
    {
        window.DataContext = windowViewModel;
    }
}