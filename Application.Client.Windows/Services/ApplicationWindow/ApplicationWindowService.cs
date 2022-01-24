using System.Reflection;
using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow;

public class ApplicationWindowService : IApplicationWindowService
{
    private readonly IServiceProvider _serviceProvider;

    public ApplicationWindowService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ShowAsync(IApplicationWindowOptionsModel applicationWindowOptions)
    {
        IApplicationWindow applicationWindow = GetApplicationWindow(applicationWindowOptions.WindowType);

        InitializeApplicationWindow(applicationWindowOptions.WindowViewModelType, (IApplicationWindowViewModel)applicationWindow.DataContext,
            applicationWindowOptions.WindowViewModelInitializerModelType, applicationWindowOptions.WindowViewModelInitializerModel);

        applicationWindow.Show();

        await Task.CompletedTask;
    }

    private IApplicationWindow GetApplicationWindow(Type applicationWindowType)
    {
        return (IApplicationWindow)_serviceProvider.GetRequiredService(applicationWindowType);
    }

    private void InitializeApplicationWindow(Type applicationWindowViewModelType, IApplicationWindowViewModel applicationWindowViewModel,
        Type applicationWindowViewModelInitializerModelType, IApplicationWindowViewModelInitializerModel applicationWindowViewModelInitializerModel)
    {
        Type applicationWindowViewModelInitializerType = typeof(IApplicationWindowViewModelInitializer<,>)
            .MakeGenericType(applicationWindowViewModelType, applicationWindowViewModelInitializerModelType);

        MethodInfo applicationWindowViewModelInitializerInitializeMethodInfo = applicationWindowViewModelInitializerType
            .GetMethods()
            .Single();

        object applicationWindowViewModelInitializer =
            _serviceProvider.GetRequiredService(applicationWindowViewModelInitializerType);

        applicationWindowViewModelInitializerInitializeMethodInfo
            .Invoke(applicationWindowViewModelInitializer, new object[] { applicationWindowViewModel, applicationWindowViewModelInitializerModel });
    }
}