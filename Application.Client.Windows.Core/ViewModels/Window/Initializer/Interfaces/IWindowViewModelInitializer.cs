using Application.Client.Windows.Core.ViewModels.Window.Initializer.Models.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window.Interfaces;

namespace Application.Client.Windows.Core.ViewModels.Window.Initializer.Interfaces;

public interface IWindowViewModelInitializer<in TWindowViewModel, in TWindowViewModelInitializerModel> 
    where TWindowViewModel : IWindowViewModel
    where TWindowViewModelInitializerModel : IWindowViewModelInitializerModel
{
    public void Initialize(TWindowViewModel windowViewModel, TWindowViewModelInitializerModel windowViewModelInitializerModel);
}