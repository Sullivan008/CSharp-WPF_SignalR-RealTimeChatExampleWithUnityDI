using System.Windows;
using System.Windows.Threading;
using Application.Client.Container;
using Application.Client.Container.Unity;
using Application.Client.Core.Environment.Enums;
using Application.Client.Core.Environment.Services.Interfaces;
using Application.Client.Core.Exceptions.Models;
using Application.Client.Windows.Main;

namespace Application.Client
{
    public partial class App
    {
        private IEnvironmentService _environmentService;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            log4net.Config.XmlConfigurator.Configure();

            Bootstrapper.Init();

            _environmentService = DependencyInjector.Retrieve<IEnvironmentService>();

            DependencyInjector.Retrieve<MainWindow>().Show();
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Current.DispatcherUnhandledException += AppDispatcherUnhandledException;
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            EnvironmentType environmentType = _environmentService.GetEnvironmentType();
            ErrorModel errorModel = new ErrorModel(environmentType, e.Exception);

            ShowUnhandledException(errorModel);

            e.Handled = true;
        }

        private static void ShowUnhandledException(ErrorModel errorModel)
        {
            string errorMessage = $"An application error occured.\n\n{errorModel.Message}.\n\n{errorModel.Exception}";

            if (MessageBox.Show(errorMessage, "Application Error", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
            {
                Current.Shutdown();
            }
        }
    }
}
