using AutoMapper;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window.Initializers.Models;

namespace SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window.Mapping.Profiles;

internal sealed class StandardWindowViewModelMappingProfile : Profile
{
    public StandardWindowViewModelMappingProfile()
    {
        CreateMap<StandardWindowViewModelInitializerModel, StandardWindowViewModel>()
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Height,
                opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.Width,
                opt => opt.MapFrom(src => src.Width))
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