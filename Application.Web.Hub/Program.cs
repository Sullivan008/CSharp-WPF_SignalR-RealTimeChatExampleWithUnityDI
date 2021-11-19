using Application.Utilities.Extensions;
using Application.Web.Cache.Infrastructure.Repository.Extensions.DependencyInjection;
using Application.Web.Cache.Infrastructure.Services.Extensions.DependencyInjection;
using Application.Web.Hub.Chat;
using Application.Web.Hub.Infrastructure.Environment.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

IHostBuilder hostBuilder = 
    Host.CreateDefaultBuilder(args)
        .ConfigureHostConfiguration(builder =>
        {
            KeyValuePair<string, string> environment = new(HostDefaults.EnvironmentKey,
                Environment.GetEnvironmentVariable(EnvironmentVariableKey.AspNetCoreEnvironment.GetEnumMemberAttrValue())!);

            builder.AddInMemoryCollection(new[] { environment })
                .AddEnvironmentVariables();
        })
        .ConfigureLogging((context, logging) =>
        {
            logging.SetMinimumLevel(LogLevel.Trace);
            logging.AddNLog(context.Configuration);
        })
        .ConfigureWebHostDefaults(builder =>
        {
            builder.Configure((webHostBuilderContext, applicationBuilder) =>
            {
                applicationBuilder.UseRouting();

                applicationBuilder.UseEndpoints(endpoints =>
                {
                    endpoints.MapHub<ChatHub>(nameof(ChatHub));
                });
            });
        })
        .ConfigureServices(services =>
        {
            services.AddMemoryCache();
            services.AddCacheServices();
            services.AddCacheRepositories();

            services.AddSignalR()
                .AddNewtonsoftJsonProtocol();
        });

hostBuilder.Build().Run();