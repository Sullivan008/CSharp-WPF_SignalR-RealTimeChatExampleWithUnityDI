using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Application.Client.Cache.Infrastructure.Interfaces;
using Application.Client.Dialogs.MessageDialog.Extensions.DependencyInjection;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Models;
using Application.Client.Infrastructure.Environment.Enums;
using Application.Client.Infrastructure.ErrorHandling.DataBinding.TraceListeners;
using Application.Client.Infrastructure.ErrorHandling.Models;
using Application.Client.SignalR.Hub.ChatHub.Extensions.DependencyInjection;
using Application.Client.SignalR.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models;
using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models.Interfaces;
using Application.Client.Windows.Implementations.Main.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Implementations.Main.Window;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models.Interfaces;
using Application.Common.Cache.Infrastructure.Repository.Extensions.DependencyInjection;
using Application.Common.Cache.Infrastructure.Services.Extensions.DependencyInjection;
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

    protected override async void OnStartup(StartupEventArgs eventArgs)
    {
        await _host.StartAsync();

        ConfigureDataBindingErrorListener();

        Current.DispatcherUnhandledException += AppDispatcherUnhandledException;

        INavigationWindowService navigationWindowService = _host.Services.GetRequiredService<INavigationWindowService>();

        INavigationWindowOptionsModel windowOptions = new NavigationWindowOptionsModel<MainWindow, MainWindowViewModel, MainWindowViewModelInitializerModel>
        {
            WindowViewModelInitializerModel = new MainWindowViewModelInitializerModel
            {
                WindowSettings = new MainWindowSettingsViewModelInitializerModel
                {
                    Title = "Test Title"
                }
            }
        };

        //MainWindowOptions otpions = new()
        //{

        //    WindowViewModelInitializerModelFactory = () => new MainWindowViewModelInitializerModel
        //    {
        //        WindowSettings = new MainWindowSettingsViewModelInitializerModel { Title = "Test Title" }
        //    }
        //};

        //SignInPageViewOptions pageViewOptions = new()
        //{
        //    PageViewModelInitializerFactory = () => new SignInViewModelInitializerModel
        //    {
        //        ViewDataInitializerModel = new SignInViewDataViewModelInitializerModel { Content = "It's from view initializer" }
        //    }
        //};

        //ViewNavigationOptions = new SignInPageViewOptions
        //{
        //    PageViewModelInitializerFactory = () => new SignInViewModelInitializerModel
        //    {
        //        ViewDataInitializerModel = new SignInViewDataViewModelInitializerModel { Content = "It's from window initializer!" }
        //    }
        //}

        IPageViewNavigationOptions options = new PageViewNavigationOptions<SignInViewModel, SignInViewModelInitializerModel>
        {
            PageViewModelInitializerFactory = () => new SignInViewModelInitializerModel
            {
                ViewDataInitializerModel = new SignInViewDataViewModelInitializerModel { Content = "It's from view initializer" }
            }
        };

        await navigationWindowService.ShowAsync(windowOptions, options);

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
        serviceCollection.AddNavigationWindowService();
        serviceCollection.AddPageViewNavigationService();

        serviceCollection.AddMainWindow();

        serviceCollection.AddMemoryCache();
        serviceCollection.AddCacheServices();
        serviceCollection.AddCacheRepositories(Assembly.GetAssembly(typeof(IAssemblyMarker))!);

        serviceCollection.AddHubConfigurations(configuration);
        serviceCollection.AddChatHub();

        //serviceCollection.AddDDialog();
        //serviceCollection.AddApplicationWindowService();

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
        ILogger<App> logger = _host.Services.GetRequiredService<ILogger<App>>();

        logger.LogError(eventArgs.Exception, eventArgs.Exception.Message);

        ErrorModel errorModel = new()
        {
            Message = eventArgs.Exception.Message,
            Exception = eventArgs.Exception.ToString()
        };

        ShowUnhandledException(errorModel);

        eventArgs.Handled = true;
    }

    private async void ShowUnhandledException(ErrorModel errorModel)
    {
        IMessageDialog messageDialog = _host.Services.GetRequiredService<IMessageDialog>();

        await messageDialog.ShowDialogAsync(new MessageDialogOptions
        {
            Content = BuildMessageContent(errorModel),
            Title = "Application Error",
            Button = MessageBoxButton.OK,
            Icon = MessageBoxImage.Error
        });

        Current.Shutdown();
    }

    private string BuildMessageContent(ErrorModel errorModel)
    {
        IHostEnvironment hostEnvironment = _host.Services.GetRequiredService<IHostEnvironment>();

        const string defaultMessage = "An application error occurred.\n\n";

        if (hostEnvironment.IsDevelopment())
        {
            return $"{defaultMessage}{errorModel.Message}\n\n{errorModel.Exception}";
        }

        return $"{defaultMessage}Exception available only in development envrionment.";
    }
}