using SullyTech.Wpf.Windows.Core.Window.ViewModels.Window;
using SullyTech.Wpf.Windows.Dialog.Window.Result.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Interfaces.DialogWindow;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Interfaces.DialogWindowSettings;

namespace SullyTech.Wpf.Windows.Dialog.Window.ViewModels.DialogWindow;

public class DialogWindowViewModel<TIDialogWindowSettingsViewModel, TIDialogResult> : WindowViewModel<TIDialogWindowSettingsViewModel>, IDialogWindowViewModel
    where TIDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
    where TIDialogResult : IDialogResult
{
    public DialogWindowViewModel(TIDialogWindowSettingsViewModel settings) : base(settings)
    { }

    private TIDialogResult? _dialogResult;
    public TIDialogResult DialogResult
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
        set => DialogResult = (TIDialogResult)value;
    }
}