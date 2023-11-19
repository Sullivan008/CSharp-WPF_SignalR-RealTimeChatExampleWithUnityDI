using AutoMapper;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Mapping.Profiles.PresenterData;

internal sealed class ExceptionDialogPresenterDataViewModelMappingProfile : Profile
{
    public ExceptionDialogPresenterDataViewModelMappingProfile()
    {
        CreateMap<IExceptionDialogPresenterDataViewModelInitializerModel, IExceptionDialogPresenterDataViewModel>()
            .ForMember(dest => dest.Message,
                opt => opt.MapFrom(src => src.Message))
            .ForMember(dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.FullName!))
            .ForMember(dest => dest.StackTrace,
                opt => opt.MapFrom(src => MapStackTrace(src.StackTrace)))
            .ForMember(dest => dest.InnerException,
                opt => opt.MapFrom(src => MapInnerException(src.InnerException)));
    }

    private static string MapStackTrace(string? stackTrace)
    {
        if (string.IsNullOrWhiteSpace(stackTrace))
        {
            return "-";
        }

        return stackTrace;
    }

    private static string MapInnerException(System.Exception? innerException)
    {
        if (innerException is null || 
            string.IsNullOrWhiteSpace(innerException.ToString()))
        {
            return "-";
        }

        return innerException.ToString();
    }
}