using AutoMapper;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Mapping.Profiles.WindowSettings;

public class DialogWindowSettingsViewModelMappingProfile : Profile
{
    public DialogWindowSettingsViewModelMappingProfile()
    {
        CreateMap<IDialogWindowSettingsViewModelInitializerModel, IDialogWindowSettingsViewModel>()
            .IncludeBase<IWindowSettingsViewModelInitializerModel, IWindowSettingsViewModel>();
    }
}