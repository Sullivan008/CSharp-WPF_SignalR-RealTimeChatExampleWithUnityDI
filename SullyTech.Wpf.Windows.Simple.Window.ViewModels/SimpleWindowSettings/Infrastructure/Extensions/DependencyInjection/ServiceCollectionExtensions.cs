using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Interfaces.SimpleWindowSettings;

namespace SullyTech.Wpf.Windows.Simple.Window.ViewModels.SimpleWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleWindowSettingsViewModel<TISimpleWindowSettingsViewModel, TSimpleWindowSettingsViewModel>(this IServiceCollection @this)
        where TSimpleWindowSettingsViewModel : TISimpleWindowSettingsViewModel
        where TISimpleWindowSettingsViewModel : ISimpleWindowSettingsViewModel
    {
        @this.AddTransient(typeof(TISimpleWindowSettingsViewModel), typeof(TSimpleWindowSettingsViewModel));
    }
}