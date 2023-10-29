using AutoMapper;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Core.ViewModels.Mapping.Profiles.WindowSettings;

internal sealed class WindowSettingsViewModelMappingProfile : Profile
{
    public WindowSettingsViewModelMappingProfile()
    {
        CreateMap<IWindowSettingsViewModelInitializerModel, IWindowSettingsViewModel>()
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Width,
                opt => opt.MapFrom(src => src.Width))
            .ForMember(dest => dest.Height,
                opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.Top,
                opt => opt.MapFrom(src => src.Top))
            .ForMember(dest => dest.Bottom,
                opt => opt.MapFrom(src => src.Bottom))
            .ForMember(dest => dest.Left,
                opt => opt.MapFrom(src => src.Left))
            .ForMember(dest => dest.Right,
                opt => opt.MapFrom(src => src.Right));
    }
}