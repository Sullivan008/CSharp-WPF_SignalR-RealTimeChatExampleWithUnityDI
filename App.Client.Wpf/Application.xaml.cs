using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using App.Client.SignalR.Hubs.Chat.Extensions.DependencyInjection;
using App.Client.SignalR.Hubs.Chat.Extensions.Hosting;
using App.Client.Wpf.Modules.Chat.Infrastructure.Extensions.DependencyInjection;
using App.Client.Wpf.Modules.Identity.Infrastructure.Extensions.DependencyInjection;
using App.Client.Wpf.Windows.Main.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SullyTech.Wpf.Controls.Window.Core.Providers.Window.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Service.ExceptionDialog.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializer.Models.PresenterData;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializer.Models.WindowSettings;
using SullyTech.Wpf.Dialogs.Message.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Services.MessageDialog.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Enums.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.PresenterData;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializer.Models.WindowSettings;
using SullyTech.Wpf.Notifications.Toast.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;
using SullyTech.Wpf.Services.Navigation.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Services.Window.Closer.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Services.Window.Destroyer.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Services.Window.Title.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.TraceListeners.BindingError;

namespace App.Client.Wpf;

public partial class Application
{
    private readonly IHost _host;

    public Application()
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
                serviceCollection.AddWindowProvider();

                serviceCollection.AddWindowSettingsViewModelMappingProfile();
                serviceCollection.AddDialogWindowSettingsViewModelMappingProfile();
                serviceCollection.AddStandardWindowSettingsViewModelMappingProfile();

                serviceCollection.AddStandardWindowService();
                serviceCollection.AddDialogWindowService();

                serviceCollection.AddNavigationService();
                serviceCollection.AddWindowTitleService();
                serviceCollection.AddWindowCloserService();
                serviceCollection.AddWindowDestroyerService();

                serviceCollection.AddToastNotification(hostBuilderContext.Configuration);

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

        //if (eventArgs.Exception is HubException)
        //{
        //    ShowHubExceptionNotification();
        //}
        //else
        //{
        ShowExceptionDialog(eventArgs.Exception);

        Current.Shutdown();
        //}

        //eventArgs.Handled = true;
    }

    private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs eventArgs)
    {
        Current.Dispatcher.BeginInvoke(() =>
        {
            LogUnhandledException(eventArgs.Exception);

            //if (eventArgs.Exception.InnerExceptions.Any())
            //{
            Exception exception = eventArgs.Exception.InnerExceptions.First();

            //if (exception is HubException)
            //{
            //    ShowHubExceptionNotification();
            //}
            //else
            //{
            ShowExceptionDialog(eventArgs.Exception);

            Current.Shutdown();
            //    }
            //}
            //else
            //{
            //    ShowExceptionDialog(eventArgs.Exception);

            //    Current.Shutdown();
            //}
        });
    }

    private void LogUnhandledException(Exception exception)
    {
        ILogger<Application> logger = _host.Services.GetRequiredService<ILogger<Application>>();
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
            presenterDataViewModelInitializerModel: new ExceptionDialogPresenterDataViewModelInitializerModel
            {
                Message = exception.Message,
                Type = exception.GetType(),
                StackTrace = exception.StackTrace,
                InnerException = exception.InnerException
            });
    }

    private async void ShowMainWindow()
    {
        //IMainWindowService mainWindowService = _host.Services.GetRequiredService<IMainWindowService>();

        //await mainWindowService.ShowAsync(
        //    presenterLoadOptions: new PresenterLoadOptions<ISignInPresenter, ISignInPresenterViewModel, ISignInPresenterDataViewModel>(),
        //    windowSettingsViewModelInitializerModel: new MainWindowSettingsViewModelInitializerModel
        //    {
        //        Title = "SullyTech - Chat Application",
        //        Width = 450,
        //        Height = 750
        //    });

        //IMessageDialogService sd = _host.Services.GetRequiredService<IMessageDialogService>();

        //await sd.ShowDialogAsync(
        //    windowSettingsViewModelInitializerModel: new MessageDialogWindowSettingsViewModelInitializerModel
        //    {
        //        Title = "kefe",
        //    },
        //    presenterDataViewModelInitializerModel: new MessageDialogPresenterDataViewModelInitializerModel
        //    {
        //        Message = "tere"
        //    },
        //    presenterViewModelInitializerModel: new MessageDialogPresenterViewModelInitializerModel
        //    {
        //        ButtonType = ButtonType.OkCancel,
        //        IconType = IconType.Information
        //    });

        IExceptionDialogService ere = _host.Services.GetRequiredService<IExceptionDialogService>();
        await ere.ShowDialogAsync(new ExceptionDialogWindowSettingsViewModelInitializerModel
        {
            Title = "a",
            Width = 50000,
            Height = 150000
        },
            new ExceptionDialogPresenterDataViewModelInitializerModel
            {
                InnerException = new Exception("e"),
                Message = "re",
                StackTrace = "ke",
                Type = ere.GetType()
            });
    }
}