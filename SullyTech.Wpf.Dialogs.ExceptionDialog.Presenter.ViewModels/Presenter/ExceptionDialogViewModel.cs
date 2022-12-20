using System.Windows.Input;
using Microsoft.Extensions.Hosting;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Commands.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Presenter;

public sealed class ExceptionDialogViewModel : PresenterViewModel<IExceptionDialogDataViewModel>, IExceptionDialogViewModel
{
    private readonly IHostEnvironment _hostEnvironment;

    private readonly IDialogWindowService _dialogWindowService;

    public ExceptionDialogViewModel(IExceptionDialogDataViewModel data, IHostEnvironment hostEnvironment, IDialogWindowService dialogWindowService) : base(data)
    {
        _hostEnvironment = hostEnvironment;
        _dialogWindowService = dialogWindowService;
    }

    public bool IsDeveloperMode => _hostEnvironment.IsDevelopment();

    private ICommand? _okCommand;
    public ICommand OkCommand => _okCommand ??= new OkCommand(this, _dialogWindowService);
}