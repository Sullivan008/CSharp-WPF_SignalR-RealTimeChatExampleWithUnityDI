﻿using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Interfaces;

namespace Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Initializers.Interfaces;

public interface INavigationWindowViewModelInitializer<in TNavigationWindowViewModel, in TNavigationWindowViewModelInitializerModel> 
    where TNavigationWindowViewModel : INavigationWindowViewModel
    where TNavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
{
    public void Initialize(TNavigationWindowViewModel navigationWindowViewModel, TNavigationWindowViewModelInitializerModel navigationWindowViewModelInitializerModel);
}