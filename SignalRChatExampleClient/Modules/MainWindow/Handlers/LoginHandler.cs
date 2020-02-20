using SignalRChatExampleClient.Models;
using SignalRChatExampleClient.Modules.MainWindow.Interfaces;
using SignalRChatExampleClient.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Modules.MainWindow.Handlers
{
    public class LoginHandler : ILoginHandler
    {
        public TaskFactory CtxTaskFactory { get; set; }

        public ObservableCollection<ParticipantViewModel> Participants { get; set; }

        public bool ParticipantIsExists(User loggedUser) =>
            Participants.FirstOrDefault(x => string.Equals(x.ConnectionId.ToLower(), loggedUser.ConnectionId.ToLower())) == null;

        public void AddNewParticipant(User loggedUser)
        {
            CtxTaskFactory.StartNew(() =>
                Participants.Add(new ParticipantViewModel
                {
                    Name = loggedUser.UserName,
                    ConnectionId = loggedUser.ConnectionId
                })).Wait();
        }
    }
}
