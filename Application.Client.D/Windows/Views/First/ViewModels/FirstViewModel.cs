using System.Windows.Input;
using Application.Client.D.Windows.Views.First.Commands;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;

namespace Application.Client.D.Windows.Views.First.ViewModels
{
    public class FirstViewModel : NavigationWindowPageViewModelBase<DWindow>
    {
        public FirstViewModel(IViewNavigationService<DWindow> viewNavigationService) : base(viewNavigationService)
        { }

        private ICommand? _navigateSecondPage;
        public ICommand NavigateSecondPage => _navigateSecondPage ??= new GoToSecondViewCommand(this, ViewNavigationService);
    }
}
