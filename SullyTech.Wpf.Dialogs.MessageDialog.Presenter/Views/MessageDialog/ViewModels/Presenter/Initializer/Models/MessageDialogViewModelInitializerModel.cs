using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter.Initializer.Models.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter.Initializer.Models;

public sealed class MessageDialogViewModelInitializerModel : IPresenterViewModelInitializerModel
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