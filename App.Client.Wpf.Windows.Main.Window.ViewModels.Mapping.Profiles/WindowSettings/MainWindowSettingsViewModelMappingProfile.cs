using App.Client.Wpf.Windows.Main.Window.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using AutoMapper;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Mapping.Profiles.WindowSettings;

internal sealed class MainWindowSettingsViewModelMappingProfile : Profile
{
    public MainWindowSettingsViewModelMappingProfile()
    {
        CreateMap<IMainWindowSettingsViewModelInitializerModel, IMainWindowSettingsViewModel>()
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Width,
                opt => opt.MapFrom(src => src.Width))
            .ForMember(dest => dest.Height,
                opt => opt.MapFrom(src => src.Height));
    }
}