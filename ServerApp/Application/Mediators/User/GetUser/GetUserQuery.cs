﻿using Barsa.Commons;
using Barsa.Interfaces;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.User.GetUser
{
    public class GetUserQuery : IRequest<CommonResponse<List<Data.Entities.User>>>, IPaginatedRequest
    {
        public int? UserId { get; set; }
        public int Page { get; set; } = 1;
        public int Fetch { get; set; } = 50;
    }
}