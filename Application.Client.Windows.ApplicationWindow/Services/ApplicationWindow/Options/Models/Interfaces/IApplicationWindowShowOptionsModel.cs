using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models.Interfaces;

namespace Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models.Interfaces;

public interface IApplicationWindowShowOptionsModel
{
    internal Type WindowType { get; }

    internal Type WindowViewModelType { get; }

    internal IApplicationWindowViewModelInitializerModel WindowViewModelInitializerModel { get; }
}