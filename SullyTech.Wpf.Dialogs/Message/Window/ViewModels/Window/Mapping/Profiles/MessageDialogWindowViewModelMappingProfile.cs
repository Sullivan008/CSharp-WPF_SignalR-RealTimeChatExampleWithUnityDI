using AutoMapper;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window.Initializers.Models;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window.Initializers.Models;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window.Mapping.Profiles;

internal sealed class MessageDialogWindowViewModelMappingProfile : Profile
{
    public MessageDialogWindowViewModelMappingProfile()
    {
        CreateMap<MessageDialogWindowViewModelInitializerModel, MessageDialogWindowViewModel>()
            .IncludeBase<DialogWindowViewModelInitializerModel, DialogWindowViewModel>();
    }
}