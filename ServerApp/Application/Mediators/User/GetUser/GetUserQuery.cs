using Barsa.Commons;
using Caronte.Infra.Repository.Database.Interfaces;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.User.GetUser
{
    public class GetUserQuery : IRequest<CommonResponse<List<User>>>, IPaginatedRequest
    {
        public int? UserId { get; set; }
        public int Page { get; set; } = 1;
        public int Fetch { get; set; } = 50;
    }
}
