namespace Application.Client.Windows.Windows.ApplicationWindow.Interfaces;

public interface IApplicationWindowOptions
{
    public Type WindowType { get; }

    public Type WindowViewModelType { get; }

    public Type WindowViewModelInitializerModelType { get; }

    public IApplicationWindowViewModelInitializerModel WindowViewModelInitializerModel { get; }
}