﻿using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.DialogWindow.Models.CustomDialogWindowResult.Interfaces;

namespace Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;

public interface ICurrentDialogWindowService : ICurrentWindowService
{
    public void SetCustomDialogWindowResult(ICustomDialogWindowResultModel customDialogWindowResult);
}