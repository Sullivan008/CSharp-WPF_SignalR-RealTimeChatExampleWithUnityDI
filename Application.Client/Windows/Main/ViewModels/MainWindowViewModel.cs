using System.Windows.Input;
using Application.Client.Windows.Main.Commands;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;

namespace Application.Client.Windows.Main.ViewModels;

public class MainWindowViewModel : NavigationWindowViewModelBase<MainWindow>
{
    public MainWindowViewModel(IViewNavigationService<MainWindow> viewNavigationService) : base(viewNavigationService)
    { }

    private ICommand? _windowLoadedCommand;
    public ICommand WindowLoadedCommand => _windowLoadedCommand ??= new WindowLoadedCommand(this, ViewNavigationService);
}