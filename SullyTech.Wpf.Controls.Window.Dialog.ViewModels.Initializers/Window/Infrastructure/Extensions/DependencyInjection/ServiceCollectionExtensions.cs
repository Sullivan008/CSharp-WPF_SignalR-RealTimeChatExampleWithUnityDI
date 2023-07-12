using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowViewModelInitializer<TIDialogWindowViewModel, TIDialogWindowViewModelInitializerModel,
        TIDialogWindowViewModelInitializer, TDialogWindowViewModelInitializer>(this IServiceCollection @this)
            where TIDialogWindowViewModel : IDialogWindowViewModel
            where TIDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
            where TIDialogWindowViewModelInitializer : IDialogWindowViewModelInitializer<TIDialogWindowViewModel, TIDialogWindowViewModelInitializerModel>
            where TDialogWindowViewModelInitializer : TIDialogWindowViewModelInitializer
    {
        @this.AddScoped(typeof(TIDialogWindowViewModelInitializer), typeof(TDialogWindowViewModelInitializer));
    }
}