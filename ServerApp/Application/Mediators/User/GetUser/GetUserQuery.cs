using Barsa.Commons;
using Caronte.Infra.Repository.Database.Interfaces;
using MediatR;
using UserEntity = Caronte.Infra.Repository.Database.Entities.User;

namespace Tartaro.ServerApp.Application.Mediators.User.GetUser
{
    public class GetUserQuery : IRequest<CommonResponse<List<UserEntity>>>, IPaginatedRequest
    {
        public int? UserId { get; set; }
        public int Page { get; set; } = 1;
        public int Fetch { get; set; } = 50;
    }
}
