using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Options;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;

public interface IViewNavigationService
{
    public void Navigate<TPageViewModel>(IViewNavigationOptions viewNavigationOptions) where TPageViewModel : IPageViewViewModel;
}