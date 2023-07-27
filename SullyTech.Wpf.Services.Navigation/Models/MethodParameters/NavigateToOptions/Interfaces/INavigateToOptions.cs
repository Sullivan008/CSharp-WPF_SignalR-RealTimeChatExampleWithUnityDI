using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;

namespace SullyTech.Wpf.Services.Navigation.Models.MethodParameters.NavigateToOptions.Interfaces;

public interface INavigateToOptions
{
    public Type PresenterType { get; }

    internal Type PresenterViewModelType { get; }

    internal Type PresenterDataViewModelType { get; }

    internal Type? PresenterViewModelInitializerModelType { get; }

    internal Type? PresenterDataViewModelInitializerModelType { get; }

    internal IPresenterViewModelInitializerModel? PresenterViewModelInitializerModel { get; }

    internal IPresenterDataViewModelInitializerModel? PresenterDataViewModelInitializerModel { get; }
}