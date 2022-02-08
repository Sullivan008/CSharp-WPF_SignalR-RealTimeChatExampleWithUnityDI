using System.Reflection;
using Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter;

public class ContentPresenterService : IContentPresenterService
{
    private readonly IServiceProvider _serviceProvider;

    public ContentPresenterService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IContentPresenterViewModel GetContentPresenterViewModel(Type contentPresenterViewModelType, ICurrentWindowService currentWindowService)
    {
        Type contentPresenterViewModelFactoryType = typeof(Func<,>)
            .MakeGenericType(typeof(ICurrentWindowService), contentPresenterViewModelType);

        Func<ICurrentWindowService, IContentPresenterViewModel> contentPresenterViewModelFactory =
            (Func<ICurrentWindowService, IContentPresenterViewModel>)_serviceProvider.GetRequiredService(contentPresenterViewModelFactoryType);

        return contentPresenterViewModelFactory(currentWindowService);
    }

    public void InitializeContentPresenterViewModel(IContentPresenterViewModel contentPresenterViewModel, IContentPresenterViewModelInitializerModel contentPresenterViewModelInitializerModel)
    {
        Type contentPresenterViewModelType = contentPresenterViewModel.GetType();
        Type contentPresenterViewModelInitializerModelType = contentPresenterViewModelInitializerModel.GetType();

        Type contentPresenterViewModelInitializerType = typeof(IContentPresenterViewModelInitializer<,>)
            .MakeGenericType(contentPresenterViewModelType, contentPresenterViewModelInitializerModelType);

        MethodInfo contentPresenterViewModelInitializerInitializeMethodInfo = contentPresenterViewModelInitializerType
            .GetMethods()
            .Single();

        object contentPresenterViewModelInitializer =
            _serviceProvider.GetRequiredService(contentPresenterViewModelInitializerType);

        contentPresenterViewModelInitializerInitializeMethodInfo
            .Invoke(contentPresenterViewModelInitializer, new object[] { contentPresenterViewModel, contentPresenterViewModelInitializerModel });
    }
}