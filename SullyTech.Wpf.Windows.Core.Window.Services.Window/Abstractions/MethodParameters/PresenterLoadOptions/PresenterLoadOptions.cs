using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;

namespace SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions;

public sealed class PresenterLoadOptions<TIPresenterViewModel, TIPresenterDataViewModel> : IPresenterLoadOptions
    where TIPresenterViewModel : IPresenterViewModel
    where TIPresenterDataViewModel : IPresenterDataViewModel
{
    public Type PresenterViewModelType => typeof(TIPresenterViewModel);

    public Type PresenterDataViewModelType => typeof(TIPresenterDataViewModel);

    public Type? PresenterViewModelInitializerModelType => 
        PresenterViewModelInitializerModel?.GetType()
                                           .GetInterfaces()
                                           .Single(x => !x.IsClass &&
                                                        x.IsInterface &&
                                                        x.IsAssignableTo(typeof(IPresenterViewModelInitializerModel)) &&
                                                        x != typeof(IPresenterViewModelInitializerModel));

    public Type? PresenterDataViewModelInitializerModelType =>
        PresenterDataViewModelInitializerModel?.GetType()
                                               .GetInterfaces()
                                               .Single(x => !x.IsClass &&
                                                            x.IsInterface &&
                                                            x.IsAssignableTo(typeof(IPresenterDataViewModelInitializerModel)) &&
                                                            x != typeof(IPresenterDataViewModelInitializerModel));

    public IPresenterViewModelInitializerModel? PresenterViewModelInitializerModel { get; init; }

    public IPresenterDataViewModelInitializerModel? PresenterDataViewModelInitializerModel { get; init; }
}