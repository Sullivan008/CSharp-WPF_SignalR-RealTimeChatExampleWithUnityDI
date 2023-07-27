using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Enums.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Interfaces.Presenter;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Presenter;

public sealed class MessageDialogPresenterViewModelInitializerModel : PresenterViewModelInitializerModel, IMessageDialogPresenterViewModelInitializerModel
{
    public IconType? IconType { get; init; }

    private readonly ButtonType? _buttonType;
    public ButtonType ButtonType
    {
        get
        {
            Guard.Guard.ThrowIfNull(_buttonType, nameof(ButtonType));

            return _buttonType!.Value;
        }

        init => _buttonType = value;
    }
}