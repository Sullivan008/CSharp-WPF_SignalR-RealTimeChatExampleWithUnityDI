﻿using System.Windows.Input;
using App.Core.Guard.Implementation;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.DialogWindow.Core.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Commands;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Enums;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox;

public class MessageBoxViewModel : ContentPresenterViewModel<MessageBoxViewDataViewModel>
{
    public MessageBoxViewModel(MessageBoxViewDataViewModel viewData, ICurrentDialogWindowService currentWindowService) : base(viewData, currentWindowService)
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

    private ICommand? _okCommand;
    public ICommand OkCommand => _okCommand ??= new OkCommand(this, (ICurrentDialogWindowService)CurrentWindowService);

    private ICommand? _noCommand;
    public ICommand NoCommand => _noCommand ??= new NoCommand(this, (ICurrentDialogWindowService)CurrentWindowService);

    private ICommand? _yesCommand;
    public ICommand YesCommand => _yesCommand ??= new YesCommand(this, (ICurrentDialogWindowService)CurrentWindowService);

    private ICommand? _cancelCommand;
    public ICommand CancelCommand => _cancelCommand ??= new CancelCommand(this, (ICurrentDialogWindowService)CurrentWindowService);
}