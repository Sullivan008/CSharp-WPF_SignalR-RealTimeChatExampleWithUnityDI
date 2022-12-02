using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Windows.Core.ViewModels.Initializers.Window.Interfaces;

public interface IWindowViewModelInitializer<in TWindowViewModel, in TWindowViewModelInitializerModel>
    where TWindowViewModel : IWindowViewModel
    where TWindowViewModelInitializerModel : IWindowViewModelInitializerModel
{
    public void Initialize(TWindowViewModel windowViewModel, TWindowViewModelInitializerModel windowViewModelInitializerModel);
}