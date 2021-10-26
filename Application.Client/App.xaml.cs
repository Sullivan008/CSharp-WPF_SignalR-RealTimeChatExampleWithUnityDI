using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
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

namespace Application.Client
{
    public partial class App
    {
        private readonly IHost _host;

        public App()
        {
            _host = new HostBuilder()
                .ConfigureHostConfiguration(builder =>
                {
                    KeyValuePair<string, string> environment = new(HostDefaults.EnvironmentKey,
                        Environment.GetEnvironmentVariable(EnvironmentVariableKey.AspNetCoreEnvironment.GetEnumMemberAttrValue())!);

                    builder.AddInMemoryCollection(new[] { environment })
                           .AddEnvironmentVariables();
                })
                .ConfigureAppConfiguration(builder =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                           .AddJsonFile("signalrsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                    logging.AddNLog(context.Configuration);
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            ConfigureDataBindingErrorListener();

            Current.DispatcherUnhandledException += AppDispatcherUnhandledException;

            MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();

            Guard.ThrowIfNull(mainWindow, nameof(mainWindow));

            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddHubConfigurations(configuration);
            services.AddChatHub();

            services.AddMainWindow();

            services.AddMessageDialog();
        }

        private static void ConfigureDataBindingErrorListener()
        {
            PresentationTraceSources.Refresh();
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;
            PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorTraceListener());
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            IHostEnvironment hostEnvironment = _host.Services.GetRequiredService<IHostEnvironment>();
            ILogger<App> logger = _host.Services.GetRequiredService<ILogger<App>>();

            logger.LogError(e.Exception, e.Exception.Message);

            ErrorModel errorModel = new()
            {
                Message = e.Exception.Message,
                Exception = hostEnvironment.IsDevelopment() ? e.Exception.ToString() : ErrorConstants.NON_DEVELOPMENT_EXCEPTION_MESSAGE
            };

            ShowUnhandledException(errorModel);

            e.Handled = true;
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
}
