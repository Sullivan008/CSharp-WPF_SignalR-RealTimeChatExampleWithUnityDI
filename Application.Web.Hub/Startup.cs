using Application.Web.Hub.Chat;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Web.Hub
{
    public class Startup
    {
        public Startup()
        { }

        public static void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            applicationBuilder.UseRouting();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>(nameof(ChatHub));
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR()
                    .AddNewtonsoftJsonProtocol();
        }
    }
}
