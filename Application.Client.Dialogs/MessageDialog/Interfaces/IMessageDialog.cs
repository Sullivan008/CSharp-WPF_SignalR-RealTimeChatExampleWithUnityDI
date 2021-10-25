using System.Threading.Tasks;
using Application.Client.Dialogs.MessageDialog.Models;

namespace Application.Client.Dialogs.MessageDialog.Interfaces
{
    public interface IMessageDialog
    {
        public Task<MessageDialogResult> ShowDialogAsync(MessageDialogOptions options);
    }
}
