﻿using App.Core.Guard.Implementation;
using Application.Client.Windows.DialogWindow.Core.Models.CustomDialogWindowResult;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox.Enums;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox;

public class MessageBoxWindowResult : CustomDialogWindowResult
{
    private readonly MessageBoxResult? _messageBoxResult;
    public MessageBoxResult MessageBoxResult
    {
        get
        {
            Guard.ThrowIfNull(_messageBoxResult, nameof(MessageBoxResult));

            return _messageBoxResult!.Value;
        }

        init
        {
            Guard.ThrowIfNull(value, nameof(MessageBoxResult));

            _messageBoxResult = value;
        }
    }
}