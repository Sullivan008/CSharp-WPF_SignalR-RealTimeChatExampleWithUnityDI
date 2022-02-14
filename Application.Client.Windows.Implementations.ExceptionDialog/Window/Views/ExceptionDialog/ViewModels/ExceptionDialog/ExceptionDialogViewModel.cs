﻿using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog;

public class ExceptionDialogViewModel : ContentPresenterViewModel<ExceptionDialogViewDataViewModel>
{
    public ExceptionDialogViewModel(ICurrentWindowService currentWindowService) : base(currentWindowService)
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
}