using App.Client.Wpf.Modules.Chat.Presenters.Chat.ViewModels.Commands;
using FluentValidation;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.ValidatablePresenter;

namespace App.Client.Wpf.Modules.Chat.Presenters.Chat.ViewModels;

public sealed class ChatPresenterViewModel : ValidatablePresenterViewModel<ChatPresenterViewModel>
{
    public ChatPresenterViewModel(IValidator<ChatPresenterViewModel> validator) : base(validator)
    {
        LoadedCommand = new LoadedCommand(this);
    }
}