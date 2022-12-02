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
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Impl.Main.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SullyTech.Extensions.Enum;
using SullyTech.Guard;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.ViewModels.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.ViewModels.PresenterData.Initializer.Models;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Result;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Window;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.WindowSettings.Initializer.Models;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.WindowShowOptions;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.WindowShowOptions.Interfaces;

namespace Application.Client;

public partial class App
{
    private readonly IHost _host;

    public App()
    {
        _host = new HostBuilder()
            .ConfigureHostConfiguration(configurationBuilder =>
            {
                string? variable = EnvironmentVariableKey.AspNetCoreEnvironment.GetEnumMemberAttrValue();
                Guard.ThrowIfNullOrWhitespace(variable, nameof(variable));

                KeyValuePair<string, string> environment = new(HostDefaults.EnvironmentKey,
                    Environment.GetEnvironmentVariable(variable!)!);

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
        serviceCollection.AddNavigationWindowService();
        serviceCollection.AddDialogWindowService();

        serviceCollection.AddToastNotificationService();

        serviceCollection.AddMainWindow();
        serviceCollection.AddMessageBoxWindow();
        serviceCollection.AddExceptionDialog();

        serviceCollection.AddHubConfigurations(configuration);
        serviceCollection.AddChatHub();
    }

    protected override async void OnStartup(StartupEventArgs eventArgs)
    {
        await _host.StartAsync();

        ConfigureDataBindingErrorListener();
        Current.DispatcherUnhandledException += AppDispatcherUnhandledException;
        TaskScheduler.UnobservedTaskException += UnobservedTaskException;


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

        eventArgs.Handled = true;

        if (eventArgs.Exception is HubException)
        {
            ShowToastNotificationFromHubException();
        }
        else
        {
            ShowExceptionDialogFromUnhandledException(eventArgs.Exception);

            Current.Shutdown();
        }
    }

    private void UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs eventArgs)
    {
        Current.Dispatcher.BeginInvoke(() =>
        {
            LogUnhandledException(eventArgs.Exception);

            if (eventArgs.Exception.InnerExceptions.Any())
            {
                Exception exception = eventArgs.Exception.InnerExceptions.First();

                if (exception is HubException)
                {
                    ShowToastNotificationFromHubException();
                }
                else
                {
                    ShowExceptionDialogFromUnhandledException(eventArgs.Exception);

                    Current.Shutdown();
                }
            }
            else
            {
                ShowExceptionDialogFromUnhandledException(eventArgs.Exception);

                Current.Shutdown();
            }
        });
    }

    private async void LogUnhandledException(Exception exception)
    {
        ILogger<App> logger = _host.Services.GetRequiredService<ILogger<App>>();
        logger.LogError(exception, exception.Message);

        await Task.CompletedTask;
    }

    private async void ShowToastNotificationFromHubException()
    {
        IToastNotificationService toastNotificationService = _host.Services.GetRequiredService<IToastNotificationService>();
        ShowNotificationOptions showNotificationOptions = new()
        {
            Title = "Application message",
            Message = "An Internal Server Error has occurred! Please contact your system administrator!",
            NotificationType = NotificationType.Error
        };

        await toastNotificationService.ShowNotification(showNotificationOptions);
    }

    private async void ShowExceptionDialogFromUnhandledException(Exception exception)
    {
        IDialogWindowService dialogWindowService = _host.Services.GetRequiredService<IDialogWindowService>();

        IDialogWindowShowOptions showDialogOptions = new DialogWindowShowOptions<ExceptionDialogWindow, ExceptionDialogWindowViewModel>
        {
            WindowSettingsViewModelInitializerModel = new ExceptionDialogWindowSettingsViewModelInitializerModel
            {
                Title = "Unexpected Application Error"
            }
        };

        IPresenterLoadOptions contentPresenterLoadOptions = new PresenterLoadOptions<ExceptionDialogViewModel>
        {
            PresenterDataViewModelInitializerModel = new ExceptionDialogDataViewModelInitializerModel
            {
                Message = exception.Message,
                Type = exception.GetType(),
                StackTrace = exception.StackTrace,
                InnerException = exception.InnerException
            }
        };

        await dialogWindowService.ShowDialogAsync<ExceptionDialogResult>(showDialogOptions, contentPresenterLoadOptions);
    }

    private async void ConnectToChatHub()
    {
        IChatHub chatHub = _host.Services.GetRequiredService<IChatHub>();

        await chatHub.ConnectAsync();
    }

    private async void ShowMainWindow()
    {
        INavigationWindowService navigationWindowService = _host.Services.GetRequiredService<INavigationWindowService>();

        INavigationWindowShowOptions windowOptions = new NavigationWindowShowOptions<MainWindow, MainWindowViewModel>
        {
            WindowSettingsViewModelInitializerModel = new MainWindowSettingsViewModelInitializerModel
            {
                Title = "SignalR Chat Example",
                Height = 750,
                Width = 450
            }
        };

        IPresenterLoadOptions presenterLoadOptions = new PresenterLoadOptions<SignInViewModel>();

        await navigationWindowService.ShowAsync(windowOptions, presenterLoadOptions);
    }
}