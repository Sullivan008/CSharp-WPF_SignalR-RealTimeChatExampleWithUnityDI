﻿using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindowSettings;

namespace SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Interfaces;

public interface INavigationWindowSettingsViewModelInitializer<in TINavigationWindowSettingsViewModel, in TINavigationWindowSettingsViewModelInitializerModel> :
    IWindowSettingsViewModelInitializer<TINavigationWindowSettingsViewModel, TINavigationWindowSettingsViewModelInitializerModel>
        where TINavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel
        where TINavigationWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
{ }
