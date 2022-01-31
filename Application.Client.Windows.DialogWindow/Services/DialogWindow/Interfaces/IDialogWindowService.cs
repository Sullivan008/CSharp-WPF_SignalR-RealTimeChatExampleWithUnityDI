using Application.Client.Windows.DialogWindow.Services.DialogWindow.Options.Models.Interfaces;

namespace Application.Client.Windows.DialogWindow.Services.DialogWindow.Interfaces;

public interface IDialogWindowService
{
    public Task ShowDialogAsync(IDialogWindowOptionsModel dialogWindowOptions);
}