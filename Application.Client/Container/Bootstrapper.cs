using System;
using System.Configuration;
using Application.Client.Container.Unity;
using Application.Client.Core.AppCacheStorage.Services;
using Application.Client.Core.AppCacheStorage.Services.Interfaces;
using Application.Client.Core.AppConfigurations.SignalR.ConfigurationSections;
using Application.Client.Core.AppConfigurations.SignalR.ConfigurationSections.ConfigurationElements;
using Application.Client.Core.AppUser.Services;
using Application.Client.Core.AppUser.Services.Interfaces;
using Application.Client.Core.Environment.Services;
using Application.Client.Core.Environment.Services.Interfaces;
using Application.Client.Core.SystemNotification.Services;
using Application.Client.Core.SystemNotification.Services.Interfaces;
using Application.Client.SignalR.Hubs.Chat;
using Application.Client.SignalR.Hubs.Chat.Interfaces;
using Application.Client.Views.Chat.Services;
using Application.Client.Views.Chat.Services.Interfaces;
using Application.Client.Views.Chat.ViewModels;
using Application.Client.Views.Chat.ViewModels.Interfaces;
using Application.Client.Views.SignIn.ViewModels;
using Application.Client.Views.SignIn.ViewModels.Interfaces;
using Application.Client.Windows.Main.ViewModels;
using Application.Client.Windows.Main.ViewModels.Interfaces;
using Microsoft.AspNet.SignalR.Client;
using Unity.log4net;

namespace Application.Client.Container
{
    public static class Bootstrapper
    {
        public static void Init()
        {
            DependencyInjector.AddExtension<Log4NetExtension>();
            DependencyInjector.RegisterInstance(new HubConnection(HubConnectionUrl));

            DependencyInjector.RegisterSingleton<ISignalRChatHub, SignalRChatHub>();
            DependencyInjector.RegisterSingleton<IEnvironmentService, EnvironmentService>();
            DependencyInjector.RegisterSingleton<IAppCacheStorageService, AppCacheStorageService>();

            DependencyInjector.RegisterTransient<IAppUserService, AppUserService>();
            DependencyInjector.RegisterTransient<ISystemNotificationService, SystemNotificationService>();
            DependencyInjector.RegisterTransient<IManageParticipantMessagesService, ManageParticipantMessagesService>();

            DependencyInjector.RegisterTransient<IMainWindowViewModel, MainWindowViewModel>();
            DependencyInjector.RegisterTransient<ISignInViewModel, SignInViewModel>();
            DependencyInjector.RegisterTransient<IChatViewModel, ChatViewModel>();
        }

        private static string HubConnectionUrl
        {
            get
            {
                SignalRConfigurationSection configurationSection = ConfigurationManager.GetSection("SignalRConfiguration") as SignalRConfigurationSection;

                if (configurationSection == null)
                {
                    throw new ArgumentNullException(nameof(configurationSection), @"The value cannot be null!");
                }

                HubConnectionConfigurationElement configurationElement = configurationSection.HubConnectionConfiguration;

                if (configurationElement == null)
                {
                    throw new ArgumentNullException(nameof(configurationElement), @"The value cannot be null!");
                }

                return configurationElement.Url;
            }
        }
    }
}
