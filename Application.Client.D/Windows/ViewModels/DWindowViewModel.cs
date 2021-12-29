using System.Windows.Input;
using Application.Client.D.Windows.Commands;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;

namespace Application.Client.D.Windows.ViewModels;

public class DWindowViewModel : NavigationWindowViewModelBase<DWindow>
{
    public DWindowViewModel(IViewNavigationService<DWindow> viewNavigationService) : base(viewNavigationService)
    { }

    private ICommand? _loadDialogSettingsFromCache;
    public ICommand LoadDialogSettingsFromCache => _loadDialogSettingsFromCache ??= new LoadDialogSettingsFromCache(this, ViewNavigationService);
}