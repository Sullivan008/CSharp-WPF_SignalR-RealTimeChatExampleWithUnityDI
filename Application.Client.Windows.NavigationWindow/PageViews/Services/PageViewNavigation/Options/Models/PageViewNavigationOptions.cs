using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;

namespace Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models;

public class PageViewNavigationOptions<TPageViewViewModel, TPageViewViewModelInitializerModel> : IPageViewNavigationOptions 

{
    private readonly Func<TPageViewViewModelInitializerModel>? _pageViewModelInitializerModelFactory;
    public Func<TPageViewViewModelInitializerModel> PageViewModelInitializerFactory
    {
        init => _pageViewModelInitializerModelFactory = value;
    }

    public Type PageViewViewModelType => typeof(TPageViewViewModel);
    public Type PageViewViewModelInitializerModelType => typeof(TPageViewViewModelInitializerModel);

    private IPageViewViewModelInitializerModel? _pageViewViewModelInitializerModel;
    public IPageViewViewModelInitializerModel? PageViewViewModelInitializerModel
    {
        get
        {
            if (_pageViewViewModelInitializerModel == null)
            {
                if (_pageViewModelInitializerModelFactory != null)
                {
                    _pageViewViewModelInitializerModel = (IPageViewViewModelInitializerModel?)_pageViewModelInitializerModelFactory();
                }
            }

            return _pageViewViewModelInitializerModel;
        }
    }
}