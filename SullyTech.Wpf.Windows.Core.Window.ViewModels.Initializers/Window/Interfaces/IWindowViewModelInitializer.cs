using SullyTech.Wpf.Windows.Core.Window.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Windows.Core.Window.ViewModels.Initializers.Window.Interfaces;

public interface IWindowViewModelInitializer<in TIWindowViewModel, in TIWindowViewModelInitializerModel>
    where TIWindowViewModel : IWindowViewModel
    where TIWindowViewModelInitializerModel : IWindowViewModelInitializerModel
{
    public void Initialize(TIWindowViewModel windowViewModel, TIWindowViewModelInitializerModel windowViewModelInitializerModel);
}