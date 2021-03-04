using Microsoft.AspNet.SignalR.Hubs;
using Unity;

namespace Application.Server.Container.Unity
{
    public class HubActivator : IHubActivator
    {
        private readonly IUnityContainer _container;

        public HubActivator(IUnityContainer container)
        {
            _container = container;
        }

        public IHub Create(HubDescriptor hubDescriptor)
        {
            return (IHub)_container.Resolve(hubDescriptor.HubType);
        }
    }
}
