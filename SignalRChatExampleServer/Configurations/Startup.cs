using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace SignalRChatExampleServer.Configurations
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseCors(CorsOptions.AllowAll);

            appBuilder.MapSignalR("/signalchat", new HubConfiguration());
        }
    }
}
