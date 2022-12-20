using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Application.Client.SignalR.Hubs.ChatHub.Extensions.DependencyInjection;
using Application.Client.SignalR.Hubs.ChatHub.Extensions.Hosting;
using Application.Client.Windows.NavigationWindow.Impl.Main.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Initializers.PresenterData.Models;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Result.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings.Models;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Notifications.Toast.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;
using SullyTech.Wpf.TraceListeners.BindingError;
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
                serviceCollection.AddDialogWindowService();
                serviceCollection.AddNavigationWindowService();

                serviceCollection.AddToastNotification(hostBuilderContext.Configuration);

                serviceCollection.AddMainWindow();
                serviceCollection.AddMessageDialog();
                serviceCollection.AddExceptionDialog();

                serviceCollection.AddChatHub(hostBuilderContext.Configuration);
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
        ShowNotificationOptions showNotificationOptions = new()
        {
            Title = "Application message",
            Message = "An Internal Server Error has occurred! Please contact your system administrator!",
            NotificationType = NotificationType.Error
        };

        await toastNotification.ShowNotificationAsync(showNotificationOptions);
    }

    private async void ShowExceptionDialog(Exception exception)
    {
        IDialogWindowService dialogWindowService = _host.Services.GetRequiredService<IDialogWindowService>();

        IDialogWindowShowOptions windowShowOptions = new DialogWindowShowOptions<IExceptionDialogWindow, IExceptionDialogWindowViewModel, IExceptionDialogWindowSettingsViewModel>
        {
            WindowSettingsViewModelInitializerModel = new ExceptionDialogWindowSettingsViewModelInitializerModel
            {
                Title = "Unexpected Application Error"
            }
        };

        IPresenterLoadOptions presenterLoadOptions = new PresenterLoadOptions<IExceptionDialogViewModel, IExceptionDialogDataViewModel>
        {
            PresenterDataViewModelInitializerModel = new ExceptionDialogDataViewModelInitializerModel
            {
                Message = exception.Message,
                Type = exception.GetType(),
                StackTrace = exception.StackTrace,
                InnerException = exception.InnerException
            }
        };

        await dialogWindowService.ShowDialogAsync<IExceptionDialogResult>(windowShowOptions, presenterLoadOptions);
    }

    private async void ShowMainWindow()
    {
        INavigationWindowService navigationWindowService = _host.Services.GetRequiredService<INavigationWindowService>();

        INavigationWindowShowOptions windowShowOptions = new NavigationWindowShowOptions<IMainWindow, IMainWindowViewModel, IMainWindowSettingsViewModel>
        {
            WindowSettingsViewModelInitializerModel = new MainWindowSettingsViewModelInitializerModel
            {
                Title = "SullyTech - SignalR Chat Example",
                Height = 750,
                Width = 450
            }
        };

        IPresenterLoadOptions presenterLoadOptions = new PresenterLoadOptions<ISignInViewModel, ISignInDataViewModel>();

        await navigationWindowService.ShowAsync(windowShowOptions, presenterLoadOptions);
    }
}