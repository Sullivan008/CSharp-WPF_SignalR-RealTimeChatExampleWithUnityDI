using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Interfaces.NavigationWindow;

namespace SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNavigationWindowViewModelInitializer<TINavigationWindowViewModel, TINavigationWindowViewModelInitializerModel,
        TINavigationWindowViewModelInitializer, TNavigationWindowViewModelInitializer>(this IServiceCollection @this)
            where TINavigationWindowViewModel : INavigationWindowViewModel
            where TINavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
            where TINavigationWindowViewModelInitializer : INavigationWindowViewModelInitializer<TINavigationWindowViewModel, TINavigationWindowViewModelInitializerModel>
            where TNavigationWindowViewModelInitializer : TINavigationWindowViewModelInitializer
    {
        @this.AddScoped(typeof(TINavigationWindowViewModelInitializer), typeof(TNavigationWindowViewModelInitializer));
    }
}