using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.Presenter.Models.Enums;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;

public interface IMessageDialogPresenterViewModelInitializerModel : IPresenterViewModelInitializerModel
{
    public IconType? IconType { get; init; }

    public ButtonType ButtonType { get; init; }
}
