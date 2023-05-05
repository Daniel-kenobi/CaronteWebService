using Barsa.Commoms;
using Barsa.Interfaces;
using MediatR;

namespace Tartaro.Application.Mediators.User
{
    public class GetUserQuery : IRequest<CommomMediatorResponse<List<Data.Entities.User>>>, IPaginatedRequest
    {
        public int? UserId { get; set; }
        public int Page { get; set; } = 1;
        public int Fetch { get; set; } = 50;
    }
}
