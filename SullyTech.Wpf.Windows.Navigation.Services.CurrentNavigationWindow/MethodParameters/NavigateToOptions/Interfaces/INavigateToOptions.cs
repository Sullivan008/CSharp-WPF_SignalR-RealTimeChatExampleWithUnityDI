﻿using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.MethodParameters.NavigateToOptions.Interfaces;

public interface INavigateToOptions
{
    internal Type PresenterViewModelType { get; }

    internal IPresenterViewModelInitializerModel? PresenterViewModelInitializerModel { get; }

    internal IPresenterDataViewModelInitializerModel? PresenterDataViewModelInitializerModel { get; }
}