using AutoMapper;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.Presenter;
using DestButtonType = SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Enums.Presenter.ButtonType;
using DestIconType = SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Enums.Presenter.IconType;
using SrcIconType = SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Enums.Presenter.IconType;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Mapping.Profiles.Presenter;

internal sealed class MessageDialogPresenterViewModelMappingProfile : Profile
{
    public MessageDialogPresenterViewModelMappingProfile()
    {
        CreateMap<IMessageDialogPresenterViewModelInitializerModel, IMessageDialogPresenterViewModel>()
            .ForMember(dest => dest.ButtonType,
                opt => opt.MapFrom(src => (DestButtonType)src.ButtonType))
            .ForMember(dest => dest.IconType,
                opt => opt.MapFrom(src => MapIconType(src.IconType)));
    }

    private static DestIconType MapIconType(SrcIconType? iconType)
    {
        return iconType.HasValue == false ? DestIconType.None : (DestIconType)iconType.Value;
    }
}