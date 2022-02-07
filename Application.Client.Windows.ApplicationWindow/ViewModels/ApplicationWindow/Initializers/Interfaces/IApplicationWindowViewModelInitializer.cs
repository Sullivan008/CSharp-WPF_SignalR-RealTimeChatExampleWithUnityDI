using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window.Initializer.Interfaces;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Interfaces;

public interface IApplicationWindowViewModelInitializer<in TApplicationWindowViewModel, in TApplicationWindowViewModelInitializerModel> :
    IWindowViewModelInitializer<TApplicationWindowViewModel, TApplicationWindowViewModelInitializerModel> where TApplicationWindowViewModel : IApplicationWindowViewModel
                                                                                                          where TApplicationWindowViewModelInitializerModel : IApplicationWindowViewModelInitializerModel
{ }