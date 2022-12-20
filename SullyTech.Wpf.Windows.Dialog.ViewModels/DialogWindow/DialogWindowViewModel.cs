﻿using SullyTech.Wpf.Windows.Core.ViewModels.Window;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindowSettings;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow;

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