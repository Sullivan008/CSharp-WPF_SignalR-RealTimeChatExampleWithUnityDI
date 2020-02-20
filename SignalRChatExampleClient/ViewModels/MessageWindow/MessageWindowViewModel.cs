using System;
using System.Windows.Input;

namespace SignalRChatExampleClient.ViewModels.MessageWindow
{
    public class MessageWindowViewModel : ViewModelBase
    {
        #region PROPERTIES Getters/ Setters

        private string _windowTitle;
        public string WindowTitle
        {
            get => _windowTitle;
            set
            {
                _windowTitle = value;

                OnPropertyChanged();
            }
        }

        private string _contentTitle;
        public string ContentTitle
        {
            get => _contentTitle;
            set
            {
                _contentTitle = value;

                OnPropertyChanged();
            }
        }

        private string _senderName;
        public string SenderName
        {
            get => _senderName;
            set
            {
                _senderName = value;

                OnPropertyChanged();
            }
        }

        private DateTime _messagePostedTime;
        public DateTime MessagePostedTime
        {
            get => _messagePostedTime;
            set
            {
                _messagePostedTime = value;

                OnPropertyChanged();
            }
        }

        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;

                OnPropertyChanged();
            }
        }

        #endregion

        #region COMMANDS

        private ICommand _closeBtnCommand;
        public ICommand CloseBtnCommand =>
            _closeBtnCommand;

        #endregion

    }
}
