﻿using System.Windows.Input;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter.Commands;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter.Enums;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.PresenterData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter;

public sealed class MessageDialogViewModel : PresenterViewModel<MessageDialogDataViewModel>
{
    private readonly ICurrentDialogWindowService _currentWindowService;

    public MessageDialogViewModel(MessageDialogDataViewModel viewData, ICurrentDialogWindowService currentWindowService) : base(viewData)
    {
        _currentWindowService = currentWindowService;
    }

    private IconType? _iconType;
    public IconType IconType
    {
        get
        {
            Guard.Guard.ThrowIfNull(_iconType, nameof(IconType));

            return _iconType!.Value;
        }

        set
        {
            _iconType = value;
            OnPropertyChanged();
        }
    }

    private ButtonType? _buttonType;
    public ButtonType ButtonType
    {
        get
        {
            Guard.Guard.ThrowIfNull(_buttonType, nameof(ButtonType));

            return _buttonType!.Value;
        }

        set
        {
            _buttonType = value;
            OnPropertyChanged();
        }
    }

    private ICommand? _okCommand;
    public ICommand OkCommand => _okCommand ??= new OkCommand(this, _currentWindowService);

    private ICommand? _noCommand;
    public ICommand NoCommand => _noCommand ??= new NoCommand(this, _currentWindowService);

    private ICommand? _yesCommand;
    public ICommand YesCommand => _yesCommand ??= new YesCommand(this, _currentWindowService);

    private ICommand? _cancelCommand;
    public ICommand CancelCommand => _cancelCommand ??= new CancelCommand(this, _currentWindowService);
}