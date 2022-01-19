using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Initializers.Models.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Interfaces;

namespace Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Initializers.Interfaces;

public interface IPageViewViewModelInitializer<in TPageViewViewModel, in TPageViewViewModelInitializerModel> where TPageViewViewModel : IPageViewViewModel
                                                                                                             where TPageViewViewModelInitializerModel : IPageViewViewModelInitializerModel
{
    public void Initialize(TPageViewViewModel pageViewViewModel, TPageViewViewModelInitializerModel pageViewViewModelInitializerModel);
}