using Application.Client.Common.Commands;
using Application.Client.D.Windows.Views.First.ViewModels;
using Application.Client.D.Windows.Views.Second.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;

namespace Application.Client.D.Windows.Views.Second.Commands;

public class GoToFirstViewCommand : AsyncCommandBase<SecondViewModel>
{
    private readonly IViewNavigationService<DWindow> _viewNavigationService;

    public GoToFirstViewCommand(SecondViewModel callerViewModel, IViewNavigationService<DWindow> viewNavigationService) : base(callerViewModel)
    {
        _viewNavigationService = viewNavigationService;
    }

    public async override Task ExecuteAsync()
    {
        _viewNavigationService.Navigate<FirstViewModel>();

        await Task.CompletedTask;
    }
}