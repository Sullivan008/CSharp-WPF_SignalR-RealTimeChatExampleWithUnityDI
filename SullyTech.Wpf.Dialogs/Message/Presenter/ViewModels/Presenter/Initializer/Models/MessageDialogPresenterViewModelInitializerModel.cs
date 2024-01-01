using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Initializers.Models;
using SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Initializer.Enums;

namespace SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Initializer.Models;

public sealed record MessageDialogPresenterViewModelInitializerModel : PresenterViewModelInitializerModel
{
    public required string Message { get; init; }

    public IconType? IconType { get; init; }

    public required ButtonType ButtonType { get; init; }
}