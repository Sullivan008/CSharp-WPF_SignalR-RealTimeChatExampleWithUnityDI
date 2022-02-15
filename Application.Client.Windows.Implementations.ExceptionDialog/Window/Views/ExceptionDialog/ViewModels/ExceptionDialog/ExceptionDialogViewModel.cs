using System.Windows.Input;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.Commands;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog;

public class ExceptionDialogViewModel : ContentPresenterViewModel<ExceptionDialogViewDataViewModel>
{
    public ExceptionDialogViewModel(ICurrentWindowService currentWindowService, ExceptionDialogViewDataViewModel viewData) : base(currentWindowService, viewData)
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