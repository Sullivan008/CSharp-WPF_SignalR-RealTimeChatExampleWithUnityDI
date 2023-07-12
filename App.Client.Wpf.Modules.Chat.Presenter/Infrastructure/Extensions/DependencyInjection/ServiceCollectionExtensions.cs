using App.Client.Wpf.Modules.Chat.Presenter.Chat.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Chat.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddChatModulePresenters(this IServiceCollection @this)
    {
        @this.AddChatPresenter();
    }
}