﻿using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Enums;
using Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox;

public class MessageBoxViewModel : ContentPresenterViewModel<MessageBoxViewDataViewModel>
{
    public MessageBoxViewModel(ICurrentDialogWindowService currentWindowService) : base(currentWindowService)
    { }

    private MessageBoxIcon? _messageBoxIcon;
    public MessageBoxIcon MessageBoxIcon
    {
        get
        {
            Guard.ThrowIfNull(_messageBoxIcon, nameof(MessageBoxIcon));

            return _messageBoxIcon!.Value;
        }

        set
        {
            Guard.ThrowIfNull(value, nameof(MessageBoxIcon));
            _messageBoxIcon = value;

            OnPropertyChanged();
        }
    }

    private MessageBoxButton? _messageBoxButton;
    public MessageBoxButton MessageBoxButton
    {
        get
        {
            Guard.ThrowIfNull(_messageBoxButton, nameof(MessageBoxButton));

            return _messageBoxButton!.Value;
        }

        set
        {
            Guard.ThrowIfNull(value, nameof(MessageBoxButton));
            _messageBoxButton = value;

            OnPropertyChanged();
        }
    }
}