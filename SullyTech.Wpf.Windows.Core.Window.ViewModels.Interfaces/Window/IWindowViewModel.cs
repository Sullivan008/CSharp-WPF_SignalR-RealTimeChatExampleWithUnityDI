using System.Windows.Input;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Windows.Core.Window.ViewModels.Interfaces.Window;

public interface IWindowViewModel
{
    public string PresenterWindowId { get; set; }

    public IWindowSettingsViewModel Settings { get; }

    public IPresenterViewModel Presenter { get; set; }
    
    public ICommand CloseWindowCommand { get; set; }

    public Task OnInit();

    public Task OnDestroy();
}