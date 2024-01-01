using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Initializers.Models;
using SullyTech.Wpf.Controls.Window.Dialog.Core.Results;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window.Initializers.Models;

namespace SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;

public interface IDialogWindowService
{
    public Task<TDialogResult> ShowDialogAsync<TDialogWindow, TDialogResult,
                                               TDialogWindowViewModel, TPresenter, TPresenterViewModel>(DialogWindowViewModelInitializerModel? windowViewModelInitializerModel = null,
                                                                                                        PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TDialogWindow : Core.UserControls.DialogWindow
        where TDialogResult : DialogResult
        where TDialogWindowViewModel : DialogWindowViewModel
        where TPresenter : Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel;

    public void SetDialogResult<TDialogWindow, TDialogResult>(string windowId, TDialogResult result)
        where TDialogWindow : Core.UserControls.DialogWindow
        where TDialogResult : DialogResult;
}