using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.WindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddStandardWindowSettingsViewModelInitializer<TIStandardWindowSettingsViewModel, TIStandardWindowSettingsViewModelInitializerModel,
        TIStandardWindowSettingsViewModelInitializer, TStandardWindowSettingsViewModelInitializer>(this IServiceCollection @this)
            where TIStandardWindowSettingsViewModel : IStandardWindowSettingsViewModel
            where TIStandardWindowSettingsViewModelInitializerModel : IStandardWindowSettingsViewModelInitializerModel
            where TIStandardWindowSettingsViewModelInitializer : IStandardWindowSettingsViewModelInitializer<TIStandardWindowSettingsViewModel, TIStandardWindowSettingsViewModelInitializerModel>
            where TStandardWindowSettingsViewModelInitializer : TIStandardWindowSettingsViewModelInitializer
    {
        @this.AddScoped(typeof(TIStandardWindowSettingsViewModelInitializer), typeof(TStandardWindowSettingsViewModelInitializer));
    }
}