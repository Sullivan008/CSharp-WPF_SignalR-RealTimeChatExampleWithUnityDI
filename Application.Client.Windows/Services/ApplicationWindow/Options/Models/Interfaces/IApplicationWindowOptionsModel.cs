using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models.Interfaces;

namespace Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models.Interfaces;

public interface IApplicationWindowOptionsModel
{
    public Type WindowType { get; }

    public Type WindowViewModelType { get; }

    public Type WindowViewModelInitializerModelType { get; }

    public IApplicationWindowViewModelInitializerModel WindowViewModelInitializerModel { get; }
}