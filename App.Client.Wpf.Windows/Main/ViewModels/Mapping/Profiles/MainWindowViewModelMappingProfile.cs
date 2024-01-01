using App.Client.Wpf.Windows.Main.ViewModels.Initializer.Models;
using AutoMapper;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window.Initializers.Models;

namespace App.Client.Wpf.Windows.Main.ViewModels.Mapping.Profiles;

internal sealed class MainWindowViewModelMappingProfile : Profile
{
    public MainWindowViewModelMappingProfile()
    {
        CreateMap<MainWindowViewModelInitializerModel, MainWindowViewModel>()
            .IncludeBase<StandardWindowViewModelInitializerModel, StandardWindowViewModel>();
    }
}