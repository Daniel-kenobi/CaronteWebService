using Barsa.Commons;
using Barsa.Interfaces;
using Barsa.Models.Client;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.Client.GetUser
{
    public class GetClientQuery : IRequest<CommonResponse<List<ClientModel>>>, IPaginatedRequest
    {
        public int Page { get; set; } = 1;
        public int Fetch { get; set; } = 50;
    }
}
