﻿using System.Reflection;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Window.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.Presenter.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.PresenterData.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions;

public abstract class WindowService : IWindowService
{
    protected readonly IServiceProvider ServiceProvider;

    protected WindowService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public virtual async Task CloseWindowAsync(IWindow window)
    {
        await OnDestroyPresenterDataViewModel(((IWindowViewModel)window.DataContext).Presenter.Data);
        await OnDestroyPresenterViewModel(((IWindowViewModel)window.DataContext).Presenter);

        await OnDestroyWindowSettingsViewModel(((IWindowViewModel)window.DataContext).Settings);
        await OnDestroyWindowViewModel((IWindowViewModel)window.DataContext);

        window.Close();
        
        await Task.CompletedTask;
    }

    public virtual async Task SetWindowWidthAsync(IWindow window, double width)
    {
        ((IWindowViewModel)window.DataContext).Settings.Width = width;

        await Task.CompletedTask;
    }

    public virtual async Task SetWindowHeightAsync(IWindow window, double height)
    {
        ((IWindowViewModel)window.DataContext).Settings.Height = height;

        await Task.CompletedTask;
    }

    public virtual async Task<IWindow> GetWindowAsync(string windowId)
    {
        IWindow result = Application.Current.Windows.OfType<IWindow>()
                                                    .Single(x => x.Id == windowId);

        return await Task.FromResult(result);
    }

    protected virtual IWindow CreateWindow(Type windowType)
    {
        return (IWindow)ServiceProvider.GetRequiredService(windowType);
    }

    protected virtual IWindowViewModel CreateWindowViewModel(IWindow window, Type windowViewModelType)
    {
        IWindowViewModel windowViewModel = (IWindowViewModel)ServiceProvider.GetRequiredService(windowViewModelType);
        windowViewModel.PresenterWindowId = window.Id;

        return windowViewModel;
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

    protected virtual IPresenterViewModel CreatePresenterViewModel(IWindow window, Type presenterViewModelType)
    {
        IPresenterViewModel presenterViewModel = (IPresenterViewModel)ServiceProvider.GetRequiredService(presenterViewModelType);
        presenterViewModel.PresenterWindowId = window.Id;

        return presenterViewModel;
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

    protected virtual async Task OnInitWindowViewModel(IWindowViewModel windowViewModel)
    {
        await windowViewModel.OnInitAsync();
    }

    protected virtual async Task OnInitWindowSettingsViewModel(IWindowSettingsViewModel windowSettingsViewModel)
    {
        await windowSettingsViewModel.OnInitAsync();
    }

    protected virtual async Task OnInitPresenterViewModel(IPresenterViewModel presenterViewModel)
    {
        await presenterViewModel.OnInitAsync();
    }

    protected virtual async Task OnInitPresenterDataViewModel(IPresenterDataViewModel presenterDataViewModel)
    {
        await presenterDataViewModel.OnInitAsync();
    }

    protected virtual async Task OnDestroyWindowViewModel(IWindowViewModel windowViewModel)
    {
        await windowViewModel.OnDestroyAsync();
    }

    protected virtual async Task OnDestroyWindowSettingsViewModel(IWindowSettingsViewModel windowSettingsViewModel)
    {
        await windowSettingsViewModel.OnDestroyAsync();
    }

    protected virtual async Task OnDestroyPresenterViewModel(IPresenterViewModel presenterViewModel)
    {
        await presenterViewModel.OnDestroyAsync();
    }

    protected virtual async Task OnDestroyPresenterDataViewModel(IPresenterDataViewModel presenterDataViewModel)
    {
        await presenterDataViewModel.OnDestroyAsync();
    }

    protected virtual void SetWindowPresenter(IWindowViewModel windowViewModel, IPresenterViewModel presenterViewModel)
    {
        windowViewModel.Presenter = presenterViewModel;
    }

    protected virtual void SetWindowDataContext(IWindow window, IWindowViewModel windowViewModel)
    {
        window.DataContext = windowViewModel;
    }

    protected abstract Type WindowViewModelInitializerGenericType { get; }

    protected abstract Type WindowSettingsViewModelInitializerGenericType { get; }
}