using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;

public interface IPresenterLoadOptions
{
    public Type PresenterType { get; }

    public Type PresenterViewModelType { get; }

    public Type PresenterDataViewModelType { get; }

    public Type? PresenterViewModelInitializerModelType { get; }

    public Type? PresenterDataViewModelInitializerModelType { get; }

    public IPresenterViewModelInitializerModel? PresenterViewModelInitializerModel { get; }

    public IPresenterDataViewModelInitializerModel? PresenterDataViewModelInitializerModel { get; }
}