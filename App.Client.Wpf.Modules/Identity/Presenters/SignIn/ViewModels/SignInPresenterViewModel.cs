using System.Windows.Input;
using App.Client.Wpf.Modules.Identity.Presenters.SignIn.ViewModels.Commands;
using FluentValidation;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.ValidatablePresenter;
using SullyTech.Wpf.Services.Navigation.Interfaces;
using SullyTech.Wpf.Services.Window.Closer.Interfaces;

namespace App.Client.Wpf.Modules.Identity.Presenters.SignIn.ViewModels;

public sealed class SignInPresenterViewModel : ValidatablePresenterViewModel<SignInPresenterViewModel>
{
    private readonly INavigationService _navigationService;

    private readonly IWindowCloserService _windowCloserService;

    public SignInPresenterViewModel(IValidator<SignInPresenterViewModel> validator, INavigationService navigationService, IWindowCloserService windowCloserService) : base(validator)
    {
        _navigationService = navigationService;
        _windowCloserService = windowCloserService;

        LoadedCommand = new LoadedCommand(this);
    }

    private string _nickName = string.Empty;
    public string NickName
    {
        get => _nickName;
        set
        {
            _nickName = value;
            OnPropertyChanged();
        }
    }

    private ICommand? _closeCommand;
    public ICommand CloseCommand =>
        _closeCommand ??= new CloseCommand(this, _windowCloserService);


    private ICommand? _signInCommand;
    public ICommand SignInCommand =>
        _signInCommand ??= new SignInCommand(this, _navigationService);
}