using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindow;

namespace SullyTech.Wpf.Windows.Simple.ViewModels.SimpleWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleWindowViewModel<TSimpleWindowViewModel>(this IServiceCollection @this)
        where TSimpleWindowViewModel : ISimpleWindowViewModel
    {
        @this.AddTransient(typeof(TSimpleWindowViewModel));
    }
}