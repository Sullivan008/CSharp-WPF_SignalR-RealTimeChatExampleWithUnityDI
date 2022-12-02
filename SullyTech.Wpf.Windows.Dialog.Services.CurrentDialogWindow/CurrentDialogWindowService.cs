using SullyTech.Wpf.Windows.Core.Services.CurrentWindow.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow;

public class CurrentDialogWindowService : CurrentWindowService, ICurrentDialogWindowService
{
    public CurrentDialogWindowService(IDialogWindow dialogWindow) : base(dialogWindow)
    { }

    public async Task SetDialogResultAsync(IDialogResult dialogResult)
    {
        ((IDialogWindowViewModel)Window.DataContext).DialogResult = dialogResult;
        ((IDialogWindow)Window).DialogResult = true;

        await Task.CompletedTask;
    }
}