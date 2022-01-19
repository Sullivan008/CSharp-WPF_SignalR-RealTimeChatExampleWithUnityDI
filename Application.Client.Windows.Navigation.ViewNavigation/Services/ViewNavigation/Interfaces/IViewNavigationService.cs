using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Options;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;

public interface IViewNavigationService
{
    public void Navigate(IViewNavigationOptions viewNavigationOptions);
}