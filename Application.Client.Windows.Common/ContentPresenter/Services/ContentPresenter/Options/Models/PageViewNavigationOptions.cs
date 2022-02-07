using Application.Client.Windows.Common.ContentPresenter.Services.ContentPresenter.Options.Models.Interfaces;

namespace Application.Client.Windows.Common.ContentPresenter.Services.ContentPresenter.Options.Models;

public class PageViewNavigationOptions<TPageViewViewModel, TPageViewViewModelInitializerModel> : IPageViewNavigationOptions 
    where TPageViewViewModel : IPageViewViewModel
    where TPageViewViewModelInitializerModel : IPageViewViewModelInitializerModel
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
                    _pageViewViewModelInitializerModel = _pageViewModelInitializerModelFactory();
                }
            }

            return _pageViewViewModelInitializerModel;
        }
    }
}