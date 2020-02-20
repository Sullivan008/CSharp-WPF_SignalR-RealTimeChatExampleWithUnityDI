using SignalRChatExampleClient.Models;
using SignalRChatExampleClient.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Modules.MainWindow.Interfaces
{
    public interface ILoginHandler
    {
        ObservableCollection<ParticipantViewModel> Participants { get; set; }

        TaskFactory CtxTaskFactory { get; set; }

        bool ParticipantIsExists(User loggedUser);

        void AddNewParticipant(User loggedUser);
    }
}
