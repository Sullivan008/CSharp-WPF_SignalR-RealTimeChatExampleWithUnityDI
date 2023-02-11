using System.Windows.Input;
using Microsoft.Extensions.Hosting;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Commands.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Presenter;

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