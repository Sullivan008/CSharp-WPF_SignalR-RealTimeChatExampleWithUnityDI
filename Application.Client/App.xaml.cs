using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Application.Client.Infrastructure.Environment.Enums;
using Application.Client.Infrastructure.ErrorHandling.DataBinding.TraceListeners;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models.Enums;
using Application.Client.SignalR.Core.Configurations.Infrastructure.Extensions.DependencyInjection;
using Application.Client.SignalR.Hubs.ChatHub.Extensions.DependencyInjection;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Options.Models;
using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Services.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Services.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Services.DialogWindow.Options.Models;
using Application.Client.Windows.DialogWindow.Services.DialogWindow.Options.Models.Interfaces;
using Application.Client.Windows.Implementations.ExceptionDialog.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Implementations.ExceptionDialog.Window;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow.Initializer.Models;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings.Initializer.Models;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.Initializer.Models;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData.Initializer.Models;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.WindowResults.ExceptionDialog;
using Application.Client.Windows.Implementations.Main.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Implementations.Main.Window;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData.Initializer.Models;
using Application.Client.Windows.Implementations.MessageBox.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models.Interfaces;
using Application.Common.Utilities.Extensions;
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
                                    .AddJsonFile("appsettings.signalr.json", optional: false, reloadOnChange: true);
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

    private static void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
    {
        serviceCollection.AddContentPresenterService();
        serviceCollection.AddNavigationWindowService();
        serviceCollection.AddDialogWindowService();

        serviceCollection.AddToastNotificationService();

        serviceCollection.AddMainWindow();
        serviceCollection.AddMessageBoxWindow();
        serviceCollection.AddExceptionDialogWindow();

        serviceCollection.AddHubConfigurations(configuration);
        serviceCollection.AddChatHub();
    }

    protected override async void OnStartup(StartupEventArgs eventArgs)
    {
        await _host.StartAsync();

        ConfigureDataBindingErrorListener();
        Current.DispatcherUnhandledException += AppDispatcherUnhandledException;

        SubscribeToPublicChatHubEvents();
        ConnectToChatHub();

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

    private static void ConfigureDataBindingErrorListener()
    {
        PresentationTraceSources.Refresh();
        PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;
        PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorTraceListener());
    }

    private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs eventArgs)
    {
        LogUnhandledException(eventArgs.Exception);

        ShowUnhandledException(eventArgs.Exception);

        eventArgs.Handled = true;
        Current.Shutdown();
    }

    private async void LogUnhandledException(Exception exception)
    {
        ILogger<App> logger = _host.Services.GetRequiredService<ILogger<App>>();
        logger.LogError(exception, exception.Message);

        await Task.CompletedTask;
    }

    private async void ShowUnhandledException(Exception exception)
    {
        IDialogWindowService dialogWindowService = _host.Services.GetRequiredService<IDialogWindowService>();

        IDialogWindowShowDialogOptionsModel showDialogOptions = new DialogWindowShowDialogOptionsModel<ExceptionDialogWindow, ExceptionDialogWindowViewModel, ExceptionDialogWindowViewModelInitializerModel>
        {
            WindowViewModelInitializerModel = new ExceptionDialogWindowViewModelInitializerModel
            {
                WindowSettings = new ExceptionDialogWindowSettingsViewModelInitializerModel
                {
                    Title = "Unexpected application error"
                }
            }
        };

        IContentPresenterLoadOptions contentPresenterLoadOptions = new ContentPresenterLoadOptions<ExceptionDialogViewModel, ExceptionDialogViewModelInitializerModel>
        {
            ContentPresenterViewModelInitializerModel = new ExceptionDialogViewModelInitializerModel
            {
                ViewDataInitializerModel = new ExceptionDialogViewDataViewModelInitializerModel
                {
                    Message = exception.Message,
                    Type = exception.GetType(),
                    StackTrace = exception.StackTrace,
                    InnerException = exception.InnerException
                }
            }
        };

        await dialogWindowService.ShowDialogAsync<ExceptionDialogWindowResult>(showDialogOptions, contentPresenterLoadOptions);
    }

    private void SubscribeToPublicChatHubEvents()
    {
        IChatHub chatHub = _host.Services.GetRequiredService<IChatHub>();

        SubscribeToOnInvokeAsyncErrorChatHubEvent(chatHub);
    }

    private void SubscribeToOnInvokeAsyncErrorChatHubEvent(IChatHub chatHub)
    {
        ILogger<App> logger = _host.Services.GetRequiredService<ILogger<App>>();

        IToastNotificationService toastNotificationService = _host.Services.GetRequiredService<IToastNotificationService>();
        ShowNotificationOptions showNotificationOptions = new()
        {
            Title = "Application message",
            Message = "An Internal Server Error has occurred! Please contact your system administrator!",
            NotificationType = NotificationType.Error
        };

        chatHub.OnInvokeAsyncError += async exception =>
        {
            await Current.Dispatcher.InvokeAsync(async () =>
            {
                logger.LogError(exception, exception.Message);

                await toastNotificationService.ShowNotification(showNotificationOptions);
            });
        };
    }

    private async void ConnectToChatHub()
    {
        IChatHub chatHub = _host.Services.GetRequiredService<IChatHub>();

        await chatHub.ConnectAsync();
    }

    private async void ShowMainWindow()
    {
        INavigationWindowService navigationWindowService = _host.Services.GetRequiredService<INavigationWindowService>();

        INavigationWindowShowOptionsModel windowOptions = new NavigationWindowShowOptionsModel<MainWindow, MainWindowViewModel, MainWindowViewModelInitializerModel>
        {
            WindowViewModelInitializerModel = new MainWindowViewModelInitializerModel
            {
                WindowSettings = new MainWindowSettingsViewModelInitializerModel
                {
                    Title = "SignalR Chat"
                }
            }
        };

        IContentPresenterLoadOptions contentPresenterLoadOptions = new ContentPresenterLoadOptions<SignInViewModel, SignInViewModelInitializerModel>
        {
            ContentPresenterViewModelInitializerModel = new SignInViewModelInitializerModel
            {
                ViewDataInitializerModel = new SignInViewDataViewModelInitializerModel()
            }
        };

        await navigationWindowService.ShowAsync(windowOptions, contentPresenterLoadOptions);
    }
}