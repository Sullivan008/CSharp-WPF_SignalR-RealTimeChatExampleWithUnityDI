using App.Core.Guard.Implementation;
using Application.Client.Windows.Core.ViewModels.Window;
using Application.Client.Windows.DialogWindow.Core.Models.CustomDialogWindowResult.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Interfaces;

namespace Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow;

public class DialogWindowViewModel<TDialogWindowSettingsViewModel, TCustomDialogWindowResultModel> : WindowViewModel<TDialogWindowSettingsViewModel>, IDialogWindowViewModel
    where TDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel, new()
    where TCustomDialogWindowResultModel : ICustomDialogWindowResultModel
{
    private TCustomDialogWindowResultModel? _customDialogResult;
    public TCustomDialogWindowResultModel CustomDialogResult
    {
        get
        {
            Guard.ThrowIfNull(_customDialogResult, nameof(CustomDialogResult));

            return _customDialogResult!;
        }
        set
        {
            Guard.ThrowIfNull(value, nameof(CustomDialogResult));
            Guard.ThrowIfNotNull(_customDialogResult, nameof(CustomDialogResult));

            _customDialogResult = value;
        }
    }

    ICustomDialogWindowResultModel IDialogWindowViewModel.CustomDialogResult
    {
        get => CustomDialogResult;
        set => CustomDialogResult = (TCustomDialogWindowResultModel)value;
    }
}