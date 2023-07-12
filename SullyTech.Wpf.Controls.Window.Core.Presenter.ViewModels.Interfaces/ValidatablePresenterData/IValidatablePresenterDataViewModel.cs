using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.ValidatablePresenterData;

public interface IValidatablePresenterDataViewModel : IPresenterDataViewModel
{
    public bool IsValid { get; }

    public Task OnEnableValidationAsync();
}