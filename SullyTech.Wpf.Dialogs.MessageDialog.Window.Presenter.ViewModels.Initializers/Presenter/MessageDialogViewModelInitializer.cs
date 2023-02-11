using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.Presenter.Interfaces;
using ButtonType = SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Enums.Presenter.ButtonType;
using IconType = SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Enums.Presenter.IconType;
using InitializerIconType = SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.Presenter.Models.Enums.IconType;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.Presenter;

internal sealed class MessageDialogViewModelInitializer : IPresenterViewModelInitializer<IMessageDialogViewModel, IMessageDialogViewModelInitializerModel>
{
    public void Initialize(IMessageDialogViewModel presenterViewModel, IMessageDialogViewModelInitializerModel presenterViewModelInitializerModel)
    {
        presenterViewModel.ButtonType = (ButtonType)presenterViewModelInitializerModel.ButtonType;
        presenterViewModel.IconType = InitializeIconType(presenterViewModelInitializerModel.IconType);
    }

    private static IconType InitializeIconType(InitializerIconType? iconType)
    {
        return iconType.HasValue == false ? IconType.None : (IconType)iconType.Value;
    }
}