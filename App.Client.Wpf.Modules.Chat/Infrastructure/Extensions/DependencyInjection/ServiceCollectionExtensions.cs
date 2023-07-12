using App.Client.Wpf.Modules.Chat.Presenter.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Chat.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddChatModule(this IServiceCollection @this)
    {
        @this.AddChatModulePresenters();
    }
}