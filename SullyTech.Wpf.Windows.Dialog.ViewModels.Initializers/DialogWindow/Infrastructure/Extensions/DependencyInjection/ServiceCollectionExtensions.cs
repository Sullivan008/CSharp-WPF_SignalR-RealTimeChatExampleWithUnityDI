using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowViewModelInitializer<TDialogWindowViewModel, TDialogWindowViewModelInitializerModel>(this IServiceCollection @this)
        where TDialogWindowViewModel : IDialogWindowViewModel
        where TDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
    {
        Type implementationInterfaceType = 
            typeof(IDialogWindowViewModelInitializer<TDialogWindowViewModel, TDialogWindowViewModelInitializerModel>);

        Type implementationType = Assembly.GetCallingAssembly().DefinedTypes.Where(x => x.IsClass)
                                                                            .Where(x => !x.IsAbstract)
                                                                            .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);
    }
}