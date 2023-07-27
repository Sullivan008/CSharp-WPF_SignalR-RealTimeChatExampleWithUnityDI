using AutoMapper;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Mapping.Profiles.PresenterData;

internal sealed class MessageDialogPresenterDataViewModelMappingProfile : Profile
{
    public MessageDialogPresenterDataViewModelMappingProfile()
    {
        CreateMap<IMessageDialogPresenterDataViewModelInitializerModel, IMessageDialogPresenterDataViewModel>()
            .ForMember(dest => dest.Message,
                opt => opt.MapFrom(src => src.Message));
    }
}