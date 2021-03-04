using Application.Client.Container.Unity;
using Application.Client.Core.AppCacheStorage.Services.Interfaces;
using Application.Client.Core.AppUser.Services.Interfaces;
using Application.Client.Core.SystemNotification.Services.Interfaces;
using Application.Client.Core.ViewModels;
using Application.Client.Core.ViewNavigator;
using Application.Client.Core.ViewNavigator.Interfaces;
using Application.Client.Core.ViewNavigator.StaticValues.Enums;
using Application.Client.SignalR.Hubs.Chat.Interfaces;
using Application.Client.Views.Chat.ViewModels;
using Application.Client.Views.SignIn.ViewModels;
using Application.Client.Windows.Main.ViewModels.Interfaces;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly ISignalRChatHub _signalRChatHub;

        private readonly IAppUserService _appUserService;

        private readonly IAppCacheStorageService _appCacheStorageService;

        private readonly ISystemNotificationService _systemNotificationService;
        
        public MainWindowViewModel(ISignalRChatHub signalRChatHub, IAppUserService appUserService, IAppCacheStorageService appCacheStorageService, ISystemNotificationService systemNotificationService)
        {
            _signalRChatHub = signalRChatHub;
            _appUserService = appUserService;
            _appCacheStorageService = appCacheStorageService;
            _systemNotificationService = systemNotificationService;
            
            ViewNavigator.Subscribe(PageViewKey.SignIn, () => { CurrentPageViewModel = DependencyInjector.Retrieve<SignInViewModel>(); });
            ViewNavigator.Subscribe(PageViewKey.Chat, () => { CurrentPageViewModel = DependencyInjector.Retrieve<ChatViewModel>(); });

            ViewNavigator.Navigate(PageViewKey.SignIn);
        }

        #region PROPERTIES Getters/ Setters

        private IPageViewModel _currentPageViewModel;
        public IPageViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                _currentPageViewModel = value;

                OnPropertyChanged();
            }
        }

        #endregion
    }
}
