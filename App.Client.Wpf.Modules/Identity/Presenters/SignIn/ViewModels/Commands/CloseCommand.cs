using SullyTech.Wpf.Controls.Presenter.Core.Commands.Abstractions;
using SullyTech.Wpf.Services.Window.Closer.Interfaces;

namespace App.Client.Wpf.Modules.Identity.Presenters.SignIn.ViewModels.Commands;

internal sealed class CloseCommand : AsyncCommand<SignInPresenterViewModel>
{
    private readonly IWindowCloserService _windowCloserService;

    public CloseCommand(SignInPresenterViewModel callerViewModel, IWindowCloserService windowCloserService) : base(callerViewModel)
    {
        _windowCloserService = windowCloserService;
    }

    public override async Task ExecuteAsync()
    {
        await _windowCloserService.CloseAsync(CallerViewModel.WindowId);
    }
}