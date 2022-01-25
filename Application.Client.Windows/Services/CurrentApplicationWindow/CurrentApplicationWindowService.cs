using System.Reflection;
using Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Interfaces;
using Application.Client.Windows.ApplicationWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow;

public class CurrentApplicationWindowService : ICurrentApplicationWindowService
{
    private readonly IServiceProvider _serviceProvider;

    private readonly IApplicationWindow _applicationWindow;

    public CurrentApplicationWindowService(IServiceProvider serviceProvider, IApplicationWindow applicationWindow)
    {
        _serviceProvider = serviceProvider;
        _applicationWindow = applicationWindow;
    }

    IApplicationWindow ICurrentApplicationWindowService.ApplicationWindow => _applicationWindow;

    public void ReInitializeWindowSettings(Func<IApplicationWindowSettingsViewModelInitializerModel> applicationWindowSettingsViewModelInitializerModelFactory)
    {
        IApplicationWindowViewModel applicationWindowViewModel = (IApplicationWindowViewModel)_applicationWindow.DataContext;
        IApplicationWindowSettingsViewModel applicationWindowSettingsViewModel = applicationWindowViewModel.WindowSettings;

        IApplicationWindowSettingsViewModelInitializerModel applicationWindowSettingsViewModelInitializerModel = applicationWindowSettingsViewModelInitializerModelFactory();

        Type applicationWindowSettingsViewModelType = applicationWindowSettingsViewModel.GetType();
        Type applicationWindowSettingsViewModelInitializerModelType = applicationWindowSettingsViewModelInitializerModel.GetType();

        Type applicationWindowSettingsViewModelInitializerType = typeof(IApplicationWindowViewModelInitializer<,>)
            .MakeGenericType(applicationWindowSettingsViewModelType, applicationWindowSettingsViewModelInitializerModelType);

        MethodInfo applicationWindowSettingsViewModelInitializerInitializeMethodInfo = applicationWindowSettingsViewModelInitializerType
            .GetMethods()
            .Single();

        object applicationWindowSettingsViewModelInitializer =
            _serviceProvider.GetRequiredService(applicationWindowSettingsViewModelInitializerType);

        applicationWindowSettingsViewModelInitializerInitializeMethodInfo
            .Invoke(applicationWindowSettingsViewModelInitializer, new object[] { applicationWindowSettingsViewModel, applicationWindowSettingsViewModelInitializerModel });
    }
}