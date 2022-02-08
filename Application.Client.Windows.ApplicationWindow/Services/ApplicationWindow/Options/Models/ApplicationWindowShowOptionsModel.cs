using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.Window.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models;

public class ApplicationWindowShowOptionsModel<TApplicationWindow, TApplicationWindowViewModel, TApplicationWindowViewModelInitializerModel> : IApplicationWindowShowOptionsModel
    where TApplicationWindow : IApplicationWindow
    where TApplicationWindowViewModel : IApplicationWindowViewModel
    where TApplicationWindowViewModelInitializerModel : IApplicationWindowViewModelInitializerModel
{
    public Type WindowType => typeof(TApplicationWindow);

    public Type WindowViewModelType => typeof(TApplicationWindowViewModel);

    public Type WindowViewModelInitializerModelType => typeof(TApplicationWindowViewModelInitializerModel);

    private readonly IApplicationWindowViewModelInitializerModel? _windowViewModelInitializerModel;
    public IApplicationWindowViewModelInitializerModel WindowViewModelInitializerModel
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