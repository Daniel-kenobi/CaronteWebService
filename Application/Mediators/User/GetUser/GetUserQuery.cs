using Barsa.Commoms;
using Barsa.Interfaces;
using MediatR;

namespace Tartaro.Application.Mediators.User.GetUser
{
    public class GetUserQuery : IRequest<CommomResponse<List<Data.Entities.User>>>, IPaginatedRequest
    {
        public int? UserId { get; set; }
        public int Page { get; set; } = 1;
        public int Fetch { get; set; } = 50;
    }
}
