using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddStandardWindowViewModelInitializer<TIStandardWindowViewModel, TIStandardWindowViewModelInitializerModel,
        TIStandardWindowViewModelInitializer, TStandardWindowViewModelInitializer>(this IServiceCollection @this)
            where TIStandardWindowViewModel : IStandardWindowViewModel
            where TIStandardWindowViewModelInitializerModel : IStandardWindowViewModelInitializerModel
            where TIStandardWindowViewModelInitializer : IStandardWindowViewModelInitializer<TIStandardWindowViewModel, TIStandardWindowViewModelInitializerModel>
            where TStandardWindowViewModelInitializer : TIStandardWindowViewModelInitializer
    {
        @this.AddScoped(typeof(TIStandardWindowViewModelInitializer), typeof(TStandardWindowViewModelInitializer));
    }
}