﻿using AutoMapper;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Mapping.Profiles.WindowSettings;

internal sealed class ExceptionDialogWindowSettingsViewModelMappingProfile : Profile
{
    public ExceptionDialogWindowSettingsViewModelMappingProfile()
    {
        CreateMap<IExceptionDialogWindowSettingsViewModelInitializerModel, IExceptionDialogWindowSettingsViewModel>()
            .IncludeBase<IDialogWindowSettingsViewModelInitializerModel, IDialogWindowSettingsViewModel>();
    }
}