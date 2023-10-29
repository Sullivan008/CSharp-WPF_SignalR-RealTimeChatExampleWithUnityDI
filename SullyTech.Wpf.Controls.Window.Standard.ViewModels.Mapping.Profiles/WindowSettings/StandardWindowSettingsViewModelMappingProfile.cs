using AutoMapper;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Standard.ViewModels.Mapping.Profiles.WindowSettings;

public class StandardWindowSettingsViewModelMappingProfile : Profile
{
    public StandardWindowSettingsViewModelMappingProfile()
    {
        CreateMap<IStandardWindowSettingsViewModelInitializerModel, IStandardWindowSettingsViewModel>()
            .IncludeBase<IWindowSettingsViewModelInitializerModel, IWindowSettingsViewModel>();
    }
}