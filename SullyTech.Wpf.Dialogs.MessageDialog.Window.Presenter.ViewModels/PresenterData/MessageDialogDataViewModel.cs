﻿using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.PresenterData;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.PresenterData;

public sealed class MessageDialogDataViewModel : PresenterDataViewModel, IMessageDialogDataViewModel
{
    private string? _message;
    public string Message
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_message, nameof(Message));

            return _message!;
        }

        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }
}