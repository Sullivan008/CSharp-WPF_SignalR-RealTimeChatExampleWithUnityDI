﻿using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData.Initializer.Models;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData.Initializer;

public class ExceptionDialogViewDataViewModelInitializer : IContentPresenterViewDataViewModelInitializer<ExceptionDialogViewDataViewModel, ExceptionDialogViewDataViewModelInitializerModel>
{
    public void Initialize(ExceptionDialogViewDataViewModel contentPresenterViewDataViewModel, ExceptionDialogViewDataViewModelInitializerModel contentPresenterViewDataViewModelInitializerModel)
    {
        contentPresenterViewDataViewModel.Message = contentPresenterViewDataViewModelInitializerModel.Message;
        contentPresenterViewDataViewModel.Type = contentPresenterViewDataViewModelInitializerModel.Type.FullName!;
        contentPresenterViewDataViewModel.StackTrace = contentPresenterViewDataViewModelInitializerModel.StackTrace;
    }
}