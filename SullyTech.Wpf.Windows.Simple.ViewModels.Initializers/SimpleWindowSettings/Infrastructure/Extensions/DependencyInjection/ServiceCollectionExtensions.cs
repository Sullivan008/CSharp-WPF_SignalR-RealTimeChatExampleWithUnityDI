using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindowSettings;

namespace SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleWindowSettingsViewModelInitializer<TISimpleWindowSettingsViewModel, TISimpleWindowSettingsViewModelInitializerModel,
        TISimpleWindowSettingsViewModelInitializer, TSimpleWindowSettingsViewModelInitializer>(this IServiceCollection @this)
            where TISimpleWindowSettingsViewModel : ISimpleWindowSettingsViewModel
            where TISimpleWindowSettingsViewModelInitializerModel : ISimpleWindowSettingsViewModelInitializerModel
            where TISimpleWindowSettingsViewModelInitializer : ISimpleWindowSettingsViewModelInitializer<TISimpleWindowSettingsViewModel, TISimpleWindowSettingsViewModelInitializerModel>
            where TSimpleWindowSettingsViewModelInitializer : TISimpleWindowSettingsViewModelInitializer
    {
        @this.AddScoped(typeof(TISimpleWindowSettingsViewModelInitializer), typeof(TSimpleWindowSettingsViewModelInitializer));
    }
}