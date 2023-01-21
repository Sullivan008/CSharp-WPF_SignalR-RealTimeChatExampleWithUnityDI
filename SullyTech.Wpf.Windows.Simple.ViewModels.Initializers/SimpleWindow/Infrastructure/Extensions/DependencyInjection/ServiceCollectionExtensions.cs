using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindow.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindow;

namespace SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleWindowViewModelInitializer<TSimpleWindowViewModel, TSimpleWindowViewModelInitializerModel,
        TISimpleWindowViewModelInitializer, TSimpleWindowViewModelInitializer>(this IServiceCollection @this)
            where TSimpleWindowViewModel : ISimpleWindowViewModel
            where TSimpleWindowViewModelInitializerModel : ISimpleWindowViewModelInitializerModel
            where TISimpleWindowViewModelInitializer : ISimpleWindowViewModelInitializer<TSimpleWindowViewModel, TSimpleWindowViewModelInitializerModel>
            where TSimpleWindowViewModelInitializer : TISimpleWindowViewModelInitializer
    {
        @this.AddScoped(typeof(TISimpleWindowViewModelInitializer), typeof(TSimpleWindowViewModelInitializer));
    }
}