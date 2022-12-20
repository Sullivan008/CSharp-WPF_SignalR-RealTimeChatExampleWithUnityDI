using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.Presenter.Models.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;

internal interface IMessageDialogViewModelInitializerModel : IPresenterViewModelInitializerModel
{
    public IconType? IconType { get; init; }

    public ButtonType ButtonType { get; init; }
}
