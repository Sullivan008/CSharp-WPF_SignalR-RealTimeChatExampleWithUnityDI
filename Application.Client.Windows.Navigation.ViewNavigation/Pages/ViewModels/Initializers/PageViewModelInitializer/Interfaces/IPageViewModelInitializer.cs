using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Abstractions.Models;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Interfaces;

public interface IPageViewModelInitializer<in TPageViewModel, in TPageViewModelInitializerModel> where TPageViewModel : PageViewModelBase
                                                                                                 where TPageViewModelInitializerModel : BasePageViewModelInitializerModel
{
    public void Initialize(TPageViewModel pageViewModel, TPageViewModelInitializerModel pageViewModelInitializerModel);
}