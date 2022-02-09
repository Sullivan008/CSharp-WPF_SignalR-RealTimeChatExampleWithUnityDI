using Application.Client.Windows.DialogWindow.Services.DialogWindow.Options.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Window.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.DialogWindow.Services.DialogWindow.Options.Models;

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