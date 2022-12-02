using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Services.CurrentWindow.Interfaces;

namespace SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenterViewModel<TPresenterViewModel>(this IServiceCollection @this,
        Func<IServiceProvider, Func<IPresenterDataViewModel, ICurrentWindowService, TPresenterViewModel>> implementationFactory)
            where TPresenterViewModel : IPresenterViewModel
    {
        @this.AddTransient(implementationFactory);
    }
}