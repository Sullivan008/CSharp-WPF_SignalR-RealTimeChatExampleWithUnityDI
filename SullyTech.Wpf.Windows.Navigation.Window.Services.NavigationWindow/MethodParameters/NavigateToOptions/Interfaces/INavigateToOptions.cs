using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.MethodParameters.NavigateToOptions.Interfaces;

public interface INavigateToOptions
{
    internal Type PresenterViewModelType { get; }

    internal Type PresenterDataViewModelType { get; }

    internal Type? PresenterViewModelInitializerModelType { get; }

    internal Type? PresenterDataViewModelInitializerModelType { get; }

    internal IPresenterViewModelInitializerModel? PresenterViewModelInitializerModel { get; }

    internal IPresenterDataViewModelInitializerModel? PresenterDataViewModelInitializerModel { get; }
}