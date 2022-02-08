using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.Services.CurrentWindowService.Abstractions;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow;

public class CurrentNavigationWindowService : CurrentWindowService, ICurrentNavigationWindowService
{
    private readonly IContentPresenterService _contentPresenterService;

    public CurrentNavigationWindowService(INavigationWindow navigationWindow, IContentPresenterService contentPresenterService) : base(navigationWindow)
    {
        _contentPresenterService = contentPresenterService;
    }

    public void NavigateContentPresenter(IContentPresenterNavigateOptions contentPresenterNavigateOptions)
    {
        IContentPresenterViewModel contentPresenterViewModel = 
            _contentPresenterService.GetContentPresenterViewModel(contentPresenterNavigateOptions.ContentPresenterViewModelType, this);

        if (contentPresenterNavigateOptions.HasInitializeData)
        {
            _contentPresenterService.InitializeContentPresenterViewModel(contentPresenterViewModel, contentPresenterNavigateOptions.ContentPresenterViewModelInitializerModel!);
        }
    }
}