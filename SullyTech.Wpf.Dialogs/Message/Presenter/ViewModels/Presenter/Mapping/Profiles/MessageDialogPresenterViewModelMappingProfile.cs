using AutoMapper;
using SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Initializer.Models;
using DestButtonType = SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Enums.ButtonType;
using DestIconType = SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Enums.IconType;
using SrcIconType = SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Initializer.Enums.IconType;

namespace SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Mapping.Profiles;

internal sealed class MessageDialogPresenterViewModelMappingProfile : Profile
{
    public MessageDialogPresenterViewModelMappingProfile()
    {
        CreateMap<MessageDialogPresenterViewModelInitializerModel, MessageDialogPresenterViewModel>()
            .ForMember(dest => dest.Message,
                opt => opt.MapFrom(src => src.Message))
            .ForMember(dest => dest.ButtonType,
                opt => opt.MapFrom(src => (DestButtonType)src.ButtonType))
            .ForMember(dest => dest.IconType,
                opt => opt.MapFrom(src => MapIconType(src.IconType)));
    }

    private static DestIconType MapIconType(SrcIconType? iconType)
    {
        return iconType is not null ? (DestIconType)iconType : DestIconType.None;
    }
}