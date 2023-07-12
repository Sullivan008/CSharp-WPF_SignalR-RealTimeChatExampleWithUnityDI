using SullyTech.Wpf.Controls.Window.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Dialog.Result.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Window;

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