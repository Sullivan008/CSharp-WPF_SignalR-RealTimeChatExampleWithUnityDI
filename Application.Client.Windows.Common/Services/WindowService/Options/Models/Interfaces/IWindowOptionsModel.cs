using Application.Client.Windows.Core.ViewModels.Window.Initializer.Models.Interfaces;

namespace Application.Client.Windows.Core.Services.WindowService.Options.Models.Interfaces;

public interface IWindowOptionsModel
{
    public Type WindowType { get; }

    public Type WindowViewModelType { get; }

    public Type WindowViewModelInitializerModelType { get; }

    public IWindowViewModelInitializerModel WindowViewModelInitializerModel { get; }
}