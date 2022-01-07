using System.Windows.Input;
using Application.Client.D.Windows.Views.Second.Commands;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;

namespace Application.Client.D.Windows.Views.Second.ViewModels;

public class SecondViewModel : PageViewModelBase<DWindow>
{
    public SecondViewModel(IViewNavigationService<DWindow> viewNavigationService) : base(viewNavigationService)
    { }

    private ICommand? _navigateFirstPage;
    public ICommand NavigateFirstPage => _navigateFirstPage ??= new GoToFirstViewCommand(this, ViewNavigationService);
}