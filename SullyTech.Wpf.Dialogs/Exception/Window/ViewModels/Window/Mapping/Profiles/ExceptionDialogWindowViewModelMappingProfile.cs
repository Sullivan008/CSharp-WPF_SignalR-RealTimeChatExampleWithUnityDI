using AutoMapper;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window.Initializers.Models;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window.Initializers.Models;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window.Mapping.Profiles;

internal sealed class ExceptionDialogWindowViewModelMappingProfile : Profile
{
    public ExceptionDialogWindowViewModelMappingProfile()
    {
        CreateMap<ExceptionDialogWindowViewModelInitializerModel, ExceptionDialogWindowViewModel>()
            .IncludeBase<DialogWindowViewModelInitializerModel, DialogWindowViewModel>();
    }
}