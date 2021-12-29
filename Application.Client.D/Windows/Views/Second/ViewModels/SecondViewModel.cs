using System.Windows.Input;
using Application.Client.D.Windows.Views.First.Commands;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;

namespace Application.Client.D.Windows.Views.Second.ViewModels;

public class SecondViewModel : NavigationWindowPageViewModelBase<DWindow>
{
    public SecondViewModel(IViewNavigationService<DWindow> viewNavigationService) : base(viewNavigationService)
    { }

    private ICommand? _navigateFirstPage;
    public ICommand NavigateFirstPage => _navigateFirstPage ??= new GoToFirstViewCommand(this, ViewNavigationService);
}