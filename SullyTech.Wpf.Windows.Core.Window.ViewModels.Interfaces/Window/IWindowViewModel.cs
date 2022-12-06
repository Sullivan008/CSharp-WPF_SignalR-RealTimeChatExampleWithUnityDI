﻿using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Windows.Core.ViewModels.Interfaces.Window;

public interface IWindowViewModel
{
    public IWindowSettingsViewModel Settings { get; }

    public IPresenterViewModel Presenter { get; set; }
}