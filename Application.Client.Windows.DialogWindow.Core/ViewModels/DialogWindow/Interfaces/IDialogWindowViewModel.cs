using Application.Client.Windows.Core.ViewModels.Window.Interfaces;
using Application.Client.Windows.DialogWindow.Core.Models.CustomDialogWindowResult.Interfaces;

namespace Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Interfaces;

public interface IDialogWindowViewModel : IWindowViewModel
{
    public ICustomDialogWindowResultModel CustomDialogResult { get; set; }
}