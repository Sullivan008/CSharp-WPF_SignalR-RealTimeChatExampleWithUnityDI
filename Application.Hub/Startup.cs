using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Hub
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        { }

        public static void ConfigureServices(IServiceCollection services)
        { }
    }
}
