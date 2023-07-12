using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializers.Window.Interfaces;

public interface IWindowViewModelInitializer<in TIWindowViewModel, in TIWindowViewModelInitializerModel>
    where TIWindowViewModel : IWindowViewModel
    where TIWindowViewModelInitializerModel : IWindowViewModelInitializerModel
{
    public void Initialize(TIWindowViewModel windowViewModel, TIWindowViewModelInitializerModel windowViewModelInitializerModel);
}