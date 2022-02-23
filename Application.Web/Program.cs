using Application.BusinessLogic.Modules.UserManagement.Infrastructure.Extensions.DependencyInjection;
using Application.Cache.Core.Services.ApplicationCache.Infrastructure.Extensions.DependencyInjection;
using Application.Common.Utilities.Extensions;
using Application.Web.Infrastructure.Environment.Enums;
using Application.Web.SignalR.Hubs.ChatHub;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

IHostBuilder hostBuilder = 
    Host.CreateDefaultBuilder(args)
        .ConfigureHostConfiguration(configurationBuilder =>
        {
            KeyValuePair<string, string> environment = new(HostDefaults.EnvironmentKey,
                Environment.GetEnvironmentVariable(EnvironmentVariableKey.AspNetCoreEnvironment.GetEnumMemberAttrValue())!);

            configurationBuilder.AddInMemoryCollection(new[] { environment })
                                .AddEnvironmentVariables();
        })
        .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
        {
            loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            loggingBuilder.AddNLog(hostBuilderContext.Configuration);
        })
        .ConfigureWebHostDefaults(webHostBuilder =>
        {
            webHostBuilder.Configure((webHostBuilderContext, applicationBuilder) =>
            {
                applicationBuilder.UseRouting();

                applicationBuilder.UseEndpoints(endpointRouteBuilder =>
                {
                    endpointRouteBuilder.MapHub<ChatHub>(nameof(ChatHub));
                });
            });
        })
        .ConfigureServices(serviceCollection =>
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddApplicationCacheService();

            serviceCollection.AddSignalR()
                             .AddNewtonsoftJsonProtocol();

            serviceCollection.AddUserManagementModule();
        });

hostBuilder.Build().Run();