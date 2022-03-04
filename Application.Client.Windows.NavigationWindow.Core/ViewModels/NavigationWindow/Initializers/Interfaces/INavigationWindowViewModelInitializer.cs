using Application.Client.Windows.Core.ViewModels.Window.Initializer.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Initializers.Interfaces;

public interface INavigationWindowViewModelInitializer<in TNavigationWindowViewModel, in TNavigationWindowViewModelInitializerModel> :
    IWindowViewModelInitializer<TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel> 
        where TNavigationWindowViewModel : INavigationWindowViewModel
        where TNavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
{ }