﻿using System.Windows.Input;
using Application.Client.Windows.Core.ViewModels.Window;
using Application.Client.Windows.DialogWindow.Models.CustomDialogWindowResult.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.DialogWindow.ViewModels.DialogWindow;

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

            _customDialogResult = value;
        }
    }

    ICustomDialogWindowResultModel IDialogWindowViewModel.CustomDialogResult
    {
        get => CustomDialogResult;
        set
        {
            Guard.ThrowIfNull(value, nameof(CustomDialogResult));
            Guard.ThrowIfNotNull(CustomDialogResult, nameof(CustomDialogResult));

            CustomDialogResult = (TCustomDialogWindowResultModel)value;
        }
    }

    private ICommand? _closeWindowCommand;
    public ICommand CloseWindowCommand
    {
        get
        {
            Guard.ThrowIfNull(_closeWindowCommand, nameof(CloseWindowCommand));

            return _closeWindowCommand!;
        }

        set
        {
            Guard.ThrowIfNull(value, nameof(CloseWindowCommand));

            _closeWindowCommand = value;
        }
    }
}