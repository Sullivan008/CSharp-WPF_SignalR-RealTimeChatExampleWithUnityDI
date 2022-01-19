using Application.Client.Windows.Windows.ApplicationWindow.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Windows.ApplicationWindow.Abstractions.Options;

public class ApplicationWindowOptions<TApplicationWindow, TApplicationWindowViewModel, TApplicationWindowViewModelInitializerModel> : IApplicationWindowOptions 
    where TApplicationWindowViewModel : IApplicationWindowViewModel
    where TApplicationWindowViewModelInitializerModel : IApplicationWindowViewModelInitializerModel
{
    private readonly Func<TApplicationWindowViewModelInitializerModel>? _windowViewModelInitializerModelFactory;
    public Func<TApplicationWindowViewModelInitializerModel> WindowViewModelInitializerModelFactory
    {
        init => _windowViewModelInitializerModelFactory = value;
    }

    public Type WindowType => typeof(TApplicationWindow);
    public Type WindowViewModelType => typeof(TApplicationWindowViewModel);
    public Type WindowViewModelInitializerModelType => typeof(TApplicationWindowViewModelInitializerModel);

    private IApplicationWindowViewModelInitializerModel? _windowViewModelInitializerModel;
    public IApplicationWindowViewModelInitializerModel WindowViewModelInitializerModel
    {
        get
        {
            if (_windowViewModelInitializerModel != null)
            {
                return _windowViewModelInitializerModel;
            }

            Guard.ThrowIfNull(_windowViewModelInitializerModelFactory, nameof(WindowViewModelInitializerModelFactory));
            _windowViewModelInitializerModel = _windowViewModelInitializerModelFactory!();

            return _windowViewModelInitializerModel;
        }
    }
}