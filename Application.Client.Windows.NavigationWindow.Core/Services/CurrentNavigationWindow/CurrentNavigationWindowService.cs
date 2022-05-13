using Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.Services.CurrentWindowService.Abstractions;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.Window.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Options.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow;

public class CurrentNavigationWindowService : CurrentWindowService, ICurrentNavigationWindowService
{
    private readonly IContentPresenterService _contentPresenterService;

    public CurrentNavigationWindowService(INavigationWindow navigationWindow, IContentPresenterService contentPresenterService) : base(navigationWindow)
    {
        _contentPresenterService = contentPresenterService;
    }

    public void NavigateTo(IContentPresenterNavigateOptions contentPresenterNavigateOptions)
    {
        IContentPresenterViewModel contentPresenterViewModel =
            _contentPresenterService.GetContentPresenterViewModel(contentPresenterNavigateOptions.ContentPresenterViewModelType, this);

        if (contentPresenterNavigateOptions.HasInitializeData)
        {
            _contentPresenterService.InitializeContentPresenterViewModel(contentPresenterViewModel, contentPresenterNavigateOptions.ContentPresenterViewModelInitializerModel!);
        }

        ((INavigationWindowViewModel)Window.DataContext).ContentPresenter = contentPresenterViewModel;
    }
}