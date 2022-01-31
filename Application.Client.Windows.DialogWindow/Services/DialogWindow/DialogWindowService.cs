using System.Reflection;
using Application.Client.Windows.DialogWindow.Services.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Services.DialogWindow.Options.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Window.Interfaces;
using Application.Common.Utilities.Guard;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Services.DialogWindow;

public class DialogWindowService : IDialogWindowService
{
    private readonly IServiceProvider _serviceProvider;

    public DialogWindowService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ShowDialogAsync(IDialogWindowOptionsModel dialogWindowOptions)
    {
        IDialogWindow dialogWindow = GetDialogWindow(dialogWindowOptions.WindowType);

        InitializeDialogWindow(dialogWindowOptions.WindowViewModelType, (IDialogWindowViewModel)dialogWindow.DataContext,
            dialogWindowOptions.WindowViewModelInitializerModelType, (IDialogWindowViewModelInitializerModel)dialogWindowOptions.WindowViewModelInitializerModel );

        bool? dialogResult = dialogWindow.ShowDialog();
        Guard.ThrowIfNull(dialogResult, nameof(dialogResult));

        await Task.CompletedTask;
    }

    private IDialogWindow GetDialogWindow(Type dialogWindowType)
    {
        return (IDialogWindow) _serviceProvider.GetRequiredService(dialogWindowType);
    }

    private void InitializeDialogWindow(Type dialogWindowViewModelType, IDialogWindowViewModel dialogWindowViewModel,
        Type dialogWindowViewModelInitializerModelType, IDialogWindowViewModelInitializerModel dialogWindowViewModelInitializerModel)
    {
        Type dialogWindowViewModelInitializerType = typeof(IDialogWindowViewModelInitializer<,>)
            .MakeGenericType(dialogWindowViewModelType, dialogWindowViewModelInitializerModelType);

        MethodInfo dialogWindowViewModelInitializerInitializeMethodInfo = dialogWindowViewModelInitializerType
            .GetMethods()
            .Single();

        object dialogWindowViewModelInitializer =
            _serviceProvider.GetRequiredService(dialogWindowViewModelInitializerType);

        dialogWindowViewModelInitializerInitializeMethodInfo
            .Invoke(dialogWindowViewModelInitializer, new object[] { dialogWindowViewModel, dialogWindowViewModelInitializerModel });
    }
}