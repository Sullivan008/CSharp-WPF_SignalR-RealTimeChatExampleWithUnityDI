using SullyTech.Wpf.Windows.Core.ViewModels.Window;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindow;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindowSettings;

namespace SullyTech.Wpf.Windows.Simple.ViewModels.SimpleWindow;

public class SimpleWindowViewModel<TSimpleWindowSettingsViewModel> : WindowViewModel<TSimpleWindowSettingsViewModel>, ISimpleWindowViewModel
    where TSimpleWindowSettingsViewModel : ISimpleWindowSettingsViewModel, new()
{
    public SimpleWindowViewModel(TSimpleWindowSettingsViewModel settings) : base(settings)
    { }
}
