using SullyTech.Wpf.Windows.Core.Window.ViewModels.Window;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Interfaces.SimpleWindow;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Interfaces.SimpleWindowSettings;

namespace SullyTech.Wpf.Windows.Simple.Window.ViewModels.SimpleWindow;

public class SimpleWindowViewModel<TISimpleWindowSettingsViewModel> : WindowViewModel<TISimpleWindowSettingsViewModel>, ISimpleWindowViewModel
    where TISimpleWindowSettingsViewModel : ISimpleWindowSettingsViewModel, new()
{
    public SimpleWindowViewModel(TISimpleWindowSettingsViewModel settings) : base(settings)
    { }
}
