using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData.SubInterfaces;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.ValidatablePresenterData.SubInterfaces;

public interface IValidatablePresenterDataSubViewModel : IPresenterDataSubViewModel
{
    public bool IsValid { get; }

    public Task OnEnableValidationAsync();
}