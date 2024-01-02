using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Presenter.Core.UserControls.Presenter.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Chat.Presenters.Chat.UserControls.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddChatPresenterUserControl(this IServiceCollection @this)
    {
        @this.AddPresenter<ChatPresenter>();
    }
}