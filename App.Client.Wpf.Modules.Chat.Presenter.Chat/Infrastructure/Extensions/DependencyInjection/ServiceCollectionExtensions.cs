using App.Client.Wpf.Modules.Chat.Presenter.Chat.Interfaces;
using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Chat.Presenter.Chat.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddChatPresenter(this IServiceCollection @this)
    {
        @this.AddPresenter<IChatPresenter, ChatPresenter>();

        @this.AddChatPresenterViewModel();
        @this.AddChatPresenterDataViewModel();
    }
}