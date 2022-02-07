using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.Window.Interfaces;
using Application.Client.Windows.Core.Services.WindowService.Options.Models;

namespace Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models;

public class ApplicationWindowOptionsModel<TApplicationWindow, TApplicationWindowViewModel, TApplicationWindowViewModelInitializerModel> : 
    WindowOptionsModel<TApplicationWindow, TApplicationWindowViewModel, TApplicationWindowViewModelInitializerModel>, IApplicationWindowOptionsModel where TApplicationWindow : IApplicationWindow
                                                                                                                                                     where TApplicationWindowViewModel : IApplicationWindowViewModel
                                                                                                                                                     where TApplicationWindowViewModelInitializerModel : IApplicationWindowViewModelInitializerModel
{ }