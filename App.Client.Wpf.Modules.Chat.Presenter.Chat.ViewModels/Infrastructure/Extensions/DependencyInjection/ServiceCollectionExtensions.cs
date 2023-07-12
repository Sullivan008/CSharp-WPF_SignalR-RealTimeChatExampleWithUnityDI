using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Interfaces.Presenter;
using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Interfaces.PresenterData;
using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Presenter;
using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.PresenterData;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddChatPresenterViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<IChatPresenterViewModel, ChatPresenterViewModel>();
    }

    public static void AddChatPresenterDataViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModel<IChatPresenterDataViewModel, ChatPresenterDataViewModel>();
    }
}