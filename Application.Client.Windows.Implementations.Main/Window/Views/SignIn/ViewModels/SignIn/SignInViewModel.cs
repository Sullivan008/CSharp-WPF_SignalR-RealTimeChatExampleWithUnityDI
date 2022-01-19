﻿using System.Windows.Input;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.Commands;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView;
using Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;

public class SignInViewModel : PageViewViewModel<SignInViewDataViewModel>
{
    private readonly INavigationWindowService _navigationWindowService;

    public SignInViewModel(IViewNavigationService viewNavigationService, INavigationWindowService navigationWindowService) : base(viewNavigationService)
    {
        _navigationWindowService = navigationWindowService;
    }
    
    private ICommand? _openTestWindowCommand;
    public ICommand OpenTestWindowCommand => _openTestWindowCommand ??= new OpenTestWindowCommand(this, _navigationWindowService);
}