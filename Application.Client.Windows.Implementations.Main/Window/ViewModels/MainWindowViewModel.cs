using System.Windows.Input;
using Application.Client.Windows.Implementations.Main.Window.Commands;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Abstractions;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels;

internal class MainWindowViewModel : NavigationWindowViewModelBase<MainWindow>
{
    public MainWindowViewModel(IViewNavigationService<MainWindow> viewNavigationService) : base(viewNavigationService)
    { }

    private ICommand? _windowLoadedCommand;
    public ICommand WindowLoadedCommand => _windowLoadedCommand ??= new WindowLoadedCommand(this, ViewNavigationService);
}