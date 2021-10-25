using Application.Hub.Chat;
using Application.Hub.Infrastructure.Configuration.Enums;
using Application.Hub.Infrastructure.Configuration.HubConfigurations;
using Application.Hub.Infrastructure.Configuration.HubConfigurations.Enums;
using Application.Utilities.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Application.Hub
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment, IOptions<HubConfigurations> hubConfigurations)
        {
            applicationBuilder.UseRouting();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>(hubConfigurations.Value.Hubs![HubType.Chat]);
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<HubConfigurations>(_configuration.GetSection(ConfigurationType.HubConfigurations.GetEnumMemberAttrValue()));

            services.AddSignalR();
        }
    }
}
