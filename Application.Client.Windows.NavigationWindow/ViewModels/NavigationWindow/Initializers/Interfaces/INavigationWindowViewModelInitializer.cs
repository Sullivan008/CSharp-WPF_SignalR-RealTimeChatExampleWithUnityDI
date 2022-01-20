﻿using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Interfaces;

public interface INavigationWindowViewModelInitializer<in TNavigationWindowViewModel, in TNavigationWindowViewModelInitializerModel> 
    where TNavigationWindowViewModel : INavigationWindowViewModel
{
    public void Initialize(TNavigationWindowViewModel navigationWindowViewModel, TNavigationWindowViewModelInitializerModel navigationWindowViewModelInitializerModel);
}