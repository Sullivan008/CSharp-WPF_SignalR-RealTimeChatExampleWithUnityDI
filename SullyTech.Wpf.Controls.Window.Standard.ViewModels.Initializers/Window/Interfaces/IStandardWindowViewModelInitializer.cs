using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializers.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.Window.Interfaces;

public interface IStandardWindowViewModelInitializer<in TIStandardWindowViewModel, in TIStandardWindowViewModelInitializerModel> :
    IWindowViewModelInitializer<TIStandardWindowViewModel, TIStandardWindowViewModelInitializerModel>
        where TIStandardWindowViewModel : IStandardWindowViewModel
        where TIStandardWindowViewModelInitializerModel : IStandardWindowViewModelInitializerModel
{ }