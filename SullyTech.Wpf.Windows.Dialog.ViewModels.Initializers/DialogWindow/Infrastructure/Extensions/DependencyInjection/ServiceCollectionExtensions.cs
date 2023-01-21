using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Infrastructure.Extensions.DependencyInjection;

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