using System.Reflection;
using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window.Initializer.Models.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window.Interfaces;
using Application.Client.Windows.Core.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Core.Services.WindowService.Abstractions;

public abstract class WindowService
{
    protected readonly IServiceProvider ServiceProvider;

    protected readonly IContentPresenterService ContentPresenterService;

    protected WindowService(IServiceProvider serviceProvider, IContentPresenterService contentPresenterService)
    {
        ServiceProvider = serviceProvider;
        ContentPresenterService = contentPresenterService;
    }

    protected virtual IWindow CreateWindow(Type windowType)
    {
        return (IWindow)ServiceProvider.GetRequiredService(windowType);
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

    protected virtual void InitializeWindowViewModel(IWindowViewModel windowViewModel, IWindowViewModelInitializerModel windowViewModelInitializerModel)
    {
        Type windowViewModelType = windowViewModel.GetType();
        Type windowViewModelInitializerModelType = windowViewModelInitializerModel.GetType();

        Type windowViewModelInitializerType = WindowViewModelInitializerGenericType.MakeGenericType(windowViewModelType, windowViewModelInitializerModelType);

        MethodInfo windowViewModelInitializerInitializeMethodInfo = windowViewModelInitializerType
            .GetInterfaces()
            .Single()
            .GetMethods()
            .Single();

        object windowViewModelInitializer = ServiceProvider.GetRequiredService(windowViewModelInitializerType);

        windowViewModelInitializerInitializeMethodInfo
            .Invoke(windowViewModelInitializer, new object[] { windowViewModel, windowViewModelInitializerModel });
    }

    protected virtual void LoadContentPresenter(IContentPresenterLoadOptions contentPresenterLoadOptions, ICurrentWindowService currentWindowService, IWindowViewModel windowViewModel)
    {
        IContentPresenterViewModel contentPresenterViewModel = 
            ContentPresenterService.GetContentPresenterViewModel(contentPresenterLoadOptions.ContentPresenterViewModelType, currentWindowService);

        if (contentPresenterLoadOptions.HasInitializeData)
        {
            ContentPresenterService.InitializeContentPresenterViewModel(contentPresenterViewModel, contentPresenterLoadOptions.ContentPresenterViewModelInitializerModel!);
        }

        windowViewModel.ContentPresenter = contentPresenterViewModel;
    }
    
    protected abstract Type CurrentWindowServiceType { get; }

    protected abstract Type WindowViewModelInitializerGenericType { get; }
}