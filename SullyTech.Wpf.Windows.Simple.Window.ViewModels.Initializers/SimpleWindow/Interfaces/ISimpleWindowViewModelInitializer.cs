using SullyTech.Wpf.Windows.Core.Window.ViewModels.Initializers.Window.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Initializers.SimpleWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Interfaces.SimpleWindow;

namespace SullyTech.Wpf.Windows.Simple.Window.ViewModels.Initializers.SimpleWindow.Interfaces;

public interface ISimpleWindowViewModelInitializer<in TISimpleWindowViewModel, in TISimpleWindowViewModelInitializerModel> :
    IWindowViewModelInitializer<TISimpleWindowViewModel, TISimpleWindowViewModelInitializerModel>
        where TISimpleWindowViewModel : ISimpleWindowViewModel
        where TISimpleWindowViewModelInitializerModel : ISimpleWindowViewModelInitializerModel
{ }