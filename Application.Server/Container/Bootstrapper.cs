using Application.Server.Container.Unity;
using Application.Server.Repositories.Participant;
using Application.Server.Repositories.Participant.Interfaces;
using Unity.log4net;

namespace Application.Server.Container
{
    public static class Bootstrapper
    {
        public static void Init()
        {
            DependencyInjector.RegisterHubActivator<HubActivator>();

            DependencyInjector.AddExtension<Log4NetExtension>();
            DependencyInjector.RegisterSingleton<IParticipantRepository, ParticipantRepository>();
        }
    }
}
