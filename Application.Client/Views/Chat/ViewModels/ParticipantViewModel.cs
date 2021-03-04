using System;
using Application.Client.Core.ViewModels;

namespace Application.Client.Views.Chat.ViewModels
{
    public class ParticipantViewModel : ViewModelBase
    {
        public string Id { get; }

        public string Name { get; }

        public ParticipantViewModel(string id, string name)
        {
            Id = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentNullException(nameof(id), @"The value cannot be null!");
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name), @"The value cannot be null!");
        }

        #region PROPERTIES GETTERS/ SETTERS

        private bool _isConnected = true;
        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                
                OnPropertyChanged();
            }
        }

        private bool _hasUnreadMessage;
        public bool HasUnreadMessage
        {
            get => _hasUnreadMessage;
            set
            {
                _hasUnreadMessage = value;

                OnPropertyChanged();
            }
        }

        #endregion
    }
}
