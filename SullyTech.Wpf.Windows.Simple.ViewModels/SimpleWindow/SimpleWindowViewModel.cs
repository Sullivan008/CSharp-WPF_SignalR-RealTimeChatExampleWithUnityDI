using SullyTech.Wpf.Windows.Core.ViewModels.Window;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindow;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindowSettings;

namespace SullyTech.Wpf.Windows.Simple.ViewModels.SimpleWindow;

public class SimpleWindowViewModel<TISimpleWindowSettingsViewModel> : WindowViewModel<TISimpleWindowSettingsViewModel>, ISimpleWindowViewModel
    where TISimpleWindowSettingsViewModel : ISimpleWindowSettingsViewModel, new()
{
    public SimpleWindowViewModel(TISimpleWindowSettingsViewModel settings) : base(settings)
    { }
}
