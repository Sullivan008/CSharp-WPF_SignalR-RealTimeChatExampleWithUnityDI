using SignalRChatExampleClient.Conditions.MainWindowViewModel;
using SignalRChatExampleClient.Modules.Chat.Interfaces;
using SignalRChatExampleClient.Modules.Chat.Services;
using SignalRChatExampleClient.Modules.Common.Handlers;
using SignalRChatExampleClient.Modules.Common.Services;
using SignalRChatExampleClient.Modules.Dialog.Interfaces;
using SignalRChatExampleClient.Modules.Dialog.Services;
using SignalRChatExampleClient.Modules.MainWindow.Handlers;
using SignalRChatExampleClient.Modules.MainWindow.Interfaces;
using SignalRChatExampleClient.Modules.MessageWindow.Interfaces;
using SignalRChatExampleClient.Modules.MessageWindow.Services;
using SignalRChatExampleClient.ViewModels.MainWindow;
using SignalRChatExampleClient.ViewModels.MessageWindow;
using System.Threading.Tasks;
using Unity;

namespace SignalRChatExampleClient.Container.Unity
{
    public class ServiceLocator
    {
        private readonly UnityContainer container;

        public ServiceLocator()
        {
            container = GetContainerWithRegistrations() as UnityContainer;
        }

        public IUnityContainer GetContainerWithRegistrations() =>
            new UnityContainer()
                .RegisterType<IChatService, ChatService>()
                .RegisterType<IMWVMCommandExecuteConditionsService, MWVMCommandExecuteConditionsService>()
                .RegisterType<ICommonParticipantOperations, CommonParticipantOperations>()
                .RegisterType<ILoginHandler, LoginHandler>()
                .RegisterType<ILogoutHandler, LogoutHandler>()
                .RegisterType<IDisconnectHandler, DisconnectHandler>()
                .RegisterType<IMessageHandler, MessageHandler>()
                .RegisterType<IReconnectHandler, ReconnectHandler>()
                .RegisterType<IMessageWindowService, MessageWindowService>()
                .RegisterType<INotificationDialogWindowService, NotificationDialogWindowService>()
                .RegisterInstance(new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext()));

        public MainWindowViewModel MainWindowViewModel => 
            container.Resolve<MainWindowViewModel>();

        public MessageWindowViewModel MessageWindowViewModel =>
            container.Resolve<MessageWindowViewModel>();
    }
}
