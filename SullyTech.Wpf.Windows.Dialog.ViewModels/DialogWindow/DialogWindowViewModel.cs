using SullyTech.Wpf.Windows.Core.ViewModels.Window;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindowSettings;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow;

public class DialogWindowViewModel<TDialogWindowSettingsViewModel, TDialogResult> : WindowViewModel<TDialogWindowSettingsViewModel>, IDialogWindowViewModel
    where TDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel, new()
    where TDialogResult : IDialogResult
{
    public DialogWindowViewModel(TDialogWindowSettingsViewModel settings) : base(settings)
    { }

    private TDialogResult? _dialogResult;
    public TDialogResult DialogResult
    {
        get
        {
            Guard.Guard.ThrowIfNull(_dialogResult, nameof(DialogResult));

            return _dialogResult!;
        }

        set => _dialogResult = value;
    }

    IDialogResult IDialogWindowViewModel.DialogResult
    {
        get => DialogResult;
        set => DialogResult = (TDialogResult)value;
    }
}