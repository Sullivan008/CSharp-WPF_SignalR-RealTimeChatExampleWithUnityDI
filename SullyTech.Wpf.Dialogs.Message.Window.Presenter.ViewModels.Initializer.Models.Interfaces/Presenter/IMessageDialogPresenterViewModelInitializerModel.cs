using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Enums.Presenter;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Interfaces.Presenter;

public interface IMessageDialogPresenterViewModelInitializerModel : IPresenterViewModelInitializerModel
{
    public IconType? IconType { get; init; }

    public ButtonType ButtonType { get; init; }
}
