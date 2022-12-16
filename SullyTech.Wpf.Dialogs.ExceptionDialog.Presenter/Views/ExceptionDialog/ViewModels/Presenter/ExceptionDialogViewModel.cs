using System.Windows.Input;
using Microsoft.Extensions.Hosting;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.ViewModels.Presenter.Commands;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.ViewModels.PresenterData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.ViewModels.Presenter;

public sealed class ExceptionDialogViewModel : PresenterViewModel<ExceptionDialogDataViewModel>
{
    private readonly IHostEnvironment _hostEnvironment;

    private readonly IDialogWindowService _dialogWindowService;

    public ExceptionDialogViewModel(ExceptionDialogDataViewModel data, IHostEnvironment hostEnvironment, IDialogWindowService dialogWindowService) : base(data)
    {
        _hostEnvironment = hostEnvironment;
        _dialogWindowService = dialogWindowService;
    }

    public bool IsDeveloperMode => _hostEnvironment.IsDevelopment();

    private ICommand? _okCommand;
    public ICommand OkCommand => _okCommand ??= new OkCommand(this, _dialogWindowService);
}