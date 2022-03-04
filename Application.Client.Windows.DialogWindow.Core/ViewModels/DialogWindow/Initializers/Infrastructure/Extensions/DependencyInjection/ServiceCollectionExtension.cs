using System.Reflection;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDialogWindowViewModelInitializer<TDialogWindowViewModel, TDialogWindowViewModelInitializerModel>(this IServiceCollection @this)
        where TDialogWindowViewModel : IDialogWindowViewModel
        where TDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
    {
        Type implementationInterfaceType = typeof(IDialogWindowViewModelInitializer<TDialogWindowViewModel, TDialogWindowViewModelInitializerModel>);

        Type implementationType = Assembly.GetCallingAssembly().DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);

        return @this;
    }
}