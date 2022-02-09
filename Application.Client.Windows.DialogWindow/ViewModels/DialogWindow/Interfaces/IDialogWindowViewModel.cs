using Application.Client.Windows.Core.ViewModels.Window.Interfaces;
using Application.Client.Windows.DialogWindow.Models.CustomDialogWindowResult.Interfaces;

namespace Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;

public interface IDialogWindowViewModel : IWindowViewModel
{
    public ICustomDialogWindowResultModel CustomDialogResult { get; }
}