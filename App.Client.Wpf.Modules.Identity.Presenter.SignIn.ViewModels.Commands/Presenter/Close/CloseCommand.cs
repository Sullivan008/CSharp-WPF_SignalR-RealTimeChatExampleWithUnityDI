using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Services.Window.Closer.Interfaces;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Commands.Presenter.Close;

public sealed class CloseCommand : AsyncCommand<ISignInPresenterViewModel>
{
    private readonly IWindowCloserService _windowCloserService;

    public CloseCommand(ISignInPresenterViewModel callerViewModel, IWindowCloserService windowCloserService) : base(callerViewModel)
    {
        _windowCloserService = windowCloserService;
    }

    public override async Task ExecuteAsync()
    {
        await _windowCloserService.CloseAsync(CallerViewModel.WindowId);
    }
}