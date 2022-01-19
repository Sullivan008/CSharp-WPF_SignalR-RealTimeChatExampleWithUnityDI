using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Initializers.Models.Interfaces;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Options;

public class ViewNavigationOptions<TPageViewViewModelInitializerModel> : IViewNavigationOptions where TPageViewViewModelInitializerModel : IPageViewViewModelInitializerModel
{
    private readonly Func<TPageViewViewModelInitializerModel>? _pageViewModelInitializerModelFactory;
    public Func<TPageViewViewModelInitializerModel> PageViewModelInitializerFactory
    {
        init => _pageViewModelInitializerModelFactory = value;
    }

    private IPageViewViewModelInitializerModel? _pageViewViewModelInitializerModel;
    public IPageViewViewModelInitializerModel? PageViewViewModelInitializerModel
    {
        get
        {
            if (_pageViewModelInitializerModelFactory == null)
            {
                return null;
            }

            if (_pageViewViewModelInitializerModel != null)
            {
                return _pageViewViewModelInitializerModel;
            }

            _pageViewViewModelInitializerModel = _pageViewModelInitializerModelFactory!();

            return _pageViewViewModelInitializerModel;
        }
    }
}

public interface IViewNavigationOptions
{
    public IPageViewViewModelInitializerModel? PageViewViewModelInitializerModel { get; }
}