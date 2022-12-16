using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.NavigateToOptions.Interfacess;

namespace SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.NavigateToOptions;

public sealed class NavigateToOptions<TPresenterViewModel> : INavigateToOptions
    where TPresenterViewModel : IPresenterViewModel
{
    Type INavigateToOptions.PresenterViewModelType => typeof(TPresenterViewModel);

    IPresenterViewModelInitializerModel? INavigateToOptions.PresenterViewModelInitializerModel => PresenterViewModelInitializerModel;

    IPresenterDataViewModelInitializerModel? INavigateToOptions.PresenterDataViewModelInitializerModel => PresenterDataViewModelInitializerModel;

    public IPresenterViewModelInitializerModel? PresenterViewModelInitializerModel { get; init; }

    public IPresenterDataViewModelInitializerModel? PresenterDataViewModelInitializerModel { get; init; }
}