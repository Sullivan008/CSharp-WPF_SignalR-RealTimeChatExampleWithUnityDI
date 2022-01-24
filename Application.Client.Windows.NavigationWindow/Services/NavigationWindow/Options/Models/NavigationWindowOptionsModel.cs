﻿using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models;

public class NavigationWindowOptionsModel<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel> : 
    ApplicationWindowOptionsModel<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel>, INavigationWindowOptionsModel
        where TNavigationWindow : INavigationWindow
        where TNavigationWindowViewModel : INavigationWindowViewModel
        where TNavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
{ }
