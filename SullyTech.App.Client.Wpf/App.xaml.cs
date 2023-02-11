using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SullyTech.App.Client.SignalR.Hubs.ChatHub.Extensions.DependencyInjection;
using SullyTech.App.Client.SignalR.Hubs.ChatHub.Extensions.Hosting;
using SullyTech.App.Client.Wpf.Modules.Chat.Infrastructure.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Modules.Identity.Infrastructure.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.App.Client.Wpf.Windows.Main.Infrastructure.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.Services.Main.Interfaces;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Services.ExceptionDialog.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings.Models;
using SullyTech.Wpf.Dialogs.MessageDialog.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Notifications.Toast.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;
using SullyTech.Wpf.TraceListeners.BindingError;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf;

public partial class App
{
    private readonly IHost _host;

    public App()
    {
        _host = new HostBuilder()
            .ConfigureHostConfiguration(configurationBuilder =>
            {
                configurationBuilder.AddEnvironmentVariables("DOTNET_");
            })
            .ConfigureAppConfiguration(configurationBuilder =>
            {
                configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((hostBuilderContext, serviceCollection) =>
            {
                serviceCollection.AddChatHub(hostBuilderContext.Configuration);

                serviceCollection.AddToastNotification(hostBuilderContext.Configuration);

                serviceCollection.AddDialogWindowService();
                serviceCollection.AddNavigationWindowService();

                serviceCollection.AddMessageDialog();
                serviceCollection.AddExceptionDialog();

                serviceCollection.AddMainWindow();

                serviceCollection.AddIdentityModule();
                serviceCollection.AddChatModule();
            })
            .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                loggingBuilder.AddNLog(hostBuilderContext.Configuration);
            })
            .Build()
            .ConnectToChatHub();
    }

    protected override async void OnStartup(StartupEventArgs eventArgs)
    {
        await _host.StartAsync();

        InitBindingErrorTraceListener();

        Current.DispatcherUnhandledException += OnDispatcherUnhandledException;
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;

        ShowMainWindow();

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

    private static void InitBindingErrorTraceListener()
    {
        PresentationTraceSources.Refresh();
        PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;
        PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorTraceListener());
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs eventArgs)
    {
        LogUnhandledException(eventArgs.Exception);

        if (eventArgs.Exception is HubException)
        {
            ShowHubExceptionNotification();
        }
        else
        {
            ShowExceptionDialog(eventArgs.Exception);

            Current.Shutdown();
        }

        eventArgs.Handled = true;
    }

    private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs eventArgs)
    {
        Current.Dispatcher.BeginInvoke(() =>
        {
            LogUnhandledException(eventArgs.Exception);

            if (eventArgs.Exception.InnerExceptions.Any())
            {
                Exception exception = eventArgs.Exception.InnerExceptions.First();

                if (exception is HubException)
                {
                    ShowHubExceptionNotification();
                }
                else
                {
                    ShowExceptionDialog(eventArgs.Exception);

                    Current.Shutdown();
                }
            }
            else
            {
                ShowExceptionDialog(eventArgs.Exception);

                Current.Shutdown();
            }
        });
    }

    private void LogUnhandledException(Exception exception)
    {
        ILogger<App> logger = _host.Services.GetRequiredService<ILogger<App>>();
        logger.LogError(exception, exception.Message);
    }

    private async void ShowHubExceptionNotification()
    {
        IToastNotification toastNotification = _host.Services.GetRequiredService<IToastNotification>();

        await toastNotification.ShowNotificationAsync(
            showNotificationOptions: new ShowNotificationOptions
            {
                Title = "Application message",
                Message = "An Internal Server Error has occurred! Please contact your system administrator!",
                NotificationType = NotificationType.Error
            });
    }

    private async void ShowExceptionDialog(Exception exception)
    {
        IExceptionDialogService exceptionDialogService = _host.Services.GetRequiredService<IExceptionDialogService>();

        await exceptionDialogService.ShowDialogAsync(
            windowSettingsViewModelInitializerModel: new ExceptionDialogWindowSettingsViewModelInitializerModel
            {
                Title = "Unexpected Application Error"
            },
            presenterDataViewModelInitializerModel: new ExceptionDialogDataViewModelInitializerModel
            {
                Message = exception.Message,
                Type = exception.GetType(),
                StackTrace = exception.StackTrace,
                InnerException = exception.InnerException
            });
    }

    private async void ShowMainWindow()
    {
        IMainWindowService mainWindowService = _host.Services.GetRequiredService<IMainWindowService>();

        await mainWindowService.ShowAsync<ISignInViewModel, ISignInDataViewModel>(
            windowSettingsViewModelInitializerModel: new MainWindowSettingsViewModelInitializerModel
            {
                Title = "SullyTech - SignalR Chat Example",
                Height = 750,
                Width = 450
            });
    }
}