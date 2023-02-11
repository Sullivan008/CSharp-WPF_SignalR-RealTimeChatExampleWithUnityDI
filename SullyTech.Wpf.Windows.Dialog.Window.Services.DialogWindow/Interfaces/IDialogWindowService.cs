using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Result.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.Interfaces;

public interface IDialogWindowService : IWindowService
{
    public Task<IDialogWindow> GetWindowAsync(string windowId);

    public Task<TIDialogResult> ShowDialogAsync<TIDialogResult>(IDialogWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions)
        where TIDialogResult : IDialogResult;

    public Task SetDialogResultAsync<TIDialogResult>(IDialogWindow window, TIDialogResult dialogResult)
        where TIDialogResult : IDialogResult;
}