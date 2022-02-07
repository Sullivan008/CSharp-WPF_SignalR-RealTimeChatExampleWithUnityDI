using Application.Client.Windows.Core.ViewModels.WindowSettings.Initializer.Models.Interfaces;
using Application.Client.Windows.Core.ViewModels.WindowSettings.Interfaces;

namespace Application.Client.Windows.Core.ViewModels.WindowSettings.Initializer.Interfaces;

public interface IWindowSettingsViewModelInitializer<in TWindowSettingsViewModel, in TWindowSettingsViewModelInitializerModel> where TWindowSettingsViewModel : IWindowSettingsViewModel
                                                                                                                               where TWindowSettingsViewModelInitializerModel : IWindowSettingsViewModelInitializerModel
{
    public void Initialize(TWindowSettingsViewModel windowSettingsViewModel, TWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel);
}