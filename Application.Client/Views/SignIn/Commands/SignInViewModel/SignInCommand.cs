using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Core.ViewNavigator;
using Application.Client.Core.ViewNavigator.StaticValues.Enums;
using Application.Models.RequestModels.SignIn;
using Application.Models.ResponseModels.SignIn;

namespace Application.Client.Views.SignIn.ViewModels
{
    public partial class SignInViewModel
    {
        private ICommand _signInCommand;
        public ICommand SignInCommand =>
            _signInCommand ?? (_signInCommand = new RelayCommandAsync(ExecuteSignInCommand, o => CanExecuteSignInCommand(_signalRChatHub.IsConnected, _userName)));

        public bool CanExecuteSignInCommand(bool isConnected, string userName)
        {
            const int USER_NAME_MIN_LENGTH = 3;

            return isConnected && !string.IsNullOrWhiteSpace(userName) && userName.Length >= USER_NAME_MIN_LENGTH;
        }

        private async Task ExecuteSignInCommand()
        {
            try
            {
                SignInResponseModel response = await _signalRChatHub.SignInAsync(new SignInRequestModel(_userName));

                if (response.IsSuccess)
                {
                    _appUserService.SetAppUser(_userName);

                    ViewNavigator.Navigate(PageViewKey.Chat);
                }
                else
                {
                    _systemNotificationService.ShowWarn(string.Join("/n", response.Errors));
                }
            }
            catch (Exception ex)
            {
                _systemNotificationService.ShowError("There was an error signing in!", ex);
            }
        }
    }
}
