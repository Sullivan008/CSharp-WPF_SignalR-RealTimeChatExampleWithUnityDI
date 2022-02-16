using Application.Client.Windows.Core.ContentPresenter.Commands.Abstractions;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;

internal class SignInCommand : AsyncContentPresenterCommand<SignInViewModel>
{
    public SignInCommand(SignInViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync()
    {
        await Task.CompletedTask;
    }

    public override Predicate<object?>? CanExecute => _ => CallerViewModel.ViewData.IsValid;
}