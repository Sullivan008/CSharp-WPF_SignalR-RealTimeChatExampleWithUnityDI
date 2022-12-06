﻿namespace SullyTech.Wpf.Windows.Core.ViewModels.Interfaces.WindowSettings;

public interface IWindowSettingsViewModel
{
    public string Title { get; set; }

    public double Height { get; set; }

    public double Width { get; set; }

    public double Top { get; set; }

    public double Bottom { get; set; } 

    public double Left { get; set; }

    public double Right { get; set; }
}