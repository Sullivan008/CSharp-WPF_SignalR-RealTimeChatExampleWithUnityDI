using System.Windows.Input;
using Microsoft.Extensions.Hosting;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Commands.Presenter.Loaded;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Commands.Presenter.Ok;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Presenter;

public sealed class ExceptionDialogPresenterViewModel : PresenterViewModel<IExceptionDialogPresenterDataViewModel>, IExceptionDialogPresenterViewModel
{
    private readonly IHostEnvironment _hostEnvironment;


    private readonly IDialogWindowService _dialogWindowService;

    public ExceptionDialogPresenterViewModel(IExceptionDialogPresenterDataViewModel data, IHostEnvironment hostEnvironment,
        IDialogWindowService dialogWindowService) : base(data)
    {
        _hostEnvironment = hostEnvironment;
        _dialogWindowService = dialogWindowService;

        LoadedCommand = new LoadedCommand(this);
    }

    public bool IsDeveloperMode => _hostEnvironment.IsDevelopment();


    private ICommand? _okCommand;
    public ICommand OkCommand =>
        _okCommand ??= new OkCommand(this, _dialogWindowService);
}