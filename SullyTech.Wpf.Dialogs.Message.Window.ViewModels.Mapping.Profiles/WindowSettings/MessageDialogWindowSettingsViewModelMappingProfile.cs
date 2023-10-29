using AutoMapper;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Mapping.Profiles.WindowSettings;

internal sealed class MessageDialogWindowSettingsViewModelMappingProfile : Profile
{
    public MessageDialogWindowSettingsViewModelMappingProfile()
    {
        CreateMap<IMessageDialogWindowSettingsViewModelInitializerModel, IMessageDialogWindowSettingsViewModel>()
            .IncludeBase<IDialogWindowSettingsViewModelInitializerModel, IDialogWindowSettingsViewModel>();
    }
}