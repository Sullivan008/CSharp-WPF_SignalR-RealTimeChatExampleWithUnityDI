﻿using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.Window.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models;

public class ApplicationWindowShowOptionsModel<TApplicationWindow, TApplicationWindowViewModel, TApplicationWindowViewModelInitializerModel> : IApplicationWindowShowOptionsModel
    where TApplicationWindow : IApplicationWindow
    where TApplicationWindowViewModel : IApplicationWindowViewModel
    where TApplicationWindowViewModelInitializerModel : IApplicationWindowViewModelInitializerModel
{
    Type IApplicationWindowShowOptionsModel.WindowType => typeof(TApplicationWindow);

    Type IApplicationWindowShowOptionsModel.WindowViewModelType => typeof(TApplicationWindowViewModel);

    IApplicationWindowViewModelInitializerModel IApplicationWindowShowOptionsModel.WindowViewModelInitializerModel => WindowViewModelInitializerModel;

    private readonly TApplicationWindowViewModelInitializerModel? _windowViewModelInitializerModel;
    public TApplicationWindowViewModelInitializerModel WindowViewModelInitializerModel
    {
        get
        {
            Guard.ThrowIfNull(_windowViewModelInitializerModel, nameof(WindowViewModelInitializerModel));
            return _windowViewModelInitializerModel!;
        }

        init
        {
            Guard.ThrowIfNull(value, nameof(WindowViewModelInitializerModel));
            _windowViewModelInitializerModel = value;
        }
    }
}