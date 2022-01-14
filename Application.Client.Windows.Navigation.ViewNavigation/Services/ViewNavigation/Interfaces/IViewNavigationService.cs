using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.InitializerModels.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Interfaces.Markers;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;

public interface IViewNavigationService
{
    public void Navigate<TPageViewModel>() where TPageViewModel : IPageViewModel;

    public void Navigate<TPageViewModel, TPageViewModelInitializerModel>(Func<TPageViewModelInitializerModel> pageViewModelInitializerFactory) where TPageViewModel : IPageViewModel
                                                                                                                                               where TPageViewModelInitializerModel : IPageViewModelInitializerModel;
}