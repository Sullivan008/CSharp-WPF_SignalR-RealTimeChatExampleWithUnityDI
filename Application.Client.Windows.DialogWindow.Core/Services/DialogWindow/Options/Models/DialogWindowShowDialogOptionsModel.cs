using Application.Client.Windows.DialogWindow.Core.Services.DialogWindow.Options.Models.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Core.Window.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.DialogWindow.Core.Services.DialogWindow.Options.Models;

public class DialogWindowShowDialogOptionsModel<TDialogWindow, TDialogWindowViewModel, TDialogWindowViewModelInitializerModel> : IDialogWindowShowDialogOptionsModel
    where TDialogWindow : IDialogWindow
    where TDialogWindowViewModel : IDialogWindowViewModel
    where TDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
{
    Type IDialogWindowShowDialogOptionsModel.WindowType => typeof(TDialogWindow);

    Type IDialogWindowShowDialogOptionsModel.WindowViewModelType => typeof(TDialogWindowViewModel);

    IDialogWindowViewModelInitializerModel IDialogWindowShowDialogOptionsModel.WindowViewModelInitializerModel => WindowViewModelInitializerModel;

    private readonly TDialogWindowViewModelInitializerModel? _windowViewModelInitializerModel;
    public TDialogWindowViewModelInitializerModel WindowViewModelInitializerModel
    {
        get
        {
            Guard.ThrowIfNull(_windowViewModelInitializerModel, nameof(WindowViewModelInitializerModel));

            return _windowViewModelInitializerModel!;
        }

        init
        {
            Guard.ThrowIfNull(value, nameof(WindowViewModelInitializerModel));
            _windowViewModelInitializerModel = value;
        }
    }
}