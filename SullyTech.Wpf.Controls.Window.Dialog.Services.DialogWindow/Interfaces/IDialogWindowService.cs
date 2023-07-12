using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Result.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;

public interface IDialogWindowService : IWindowService
{
    public Task<TIDialogResult> ShowDialogAsync<TIDialogResult>(IDialogWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions)
        where TIDialogResult : IDialogResult;

    public Task SetDialogResultAsync<TIDialogResult>(string windowId, TIDialogResult dialogResult)
        where TIDialogResult : IDialogResult;
}