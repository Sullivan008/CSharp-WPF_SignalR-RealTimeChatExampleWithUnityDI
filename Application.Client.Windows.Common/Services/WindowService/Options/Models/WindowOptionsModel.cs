using Application.Client.Windows.Common.Window.Interfaces;
using Application.Client.Windows.Core.Services.WindowService.Options.Models.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window.Initializer.Models.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Core.Services.WindowService.Options.Models;

public class WindowOptionsModel<TWindow, TWindowViewModel, TWindowViewModelInitializerModel> : IWindowOptionsModel where TWindow : IWindow 
                                                                                                                   where TWindowViewModel : IWindowViewModel
                                                                                                                   where TWindowViewModelInitializerModel : IWindowViewModelInitializerModel
{
    public Type WindowType => typeof(TWindow);

    public Type WindowViewModelType => typeof(TWindowViewModel);

    public Type WindowViewModelInitializerModelType => typeof(TWindowViewModelInitializerModel);

    private readonly IWindowViewModelInitializerModel? _windowViewModelInitializerModel;
    public IWindowViewModelInitializerModel WindowViewModelInitializerModel
    {
        get
        {
            Guard.ThrowIfNull(_windowViewModelInitializerModel, nameof(WindowViewModelInitializerModel));
            return _windowViewModelInitializerModel!;
        }

        init
        {
            Guard.ThrowIfNull(value, nameof(WindowViewModelInitializerModel));
            _windowViewModelInitializerModel = value;
        }
    }
}