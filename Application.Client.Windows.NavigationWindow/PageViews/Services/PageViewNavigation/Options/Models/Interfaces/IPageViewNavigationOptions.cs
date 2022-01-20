using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Initializers.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;

public interface IPageViewNavigationOptions
{
    public Type PageViewViewModelType { get; }

    public Type PageViewViewModelInitializerModelType { get; }

    public IPageViewViewModelInitializerModel? PageViewViewModelInitializerModel { get; }
}