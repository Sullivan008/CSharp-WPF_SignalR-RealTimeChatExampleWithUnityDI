using System.Windows.Input;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.Commands;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData;
using Microsoft.Extensions.Hosting;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog;

public class ExceptionDialogViewModel : PresenterViewModel<ExceptionDialogViewDataViewModel>
{
    private readonly IHostEnvironment _hostEnvironment;

    private readonly ICurrentDialogWindowService _currentWindowService;

    public ExceptionDialogViewModel(ExceptionDialogViewDataViewModel viewData, IHostEnvironment hostEnvironment, ICurrentDialogWindowService currentWindowService) : base(viewData)
    {
        _hostEnvironment = hostEnvironment;
        _currentWindowService = currentWindowService;
    }

    public bool IsDeveloperMode => _hostEnvironment.IsDevelopment();

    private ICommand? _okCommand;
    public ICommand OkCommand => _okCommand ??= new OkCommand(this, _currentWindowService);
}