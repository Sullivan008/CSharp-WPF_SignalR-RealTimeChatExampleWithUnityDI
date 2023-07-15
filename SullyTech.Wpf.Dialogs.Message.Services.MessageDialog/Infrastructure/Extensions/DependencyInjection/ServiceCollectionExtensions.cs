﻿using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Services.MessageDialog.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Services.MessageDialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogService(this IServiceCollection @this)
    {
        @this.AddScoped<IMessageDialogService, MessageDialogService>();
    }
}