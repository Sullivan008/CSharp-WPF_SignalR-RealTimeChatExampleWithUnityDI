using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.Presenter.Models.Enums;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;

public interface IMessageDialogViewModelInitializerModel : IPresenterViewModelInitializerModel
{
    public IconType? IconType { get; init; }

    public ButtonType ButtonType { get; init; }
}
