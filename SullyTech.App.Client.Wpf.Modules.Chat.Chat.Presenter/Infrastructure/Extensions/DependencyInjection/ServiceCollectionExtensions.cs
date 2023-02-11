using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddChatPresenter(this IServiceCollection @this)
    {
        @this.AddChatViewModel();

        @this.AddChatDataViewModel();
    }
}