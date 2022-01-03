using Application.Client.Windows.Implementations.Main.Window.Commands;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;
using System.Windows.Input;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels;

internal class MainWindowViewModel : NavigationWindowViewModelBase<MainWindow>
{
    public MainWindowViewModel(IViewNavigationService<MainWindow> viewNavigationService) : base(viewNavigationService)
    { }

    private ICommand? _windowLoadedCommand;
    public ICommand WindowLoadedCommand => _windowLoadedCommand ??= new WindowLoadedCommand(this, ViewNavigationService);
}