using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.InitializerModels.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Initializers.Abstractions.Models;
using Application.Client.Windows.Windows.ApplicationWindow.Abstractions.Options;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Abstractions.Options;

public class NavigationWindowOptions<TNavigationWindowViewModelInitializerModel> : ApplicationWindowOptions<TNavigationWindowViewModelInitializerModel>
    where TNavigationWindowViewModelInitializerModel : BaseNavigationWindowViewModelInitializerModel
{ }

public class NavigationWindowOptions<TNavigationWindowViewModelInitializerModel, TPageViewModelInitializerModel> : ApplicationWindowOptions<TNavigationWindowViewModelInitializerModel>
    where TNavigationWindowViewModelInitializerModel : BaseNavigationWindowViewModelInitializerModel
    where TPageViewModelInitializerModel : IPageViewModelInitializerModel
{
    private readonly Func<TPageViewModelInitializerModel>? _pageViewModelInitializerModelFactory;
    public Func<TPageViewModelInitializerModel> PageViewModelInitializerFactory
    {
        get
        {
            Guard.ThrowIfNull(_pageViewModelInitializerModelFactory, nameof(PageViewModelInitializerFactory));

            return _pageViewModelInitializerModelFactory;
        }

        init => _pageViewModelInitializerModelFactory = value;
    }
}