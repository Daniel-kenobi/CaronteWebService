﻿using Barsa.Models.User;
using Barsa.Commons;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.User.Login
{
    public class LoginQuery : IRequest<CommonResponse<string>>
    {
        public UserLoginModel Client { get; set; }
    }
}