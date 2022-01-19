using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Initializers.Models.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Interfaces;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Options;

public class ViewNavigationOptions<TPageViewViewModel, TPageViewViewModelInitializerModel> : IViewNavigationOptions 
    where TPageViewViewModel : IPageViewViewModel
    where TPageViewViewModelInitializerModel : IPageViewViewModelInitializerModel
{
    private readonly Func<TPageViewViewModelInitializerModel>? _pageViewModelInitializerModelFactory;
    public Func<TPageViewViewModelInitializerModel> PageViewModelInitializerFactory
    {
        init => _pageViewModelInitializerModelFactory = value;
    }

    public Type PageViewModelType => typeof(TPageViewViewModel);
    public Type PageViewViewModelInitializerModelType => typeof(TPageViewViewModelInitializerModel);

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
    public Type PageViewModelType { get; }

    public Type PageViewViewModelInitializerModelType { get; }

    public IPageViewViewModelInitializerModel? PageViewViewModelInitializerModel { get; }
}