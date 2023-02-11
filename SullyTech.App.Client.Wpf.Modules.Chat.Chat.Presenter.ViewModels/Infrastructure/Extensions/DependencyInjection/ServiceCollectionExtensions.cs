using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Presenter;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddChatViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<IChatViewModel, ChatViewModel>();
    }

    public static void AddChatDataViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModel<IChatDataViewModel, ChatDataViewModel>();
    }
}