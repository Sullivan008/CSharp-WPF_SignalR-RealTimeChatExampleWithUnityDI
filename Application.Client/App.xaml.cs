using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Application.Client.Cache.Infrastructure.Repository.Extensions.DependencyInjection;
using Application.Client.Dialogs.MessageDialog.Extensions.DependencyInjection;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Models;
using Application.Client.Infrastructure.Environment.Enums;
using Application.Client.Infrastructure.ErrorHandling.Constants;
using Application.Client.Infrastructure.ErrorHandling.DataBinding.TraceListeners;
using Application.Client.Infrastructure.ErrorHandling.Models;
using Application.Client.Infrastructure.Extensions.DependencyInjection;
using Application.Client.SignalR.Hubs.ChatHub.Extensions.DependencyInjection;
using Application.Client.SignalR.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Main;
using Application.Utilities.Extensions;
using Application.Utilities.Guard;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Application.Client;

public partial class App
{
    private readonly IHost _host;

    public App()
    {
        _host = new HostBuilder()
            .ConfigureHostConfiguration(configurationBuilder =>
            {
                KeyValuePair<string, string> environment = new(HostDefaults.EnvironmentKey,
                    Environment.GetEnvironmentVariable(EnvironmentVariableKey.AspNetCoreEnvironment.GetEnumMemberAttrValue())!);

                configurationBuilder.AddInMemoryCollection(new[] { environment })
                                    .AddEnvironmentVariables();
            })
            .ConfigureAppConfiguration(configurationBuilder =>
            {
                configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                    .AddJsonFile("signalrsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((hostBuilderContext, serviceCollection) =>
            {
                ConfigureServices(hostBuilderContext.Configuration, serviceCollection);
            })
            .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                loggingBuilder.AddNLog(hostBuilderContext.Configuration);
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs eventArgs)
    {
        await _host.StartAsync();

        ConfigureDataBindingErrorListener();

        Current.DispatcherUnhandledException += AppDispatcherUnhandledException;

        MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();

        Guard.ThrowIfNull(mainWindow, nameof(mainWindow));

        mainWindow.Show();

        base.OnStartup(eventArgs);
    }

    protected override async void OnExit(ExitEventArgs eventArgs)
    {
        using (_host)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
        }

        base.OnExit(eventArgs);
    }

    private static void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
    {
        serviceCollection.AddMemoryCache();
        serviceCollection.AddCacheRepositories();

        serviceCollection.AddHubConfigurations(configuration);
        serviceCollection.AddChatHub();

        serviceCollection.AddMainWindow();

        serviceCollection.AddMessageDialog();
    }

    private static void ConfigureDataBindingErrorListener()
    {
        PresentationTraceSources.Refresh();
        PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;
        PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorTraceListener());
    }

    private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs eventArgs)
    {
        IHostEnvironment hostEnvironment = _host.Services.GetRequiredService<IHostEnvironment>();
        ILogger<App> logger = _host.Services.GetRequiredService<ILogger<App>>();

        logger.LogError(eventArgs.Exception, eventArgs.Exception.Message);

        ErrorModel errorModel = new()
        {
            Message = eventArgs.Exception.Message,
            Exception = hostEnvironment.IsDevelopment() ? eventArgs.Exception.ToString() : ErrorConstants.NON_DEVELOPMENT_EXCEPTION_MESSAGE
        };

        ShowUnhandledException(errorModel);

        eventArgs.Handled = true;
    }

    private async void ShowUnhandledException(ErrorModel errorModel)
    {
        IMessageDialog messageDialog = _host.Services.GetRequiredService<IMessageDialog>();

        await messageDialog.ShowDialogAsync(new MessageDialogOptions
        {
            Content = $"An application error occurred.\n\n{errorModel.Message}.\n\n{errorModel.Exception}",
            Title = "Application Error",
            Button = MessageBoxButton.OK,
            Icon = MessageBoxImage.Error
        });

        Current.Shutdown();
    }
}