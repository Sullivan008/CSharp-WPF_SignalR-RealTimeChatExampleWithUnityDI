using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.Presenter.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.Presenter;
using ButtonType = SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Enums.Presenter.ButtonType;
using IconType = SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Enums.Presenter.IconType;
using InitializerIconType = SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.Presenter.Models.Enums.IconType;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.Presenter;

internal sealed class MessageDialogPresenterViewModelInitializer : IPresenterViewModelInitializer<IMessageDialogPresenterViewModel, IMessageDialogPresenterViewModelInitializerModel>
{
    public void Initialize(IMessageDialogPresenterViewModel presenterViewModel, IMessageDialogPresenterViewModelInitializerModel presenterViewModelInitializerModel)
    {
        presenterViewModel.ButtonType = (ButtonType)presenterViewModelInitializerModel.ButtonType;
        presenterViewModel.IconType = InitializeIconType(presenterViewModelInitializerModel.IconType);
    }

    private static IconType InitializeIconType(InitializerIconType? iconType)
    {
        return iconType.HasValue == false ? IconType.None : (IconType)iconType.Value;
    }
}