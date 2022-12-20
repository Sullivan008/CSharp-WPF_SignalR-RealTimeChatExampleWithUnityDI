using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Core.Services.Window.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.Interfaces;

public interface IDialogWindowService : IWindowService
{
    public Task<IDialogWindow> GetWindowAsync(string windowId);

    public Task<TIDialogResult> ShowDialogAsync<TIDialogResult>(IDialogWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions)
        where TIDialogResult : IDialogResult;

    public Task SetDialogResult<TIDialogResult>(IDialogWindow window, TIDialogResult dialogResult)
        where TIDialogResult : IDialogResult;
}