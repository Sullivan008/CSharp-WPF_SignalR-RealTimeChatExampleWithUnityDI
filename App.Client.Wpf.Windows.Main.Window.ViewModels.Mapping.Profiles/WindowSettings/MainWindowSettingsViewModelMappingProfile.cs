using App.Client.Wpf.Windows.Main.Window.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using AutoMapper;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.WindowSettings;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Mapping.Profiles.WindowSettings;

internal sealed class MainWindowSettingsViewModelMappingProfile : Profile
{
    public MainWindowSettingsViewModelMappingProfile()
    {
        CreateMap<IMainWindowSettingsViewModelInitializerModel, IMainWindowSettingsViewModel>()
            .IncludeBase<IStandardWindowSettingsViewModelInitializerModel, IStandardWindowSettingsViewModel>();
    }
}