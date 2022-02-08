using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Window.Interfaces;

namespace Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow;

public class CurrentDialogWindowService : ICurrentDialogWindowService
{
    private readonly IDialogWindow _dialogWindow;

    private readonly IServiceProvider _serviceProvider;


    public CurrentDialogWindowService(IServiceProvider serviceProvider, IDialogWindow dialogWindow)
    {
        _dialogWindow = dialogWindow;
        _serviceProvider = serviceProvider;
    }
    
}