using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.Services.WindowService.Abstractions;
using Application.Client.Windows.DialogWindow.Models.CustomDialogWindowResult.Interfaces;
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

    public async Task<TCustomDialogWindowResultModel> ShowDialogAsync<TCustomDialogWindowResultModel>(IDialogWindowShowDialogOptionsModel dialogWindowOptions, IContentPresenterLoadOptions contentPresenterLoadOptions)
        where TCustomDialogWindowResultModel : ICustomDialogWindowResultModel
    {
        IDialogWindow dialogWindow = (IDialogWindow)CreateWindow(dialogWindowOptions.WindowType);

        IDialogWindowViewModel dialogWindowViewModel = (IDialogWindowViewModel)CreateWindowViewModel(dialogWindowOptions.WindowViewModelType);
        InitializeWindowViewModel(dialogWindowViewModel, dialogWindowOptions.WindowViewModelInitializerModel);

        ICurrentDialogWindowService currentDialogWindowService = (ICurrentDialogWindowService)CreateCurrentWindowService(dialogWindow);
        LoadContentPresenter(contentPresenterLoadOptions, currentDialogWindowService, dialogWindowViewModel);

        SetWindowDataContext(dialogWindow, dialogWindowViewModel);

        dialogWindow.ShowDialog();

        TCustomDialogWindowResultModel customDialogWindowResult = GetCustomDialogResult<TCustomDialogWindowResultModel>(dialogWindowViewModel);

        return await Task.FromResult(customDialogWindowResult);
    }

    private static TCustomDialogWindowResultModel GetCustomDialogResult<TCustomDialogWindowResultModel>(IDialogWindowViewModel dialogWindowViewModel)
        where TCustomDialogWindowResultModel : ICustomDialogWindowResultModel
    {
        return (TCustomDialogWindowResultModel)dialogWindowViewModel.CustomDialogResult;
    }

    protected override Type CurrentWindowServiceType => typeof(ICurrentDialogWindowService);
    protected override Type WindowViewModelInitializerGenericType => typeof(IDialogWindowViewModelInitializer<,>);
}