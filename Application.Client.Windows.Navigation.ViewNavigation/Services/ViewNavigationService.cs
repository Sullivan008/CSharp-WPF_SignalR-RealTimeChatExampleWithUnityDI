using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.Windows;
using Application.Client.Windows.Navigation.ViewNavigation.Initializers.ViewModelInitializers.NavigationWindowPageViewModelInitializer.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Initializers.ViewModelInitializers.NavigationWindowPageViewModelInitializer.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services;

public class ViewNavigationService<TNavigationWindow> : IViewNavigationService<TNavigationWindow> where TNavigationWindow : NavigationWindow
{
    private readonly IServiceProvider _serviceProvider;

    private readonly TNavigationWindow _navigationWindow;

    public ViewNavigationService(IServiceProvider serviceProvider, TNavigationWindow navigationWindow)
    {
        _serviceProvider = serviceProvider;
        _navigationWindow = navigationWindow;
    }

    public void Navigate<TPageViewModelType>() where TPageViewModelType : NavigationWindowPageViewModelBase<TNavigationWindow>
    {
        TPageViewModelType navigationWindowPageViewModel = GetNavigationWindowPageViewModel<TPageViewModelType>();

        ((NavigationWindowViewModelBase<TNavigationWindow>)_navigationWindow.DataContext).CurrentPage = navigationWindowPageViewModel;
    }

    public void Navigate<TPageViewModelType, TPageViewModelInitializer>(Func<TPageViewModelInitializer> pageViewModelInitializer) where TPageViewModelType : NavigationWindowPageViewModelBase<TNavigationWindow>
                                                                                                                                  where TPageViewModelInitializer : BaseNavigationWindowPageViewModelInitializerModel
    {
        TPageViewModelType navigationWindowPageViewModel = GetNavigationWindowPageViewModel<TPageViewModelType>();

        InitializeNavigationWindowPageViewModel(navigationWindowPageViewModel, pageViewModelInitializer);

        ((NavigationWindowViewModelBase<TNavigationWindow>)_navigationWindow.DataContext).CurrentPage = navigationWindowPageViewModel;
    }

    private TPageViewModelType GetNavigationWindowPageViewModel<TPageViewModelType>() where TPageViewModelType : NavigationWindowPageViewModelBase<TNavigationWindow>
    {
        Func<IViewNavigationService<TNavigationWindow>, TPageViewModelType> navigationWindowPageViewModelFactory =
            _serviceProvider.GetRequiredService<Func<IViewNavigationService<TNavigationWindow>, TPageViewModelType>>();

        return navigationWindowPageViewModelFactory(this);
    }

    private void InitializeNavigationWindowPageViewModel<TPageViewModelType, TPageViewModelInitializerModel>(TPageViewModelType navigationWindowPageViewModel,
        Func<TPageViewModelInitializerModel> getPageViewModelInitializerModel) where TPageViewModelType : NavigationWindowPageViewModelBase<TNavigationWindow> 
                                                                               where TPageViewModelInitializerModel : BaseNavigationWindowPageViewModelInitializerModel
    {
        INavigationWindowPageViewModelInitializer<TNavigationWindow, TPageViewModelType, TPageViewModelInitializerModel> navigationWindowPageViewModelInitializer =
            _serviceProvider.GetRequiredService<INavigationWindowPageViewModelInitializer<TNavigationWindow, TPageViewModelType, TPageViewModelInitializerModel>>();

        TPageViewModelInitializerModel pageViewModelInitializerModel = getPageViewModelInitializerModel();

        navigationWindowPageViewModelInitializer.Initialize(navigationWindowPageViewModel, pageViewModelInitializerModel);
    }
}