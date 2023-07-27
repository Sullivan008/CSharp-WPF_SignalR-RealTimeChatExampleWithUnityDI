using AutoMapper;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Mapping.Profiles.WindowSettings;

internal sealed class ExceptionDialogWindowSettingsViewModelMappingProfile : Profile
{
    public ExceptionDialogWindowSettingsViewModelMappingProfile()
    {
        CreateMap<IExceptionDialogWindowSettingsViewModelInitializerModel, IExceptionDialogWindowSettingsViewModel>()
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title));
    }
}