﻿using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.Services.WindowService.Interfaces;
using Application.Client.Windows.DialogWindow.Core.Models.CustomDialogWindowResult.Interfaces;
using Application.Client.Windows.DialogWindow.Core.Services.DialogWindow.Options.Models.Interfaces;

namespace Application.Client.Windows.DialogWindow.Core.Services.DialogWindow.Interfaces;

public interface IDialogWindowService : IWindowService
{
    public Task<TCustomDialogWindowResultModel> ShowDialogAsync<TCustomDialogWindowResultModel>(IDialogWindowShowDialogOptionsModel dialogWindowOptions, IContentPresenterLoadOptions contentPresenterLoadOptions)
        where TCustomDialogWindowResultModel : ICustomDialogWindowResultModel;
}