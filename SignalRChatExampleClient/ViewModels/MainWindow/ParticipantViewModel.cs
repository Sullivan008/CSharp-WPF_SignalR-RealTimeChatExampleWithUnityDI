using SignalRChatExampleClient.Models;
using System.Collections.ObjectModel;

namespace SignalRChatExampleClient.ViewModels.MainWindow
{
    public class ParticipantViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public string ConnectionId { get; set; }

        public ObservableCollection<ChatMessage> Messages { get; set; }

        public ParticipantViewModel()
        {
            Messages = new ObservableCollection<ChatMessage>();
        }

        #region PROPERTIES Getters/ Setters

        private bool _isLoggedIn = true;
        public bool IsLoggedIn
        {
            get => _isLoggedIn;

            set
            {
                _isLoggedIn = value;

                OnPropertyChanged();
            }
        }

        private bool _hasSentNewMessage;

        public bool HasSentNewMessage
        {
            get => _hasSentNewMessage;

            set
            {
                _hasSentNewMessage = value;

                OnPropertyChanged();
            }
        }

        #endregion
    }
}
