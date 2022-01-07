using System.Windows.Input;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.Commands;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Services.ApplicationWindow.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;

public class SignInViewModel : PageViewModelBase<MainWindow>
{
    private readonly IApplicationWindowService _applicationWindowService;

    public SignInViewModel(IViewNavigationService<MainWindow> viewNavigationService, IApplicationWindowService applicationWindowService) : base(viewNavigationService)
    {
        _applicationWindowService = applicationWindowService;
    }

    private string _content = string.Empty;
    public string Content
    {
        get => _content;
        set
        {
            Guard.ThrowIfNullOrWhitespace(value, nameof(Content));
            _content = value;

            OnPropertyChanged();
        }
    }

    private ICommand? _openTestWindowCommand;
    public ICommand OpenTestWindowCommand => _openTestWindowCommand ??= new OpenTestWindowCommand(this, _applicationWindowService);
}