using Application.Client.Windows.ApplicationWindow.Core.ViewModels.ApplicationWindow.Initializers.Models.Interfaces;

namespace Application.Client.Windows.ApplicationWindow.Core.Services.ApplicationWindow.Options.Models.Interfaces;

public interface IApplicationWindowShowOptionsModel
{
    internal Type WindowType { get; }

    internal Type WindowViewModelType { get; }

    internal IApplicationWindowViewModelInitializerModel WindowViewModelInitializerModel { get; }
}