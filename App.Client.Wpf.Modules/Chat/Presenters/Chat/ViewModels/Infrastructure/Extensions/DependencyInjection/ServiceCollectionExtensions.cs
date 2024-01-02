using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Chat.Presenters.Chat.ViewModels.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddChatPresenterViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<ChatPresenterViewModel>();
    }
}