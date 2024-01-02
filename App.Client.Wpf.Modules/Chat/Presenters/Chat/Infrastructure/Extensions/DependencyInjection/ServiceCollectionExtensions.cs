using App.Client.Wpf.Modules.Chat.Presenters.Chat.UserControls.Infrastructure.Extensions.DependencyInjection;
using App.Client.Wpf.Modules.Chat.Presenters.Chat.ViewModels.Infrastructure.Extensions.DependencyInjection;
using App.Client.Wpf.Modules.Chat.Presenters.Chat.ViewModels.Validators.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Chat.Presenters.Chat.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddChatPresenter(this IServiceCollection @this)
    {
        @this.AddChatPresenterUserControl();
        @this.AddChatPresenterViewModel();
        @this.AddChatPresenterViewModelValidator();
    }
}