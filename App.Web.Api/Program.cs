using App.BusinessLogic.Infrastructure.Extensions.DependencyInjection;
using App.Web.Api.Controllers.Infrastructure.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using SullyTech.DateInfo.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Web.Api.ErrorHandling.Filters.ActionFilters;
using SullyTech.Web.Api.ErrorHandling.Middlewares.Infrastructure.Extensions.ApplicationBuilder;

IHostBuilder hostBuilder =
    Host.CreateDefaultBuilder(args)
        .ConfigureHostConfiguration(configurationBuilder => { })
        .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
        {
            loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            loggingBuilder.AddNLog(hostBuilderContext.Configuration);
        })
        .ConfigureWebHostDefaults(webHostBuilder =>
        {
            webHostBuilder.Configure((webHostBuilderContext, applicationBuilder) =>
            {
                if (webHostBuilderContext.HostingEnvironment.IsDevelopment())
                {
                    applicationBuilder.UseSwagger();
                    applicationBuilder.UseSwaggerUI();
                }

                applicationBuilder.UseRouting();

                applicationBuilder.UseAuthentication();
                applicationBuilder.UseAuthorization();

                applicationBuilder.UseErrorHandlingMiddleware();

                applicationBuilder.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
        })
        .ConfigureServices((hostBuilderContext, serviceCollection) =>
        {
            serviceCollection.AddHttpContextAccessor();

            serviceCollection.AddMemoryCache();

            serviceCollection.AddDateInfo();

            serviceCollection.AddBusinessLogic();
            serviceCollection.AddApiControllers();


        });

hostBuilder.Build()
           .Run();