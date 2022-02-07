using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ApplicationWindow.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationWindow<TApplicationWindow, TApplicationWindowViewModel>(this IServiceCollection @this) where TApplicationWindow : IApplicationWindow
                                                                                                                                          where TApplicationWindowViewModel : IApplicationWindowViewModel
    {
        @this.AddTransient(typeof(TApplicationWindow), _ =>
        {
            TApplicationWindow applicationWindow = Activator.CreateInstance<TApplicationWindow>();

            IApplicationWindowViewModel applicationWindowViewModel = Activator.CreateInstance<TApplicationWindowViewModel>();
            applicationWindow.DataContext = applicationWindowViewModel;

            return applicationWindow;
        });

        return @this;
    }
}