using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.Window.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindow;

namespace SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindow.Interfaces;

public interface INavigationWindowViewModelInitializer<in TNavigationWindowViewModel, in TNavigationWindowViewModelInitializerModel> :
    IWindowViewModelInitializer<TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel>
        where TNavigationWindowViewModel : INavigationWindowViewModel
        where TNavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
{ }