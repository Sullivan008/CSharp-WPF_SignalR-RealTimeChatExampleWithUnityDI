using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Chat.Presenters.Chat.ViewModels.Validators.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddChatPresenterViewModelValidator(this IServiceCollection @this)
    {
        @this.AddScoped<IValidator<ChatPresenterViewModel>, ChatPresenterViewModelValidator>();
    }
}