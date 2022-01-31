using System.Reflection;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Interfaces;
using Application.Client.Windows.DialogWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow;

public class CurrentDialogWindowService : ICurrentDialogWindowService
{
    private readonly IDialogWindow _dialogWindow;

    private readonly IServiceProvider _serviceProvider;


    public CurrentDialogWindowService(IServiceProvider serviceProvider, IDialogWindow dialogWindow)
    {
        _dialogWindow = dialogWindow;
        _serviceProvider = serviceProvider;
    }

    IDialogWindow ICurrentDialogWindowService.DialogWindow => _dialogWindow;

    public void ReInitializeWindowSettings(Func<IDialogWindowSettingsViewModelInitializerModel> dialogWindowSettingsViewModelInitializerModelFactory)
    {
        IDialogWindowViewModel dialogWindowViewModel = (IDialogWindowViewModel)_dialogWindow.DataContext;
        IDialogWindowSettingsViewModel dialogWindowSettingsViewModel = (IDialogWindowSettingsViewModel)dialogWindowViewModel.WindowSettings;

        IDialogWindowSettingsViewModelInitializerModel dialogWindowSettingsViewModelInitializerModel = dialogWindowSettingsViewModelInitializerModelFactory();

        Type dialogWindowSettingsViewModelType = dialogWindowSettingsViewModel.GetType();
        Type dialogWindowSettingsViewModelInitializerModelType = dialogWindowSettingsViewModelInitializerModel.GetType();

        Type dialogWindowSettingsViewModelInitializerType = typeof(IDialogWindowSettingsViewModelInitializer<,>)
            .MakeGenericType(dialogWindowSettingsViewModelType, dialogWindowSettingsViewModelInitializerModelType);

        MethodInfo dialogWindowSettingsViewModelInitializerInitializeMethodInfo = dialogWindowSettingsViewModelInitializerType
            .GetMethods()
            .Single();

        object dialogWindowSettingsViewModelInitializer =
            _serviceProvider.GetRequiredService(dialogWindowSettingsViewModelInitializerType);

        dialogWindowSettingsViewModelInitializerInitializeMethodInfo
            .Invoke(dialogWindowSettingsViewModelInitializer, new object[] { dialogWindowSettingsViewModel, dialogWindowSettingsViewModelInitializerModel });
    }
}