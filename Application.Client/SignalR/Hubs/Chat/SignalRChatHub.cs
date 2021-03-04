using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Client.Core.AppConfigurations.SignalR.ConfigurationSections;
using Application.Client.Core.AppConfigurations.SignalR.ConfigurationSections.ConfigurationElements;
using Application.Client.Core.AppUser.Services.Interfaces;
using Application.Client.Core.SystemNotification.Services.Interfaces;
using Application.Client.SignalR.Hubs.Chat.Interfaces;
using Application.Client.SignalR.Hubs.Chat.StaticValues;
using Application.Client.SignalR.Hubs.Chat.StaticValues.Enums;
using Application.Client.SignalR.Hubs.Exceptions;
using Application.Client.SignalR.Hubs.Models;
using Application.Models.RequestModels.SendMessage;
using Application.Models.RequestModels.SignIn;
using Application.Models.ResponseModels.GetParticipants;
using Application.Models.ResponseModels.SignIn;
using Microsoft.AspNet.SignalR.Client;

namespace Application.Client.SignalR.Hubs.Chat
{
    public class SignalRChatHub : ISignalRChatHub
    {
        private readonly IHubProxy _hubProxy;

        private readonly HubConnection _hubConnection;

        private readonly IAppUserService _appUserService;

        private readonly HubConfiguration _hubConfiguration;

        private readonly ISystemNotificationService _systemNotificationService;

        private readonly HashSet<string> _hubEventSubscriptions = new HashSet<string>();

        public bool IsConnected => _hubConnection.State == ConnectionState.Connected;

        public SignalRChatHub(HubConnection hubConnection, IAppUserService appUserService, ISystemNotificationService systemNotificationService)
        {
            _hubConnection = hubConnection;
            _appUserService = appUserService;
            _systemNotificationService = systemNotificationService;

            _hubConfiguration = GetHubConfiguration();

            _hubProxy = _hubConnection.CreateHubProxy(_hubConfiguration.HubName);

            Task.Run(ConnectToHubAsync).Wait();

            _hubConnection.Closed += async () => await OnHubConnectionClosedAsync();
            _hubConnection.Reconnected += async () => await OnHubConnectionReconnectedAsync();
        }

        private async Task ConnectToHubAsync()
        {
            while (_hubConnection.State != ConnectionState.Connected)
            {
                try
                {
                    await _hubConnection.Start();

                    break;
                }
                catch (HttpRequestException ex)
                {
                    _systemNotificationService.ShowWarn("The chat server is currently unavailable. Please try again later. The application will try to connect again 10 seconds after closing the dialog!", ex);

                    Task.Delay(_hubConfiguration.ReconnectTimeInterval).Wait();
                }
            }
        }

        private async Task OnHubConnectionClosedAsync()
        {
            await ConnectToHubAsync();

            bool userIsSignedIn = await IsSignedInAsync();

            if (!userIsSignedIn && _appUserService.IsAppUserExist())
            {
                SignInResponseModel response = await SignInAsync(new SignInRequestModel(_appUserService.GetUserName()));

                if (!response.IsSuccess)
                {
                    _systemNotificationService.ShowWarn(string.Join(", ", response.Errors));
                }
            }
        }

        private async Task OnHubConnectionReconnectedAsync()
        {
            bool userIsSignedIn = await IsSignedInAsync();

            if (!userIsSignedIn && _appUserService.IsAppUserExist())
            {
                SignInResponseModel response = await SignInAsync(new SignInRequestModel(_appUserService.GetUserName()));

                if (!response.IsSuccess)
                {
                    _systemNotificationService.ShowWarn(string.Join(", ", response.Errors));
                }
            }
        }

        private static HubConfiguration GetHubConfiguration()
        {
            SignalRConfigurationSection configurationSection = ConfigurationManager.GetSection("SignalRConfiguration") as SignalRConfigurationSection;

            if (configurationSection == null)
            {
                throw new ArgumentNullException(nameof(configurationSection), @"The value cannot be null!");
            }

            ChatHubConfigurationElement configurationElement = configurationSection.ChatHubConfigurationElement;

            if (configurationElement == null)
            {
                throw new ArgumentNullException(nameof(configurationElement), @"The value cannot be null!");
            }

            return new HubConfiguration(configurationElement.HubName, configurationElement.ReconnectTimeInterval);
        }

        public void RegisterHubEvent<TResponseModelType>(string actionName, Action<TResponseModelType> callbackAction)
        {
            if (string.IsNullOrWhiteSpace(actionName))
            {
                throw new ArgumentNullException(nameof(actionName), @"The hub event action name cannot be null!");
            }

            if (_hubEventSubscriptions.TryGetValue(actionName, out _))
            {
                throw new AlreadySubscribeToHubEventException($"Have already subscribe to the hub event! Hub Event Key: {actionName}");
            }

            if (callbackAction == null)
            {
                throw new ArgumentNullException(nameof(callbackAction), @"The hub event callback action cannot be null!");
            }

            _hubProxy.On<TResponseModelType>(actionName, callbackAction.Invoke);
            _hubEventSubscriptions.Add(actionName);
        }

        public void RegisterHubReconnectingEvent(Action callbackAction)
        {
            if (callbackAction == null)
            {
                throw new ArgumentNullException(nameof(callbackAction), @"The hub event callback action cannot be null!");
            }

            _hubConnection.Reconnecting += callbackAction;
        }

        #region SERVER METHODS

        public async Task<SignInResponseModel> SignInAsync(SignInRequestModel requestModel)
        {
            return await _hubProxy.Invoke<SignInResponseModel>(ServerMethods.GetServerMethodName(ServerMethodType.SignIn), requestModel);
        }

        public async Task SignOutAsync()
        {
            await _hubProxy.Invoke(ServerMethods.GetServerMethodName(ServerMethodType.SignOut));
        }
        
        public async Task<GetParticipantsResponseModel> GetParticipantsAsync()
        {
            return await _hubProxy.Invoke<GetParticipantsResponseModel>(ServerMethods.GetServerMethodName(ServerMethodType.GetParticipants));
        }

        public async Task SendMessageAsync(SendMessageRequestModel requestModel)
        {
            await _hubProxy.Invoke(ServerMethods.GetServerMethodName(ServerMethodType.SendMessage), requestModel);
        }

        private async Task<bool> IsSignedInAsync()
        {
            return await _hubProxy.Invoke<bool>(ServerMethods.GetServerMethodName(ServerMethodType.IsSignedIn));
        }

        #endregion
    }
}
