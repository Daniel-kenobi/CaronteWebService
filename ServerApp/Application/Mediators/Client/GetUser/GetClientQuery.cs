using Barsa.Commoms;
using Barsa.Interfaces;
using Barsa.Models.ClientInformation;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.Client.GetUser
{
    public class GetClientQuery : IRequest<CommomResponse<List<ClientModel>>>, IPaginatedRequest
    {
        public int Page { get; set; } = 1;
        public int Fetch { get; set; } = 50;
    }
}
