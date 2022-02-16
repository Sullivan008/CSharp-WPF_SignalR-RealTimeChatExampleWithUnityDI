using Application.Client.Windows.Core.Services.CurrentWindowService.Abstractions;
using Application.Client.Windows.DialogWindow.Models.CustomDialogWindowResult.Interfaces;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Window.Interfaces;

namespace Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow;

public class CurrentDialogWindowService : CurrentWindowService, ICurrentDialogWindowService
{
    public CurrentDialogWindowService(IDialogWindow dialogWindow) : base(dialogWindow)
    { }

    public async Task SetCustomDialogWindowResult(ICustomDialogWindowResultModel customDialogWindowResult)
    {
        ((IDialogWindowViewModel)Window.DataContext).CustomDialogResult = customDialogWindowResult;
        ((IDialogWindow)Window).DialogResult = true;

        await Task.CompletedTask;
    }
}