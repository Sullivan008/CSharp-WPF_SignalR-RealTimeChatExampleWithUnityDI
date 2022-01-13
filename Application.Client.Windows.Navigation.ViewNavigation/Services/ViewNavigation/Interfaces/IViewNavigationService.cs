using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Abstractions.Models;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;

public interface IViewNavigationService
{
    public void Navigate<TPageViewModel>() where TPageViewModel : PageViewModelBase;

    public void Navigate<TPageViewModel, TPageViewModelInitializer>(Func<TPageViewModelInitializer> pageViewModelInitializerFactory) where TPageViewModel : PageViewModelBase
                                                                                                                                     where TPageViewModelInitializer : BasePageViewModelInitializerModel;
}