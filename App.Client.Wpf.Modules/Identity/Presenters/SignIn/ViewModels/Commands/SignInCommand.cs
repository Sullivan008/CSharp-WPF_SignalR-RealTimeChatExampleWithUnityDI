using SullyTech.Wpf.Controls.Presenter.Core.Commands.Abstractions;
using SullyTech.Wpf.Services.Navigation.Interfaces;

namespace App.Client.Wpf.Modules.Identity.Presenters.SignIn.ViewModels.Commands;

internal sealed class SignInCommand : AsyncCommand<SignInPresenterViewModel>
{
    private readonly INavigationService _navigationService;

    public SignInCommand(SignInPresenterViewModel callerViewModel, INavigationService navigationService) : base(callerViewModel)
    {
        _navigationService = navigationService;
    }

    public override Predicate<object?> CanExecute => _ => CallerViewModel.IsValid;

    public override async Task ExecuteAsync()
    {
        await SignInAsync();

        await NavigateToChatView();
    }

    private async Task SignInAsync()
    {
        // TODO - IF implemented Sign In - API Logic, then implemented it!

        await Task.CompletedTask;
    }

    private async Task NavigateToChatView()
    {
        // TODO - IF implemented Chat - Presenter, then implemented it!

        //await _navigationService.NavigateToAsync(
        //    windowId: CallerViewModel.WindowId,
        //    navigateToOptions: new NavigateToOptions<IChatPresenter, IChatPresenterViewModel, IChatPresenterDataViewModel>());

        await Task.CompletedTask;
    }
}