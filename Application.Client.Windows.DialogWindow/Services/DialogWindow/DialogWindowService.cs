using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.Services.WindowService.Abstractions;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Services.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Services.DialogWindow.Options.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Window.Interfaces;

namespace Application.Client.Windows.DialogWindow.Services.DialogWindow;

public class DialogWindowService : WindowService, IDialogWindowService
{
    public DialogWindowService(IServiceProvider serviceProvider, IContentPresenterService contentPresenterService) : base(serviceProvider, contentPresenterService)
    { }

    public async Task ShowDialogAsync(IDialogWindowShowDialogOptionsModel dialogWindowOptions, IContentPresenterLoadOptions contentPresenterLoadOptions)
    {
        IDialogWindow dialogWindow = (IDialogWindow)CreateWindow(dialogWindowOptions.WindowType);

        IDialogWindowViewModel dialogWindowViewModel = (IDialogWindowViewModel)CreateWindowViewModel(dialogWindowOptions.WindowViewModelType);
        InitializeWindowViewModel(dialogWindowViewModel, dialogWindowOptions.WindowViewModelInitializerModel);

        ICurrentDialogWindowService currentDialogWindowService = (ICurrentDialogWindowService)CreateCurrentWindowService(dialogWindow);
        LoadContentPresenter(contentPresenterLoadOptions, currentDialogWindowService, dialogWindowViewModel);

        SetWindowDataContext(dialogWindow, dialogWindowViewModel);

        dialogWindow.ShowDialog();

        await Task.CompletedTask;
    }

    protected override Type CurrentWindowServiceType => typeof(ICurrentDialogWindowService);
    protected override Type WindowViewModelInitializerGenericType => typeof(IDialogWindowViewModelInitializer<,>);
}