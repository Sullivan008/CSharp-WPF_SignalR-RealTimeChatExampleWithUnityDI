using App.Client.Wpf.Windows.Main.UserControls.Infrastructure.Extensions.DependencyInjection;
using App.Client.Wpf.Windows.Main.ViewModels.Infrastructure.Extensions.DependencyInjection;
using App.Client.Wpf.Windows.Main.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Windows.Main.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindow(this IServiceCollection @this)
    {
        @this.AddMainWindowWindowUserControl();
        @this.AddMainWindowViewModel();
        @this.AddMainWindowViewModelMappingProfile();
    }
}