using Application.Client.Common.Commands;
using Application.Client.D.Windows.Views.First.ViewModels;
using Application.Client.D.Windows.Views.Second.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;

namespace Application.Client.D.Windows.Views.First.Commands;

public class GoToSecondViewCommand : AsyncCommandBase<FirstViewModel>
{
    private readonly IViewNavigationService<DWindow> _viewNavigationService;

    public GoToSecondViewCommand(FirstViewModel callerViewModel, IViewNavigationService<DWindow> viewNavigationService) : base(callerViewModel)
    {
        _viewNavigationService = viewNavigationService;
    }

    public async override Task ExecuteAsync()
    {
        _viewNavigationService.Navigate<SecondViewModel>();

        await Task.CompletedTask;
    }
}