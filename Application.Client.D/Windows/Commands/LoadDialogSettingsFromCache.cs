using Application.Client.Common.Commands;
using Application.Client.D.Windows.ViewModels;
using Application.Client.D.Windows.Views.First.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;

namespace Application.Client.D.Windows.Commands
{
    internal class LoadDialogSettingsFromCache : AsyncCommandBase<DWindowViewModel>
    {
        private readonly IViewNavigationService<DWindow> _viewNavigationService;

        public LoadDialogSettingsFromCache(DWindowViewModel callerViewModel, IViewNavigationService<DWindow> viewNavigationService) : base(callerViewModel)
        {
            _viewNavigationService = viewNavigationService;
        }

        public override async Task ExecuteAsync()
        {
            _viewNavigationService.Navigate<FirstViewModel>();

            await Task.CompletedTask;
        }
    }
}
