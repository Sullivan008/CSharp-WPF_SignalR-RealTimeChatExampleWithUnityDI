using Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Options.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Options;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Interfaces;

public interface INavigationWindowService
{
    public Task ShowAsync(INavigationWindowOptionsModel navigationWindowOptions, IViewNavigationOptions viewNavigationOptions);
}