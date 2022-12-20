using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Windows.Core.ViewModels.Initializers.Window.Interfaces;

public interface IWindowViewModelInitializer<in TIWindowViewModel, in TIWindowViewModelInitializerModel>
    where TIWindowViewModel : IWindowViewModel
    where TIWindowViewModelInitializerModel : IWindowViewModelInitializerModel
{
    public void Initialize(TIWindowViewModel windowViewModel, TIWindowViewModelInitializerModel windowViewModelInitializerModel);
}