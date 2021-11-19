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
            serviceCollection.AddCacheServices();
            serviceCollection.AddCacheRepositories();

            serviceCollection.AddSignalR()
                             .AddNewtonsoftJsonProtocol();
        });

hostBuilder.Build().Run();