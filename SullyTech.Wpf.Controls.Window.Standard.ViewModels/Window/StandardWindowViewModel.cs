using SullyTech.Wpf.Controls.Window.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Standard.ViewModels.Window;

public class StandardWindowViewModel<TIStandardWindowSettingsViewModel> : WindowViewModel<TIStandardWindowSettingsViewModel>, IStandardWindowViewModel
    where TIStandardWindowSettingsViewModel : IStandardWindowSettingsViewModel
{
    public StandardWindowViewModel(TIStandardWindowSettingsViewModel settings) : base(settings)
    { }
}
