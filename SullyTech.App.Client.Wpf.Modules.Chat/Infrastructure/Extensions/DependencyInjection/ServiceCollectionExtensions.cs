using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Modules.Chat.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddChatModule(this IServiceCollection @this)
    {
        @this.AddChatPresenter();
    }
}