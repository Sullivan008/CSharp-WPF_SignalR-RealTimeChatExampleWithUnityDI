using SullyTech.Wpf.Windows.Core.Window.ViewModels.Initializers.Window.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Interfaces.NavigationWindow;

namespace SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindow.Interfaces;

public interface INavigationWindowViewModelInitializer<in TINavigationWindowViewModel, in TINavigationWindowViewModelInitializerModel> :
    IWindowViewModelInitializer<TINavigationWindowViewModel, TINavigationWindowViewModelInitializerModel>
        where TINavigationWindowViewModel : INavigationWindowViewModel
        where TINavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
{ }