using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowViewModelInitializer<TIDialogWindowViewModel, TIDialogWindowViewModelInitializerModel>(this IServiceCollection @this)
        where TIDialogWindowViewModel : IDialogWindowViewModel
        where TIDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
    {
        Type implementationInterfaceType = 
            typeof(IDialogWindowViewModelInitializer<TIDialogWindowViewModel, TIDialogWindowViewModelInitializerModel>);

        Type implementationType = Assembly.GetCallingAssembly().DefinedTypes.Where(x => x.IsClass)
                                                                            .Where(x => !x.IsAbstract)
                                                                            .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);
    }
}