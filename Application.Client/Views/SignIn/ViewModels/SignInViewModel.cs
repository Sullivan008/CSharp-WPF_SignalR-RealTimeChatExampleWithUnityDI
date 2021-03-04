using Application.Client.Core.AppUser.Services.Interfaces;
using Application.Client.Core.SystemNotification.Services.Interfaces;
using Application.Client.Core.ViewModels;
using Application.Client.SignalR.Hubs.Chat.Interfaces;
using Application.Client.Views.SignIn.ViewModels.Interfaces;

namespace Application.Client.Views.SignIn.ViewModels
{
    public partial class SignInViewModel : ViewModelBase, ISignInViewModel
    {
        private readonly ISignalRChatHub _signalRChatHub;

        private readonly IAppUserService _appUserService;

        private readonly ISystemNotificationService _systemNotificationService;
        
        public SignInViewModel(ISignalRChatHub signalRChatHub, IAppUserService appUserService, ISystemNotificationService systemNotificationService)
        {
            _signalRChatHub = signalRChatHub;
            _appUserService = appUserService;
            _systemNotificationService = systemNotificationService;
        }

        #region PROPERTIES GETTERS/ SETTERS

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;

                OnPropertyChanged();
            }
        }

        #endregion
    }
}
