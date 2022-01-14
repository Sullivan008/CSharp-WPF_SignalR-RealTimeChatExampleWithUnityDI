using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.InitializerModels.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Interfaces.Markers;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.Interfaces;

public interface IPageViewModelInitializer<in TPageViewModel, in TPageViewModelInitializerModel> where TPageViewModel : IPageViewModel
                                                                                                 where TPageViewModelInitializerModel : IPageViewModelInitializerModel
{
    public void Initialize(TPageViewModel pageViewModel, TPageViewModelInitializerModel pageViewModelInitializerModel);
}