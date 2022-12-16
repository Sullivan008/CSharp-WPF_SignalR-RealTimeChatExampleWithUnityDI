using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindowSettings;

namespace SullyTech.Wpf.Windows.Simple.ViewModels.SimpleWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleWindowSettingsViewModel<TSimpleWindowSettingsViewModel>(this IServiceCollection @this)
        where TSimpleWindowSettingsViewModel : ISimpleWindowSettingsViewModel
    {
        @this.AddTransient(typeof(TSimpleWindowSettingsViewModel));
    }
}