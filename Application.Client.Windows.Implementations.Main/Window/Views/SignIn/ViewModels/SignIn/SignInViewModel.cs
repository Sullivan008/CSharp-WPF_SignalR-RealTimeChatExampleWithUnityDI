﻿using System.Windows.Input;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.DialogWindow.Services.DialogWindow.Interfaces;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.Commands;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;

public class SignInViewModel : ContentPresenterViewModel<SignInViewDataViewModel>
{
    private readonly IDialogWindowService _dialogWindowService;

    private readonly INavigationWindowService _navigationWindowService;

    public SignInViewModel(ICurrentNavigationWindowService currentNavigationWindowService, INavigationWindowService navigationWindowService, IDialogWindowService dialogWindowService) : base(currentNavigationWindowService)
    {
        _dialogWindowService = dialogWindowService;
        _navigationWindowService = navigationWindowService;

        var asd = System.Windows.Application.Current.Windows;
    }
    
    private ICommand? _openTestWindowCommand;
    public ICommand OpenTestWindowCommand => _openTestWindowCommand ??= new OpenTestWindowCommand(this, _navigationWindowService, _dialogWindowService);
}