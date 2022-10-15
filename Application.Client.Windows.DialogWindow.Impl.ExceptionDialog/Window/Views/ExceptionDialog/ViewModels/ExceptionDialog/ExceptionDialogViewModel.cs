﻿using System.Windows.Input;
using App.Core.Guard.Implementation;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.DialogWindow.Core.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.Commands;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog;

public class ExceptionDialogViewModel : ContentPresenterViewModel<ExceptionDialogViewDataViewModel>
{
    public ExceptionDialogViewModel(ExceptionDialogViewDataViewModel viewData, ICurrentWindowService currentWindowService) : base(viewData, currentWindowService)
    { }

    private bool? _isDeveloperMode;
    public bool IsDeveloperMode
    {
        get
        {
            Guard.ThrowIfNull(_isDeveloperMode, nameof(IsDeveloperMode));

            return _isDeveloperMode!.Value;
        }

        set
        {
            Guard.ThrowIfNull(value, nameof(IsDeveloperMode));
            _isDeveloperMode = value;

            OnPropertyChanged();
        }
    }

    private ICommand? _okCommand;
    public ICommand OkCommand => _okCommand ??= new OkCommand(this, (ICurrentDialogWindowService)CurrentWindowService);
}