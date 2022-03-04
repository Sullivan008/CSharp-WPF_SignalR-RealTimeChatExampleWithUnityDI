using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.Services.WindowService.Abstractions;
using Application.Client.Windows.NavigationWindow.Core.Services.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.Services.NavigationWindow.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.Window.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Core.Services.NavigationWindow;

public class NavigationWindowService : WindowService, INavigationWindowService
{
    public NavigationWindowService(IServiceProvider serviceProvider, IContentPresenterService contentPresenterService) : base(serviceProvider, contentPresenterService)
    { }

    public async Task ShowAsync(INavigationWindowShowOptionsModel navigationWindowOptions, IContentPresenterLoadOptions contentPresenterLoadOptions)
    {
        INavigationWindow navigationWindow = (INavigationWindow)CreateWindow(navigationWindowOptions.WindowType);

        INavigationWindowViewModel navigationWindowViewModel = (INavigationWindowViewModel)CreateWindowViewModel(navigationWindowOptions.WindowViewModelType);
        InitializeWindowViewModel(navigationWindowViewModel, navigationWindowOptions.WindowViewModelInitializerModel);

        ICurrentNavigationWindowService currentNavigationWindowService = (ICurrentNavigationWindowService)CreateCurrentWindowService(navigationWindow);
        LoadContentPresenter(contentPresenterLoadOptions, currentNavigationWindowService, navigationWindowViewModel);

        SetWindowDataContext(navigationWindow, navigationWindowViewModel);

        navigationWindow.Show();

        await Task.CompletedTask;
    }

    protected override Type CurrentWindowServiceType => typeof(ICurrentNavigationWindowService);

    protected override Type WindowViewModelInitializerGenericType => typeof(INavigationWindowViewModelInitializer<,>);
}