using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Core.Commands;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _signOutCommand;
        public ICommand SignOutCommand =>
            _signOutCommand ?? (_signOutCommand = new RelayCommandAsync(ExecuteSignOutCommand, o => CanExecuteSignOutCommand(_signalRChatHub.IsConnected, _appUserService.IsAppUserExist())));

        private static bool CanExecuteSignOutCommand(bool isConnected, bool isAppUserExisting)
        {
            return isConnected && isAppUserExisting;
        }

        private async Task ExecuteSignOutCommand()
        {
            try
            {
                await _signalRChatHub.SignOutAsync();

                _appCacheStorageService.ClearStorage();
            }
            catch (InvalidOperationException ex)
            {
                _systemNotificationService.ShowError("An error occurred while the user was trying to sign out!", ex);
            }
        }
    }
}
