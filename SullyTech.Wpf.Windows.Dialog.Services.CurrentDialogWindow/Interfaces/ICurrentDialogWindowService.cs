using SullyTech.Wpf.Windows.Core.Services.CurrentWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;

namespace SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;

public interface ICurrentDialogWindowService : ICurrentWindowService
{
    public Task SetDialogResultAsync(IDialogResult dialogResult);
}