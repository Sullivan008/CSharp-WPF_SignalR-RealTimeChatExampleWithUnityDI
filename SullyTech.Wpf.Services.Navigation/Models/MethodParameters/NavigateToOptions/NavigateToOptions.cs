using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Services.Navigation.Models.MethodParameters.NavigateToOptions.Interfaces;

namespace SullyTech.Wpf.Services.Navigation.Models.MethodParameters.NavigateToOptions;

public sealed class NavigateToOptions<TIPresenter, TIPresenterViewModel, TIPresenterDataViewModel> : INavigateToOptions
    where TIPresenter : IPresenter
    where TIPresenterViewModel : IPresenterViewModel
    where TIPresenterDataViewModel : IPresenterDataViewModel
{
    Type INavigateToOptions.PresenterType => typeof(TIPresenter);

    Type INavigateToOptions.PresenterViewModelType => typeof(TIPresenterViewModel);

    Type INavigateToOptions.PresenterDataViewModelType => typeof(TIPresenterDataViewModel);

    Type? INavigateToOptions.PresenterViewModelInitializerModelType =>
        PresenterViewModelInitializerModel?.GetType()
            .GetInterfaces()
            .Single(x => !x.IsClass &&
                         x.IsInterface &&
                         x.IsAssignableTo(typeof(IPresenterViewModelInitializerModel)) &&
                         x != typeof(IPresenterViewModelInitializerModel));

    Type? INavigateToOptions.PresenterDataViewModelInitializerModelType =>
        PresenterDataViewModelInitializerModel?.GetType()
            .GetInterfaces()
            .Single(x => !x.IsClass &&
                         x.IsInterface &&
                         x.IsAssignableTo(typeof(IPresenterDataViewModelInitializerModel)) &&
                         x != typeof(IPresenterDataViewModelInitializerModel));

    IPresenterViewModelInitializerModel? INavigateToOptions.PresenterViewModelInitializerModel => PresenterViewModelInitializerModel;

    IPresenterDataViewModelInitializerModel? INavigateToOptions.PresenterDataViewModelInitializerModel => PresenterDataViewModelInitializerModel;

    public IPresenterViewModelInitializerModel? PresenterViewModelInitializerModel { get; init; }

    public IPresenterDataViewModelInitializerModel? PresenterDataViewModelInitializerModel { get; init; }
}