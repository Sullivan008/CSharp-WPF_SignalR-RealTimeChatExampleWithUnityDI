using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.Presenter.Models.Enums;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.Presenter.Models;

public sealed class MessageDialogViewModelInitializerModel : IMessageDialogViewModelInitializerModel
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