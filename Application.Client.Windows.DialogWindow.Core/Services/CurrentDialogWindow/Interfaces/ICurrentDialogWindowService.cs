using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.DialogWindow.Core.Models.CustomDialogWindowResult.Interfaces;

namespace Application.Client.Windows.DialogWindow.Core.Services.CurrentDialogWindow.Interfaces;

public interface ICurrentDialogWindowService : ICurrentWindowService
{
    public Task SetCustomDialogWindowResult(ICustomDialogWindowResultModel customDialogWindowResult);
}