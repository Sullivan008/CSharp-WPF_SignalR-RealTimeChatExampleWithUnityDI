using Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Initializers.Abstractions;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Windows.ApplicationWindow.Abstractions.Options;

public abstract class ApplicationWindowOptions<TApplicationWindowViewModelInitializerModel> where TApplicationWindowViewModelInitializerModel : BaseApplicationWindowViewModelInitializerModel
{
    private readonly Func<TApplicationWindowViewModelInitializerModel>? _windowViewModelInitializerModelFactory;
    public Func<TApplicationWindowViewModelInitializerModel> WindowViewModelInitializerModelFactory
    {
        get
        {
            Guard.ThrowIfNull(_windowViewModelInitializerModelFactory, nameof(WindowViewModelInitializerModelFactory));

            return _windowViewModelInitializerModelFactory!;
        }

        init => _windowViewModelInitializerModelFactory = value;
    }
}