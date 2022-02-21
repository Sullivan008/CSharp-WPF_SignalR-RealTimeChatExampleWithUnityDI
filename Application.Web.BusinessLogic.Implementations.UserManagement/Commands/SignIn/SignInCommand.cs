﻿using Application.BusinessLogic.Core.MediatR.Commands.Abstractions;
using Application.BusinessLogic.Modules.UserManagement.Commands.SignIn.RequestModel;
using Application.Common.Utilities.Guard;

namespace Application.BusinessLogic.Modules.UserManagement.Commands.SignIn;

public class SignInCommand : MediatRCommand
{
    public SignInCommandRequestModel RequestModel { get; }

    public SignInCommand(SignInCommandRequestModel requestModel)
    {
        Guard.ThrowIfNull(requestModel, nameof(RequestModel));
        RequestModel = requestModel;
    }
}