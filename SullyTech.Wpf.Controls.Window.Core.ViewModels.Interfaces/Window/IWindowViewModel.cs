using System.Windows.Input;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.Window;

public interface IWindowViewModel
{
    public string WindowId { get; set; }

    public IWindowSettingsViewModel Settings { get; }

    public IPresenter Presenter { get; set; }

    public ICommand LoadedCommand { get; set; }

    public ICommand ClosingCommand { get; set; }

    public Task OnBeforeLoadAsync();

    public Task OnAfterLoadAsync();

    public Task OnDestroyAsync();
}