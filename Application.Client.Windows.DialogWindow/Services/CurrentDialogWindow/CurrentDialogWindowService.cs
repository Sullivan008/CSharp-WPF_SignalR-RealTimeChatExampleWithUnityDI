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

    public void SetCustomDialogWindowResult(ICustomDialogWindowResultModel customDialogWindowResult)
    {
        ((IDialogWindowViewModel) Window.DataContext).CustomDialogResult = customDialogWindowResult;

        Window.Close();
    }
}