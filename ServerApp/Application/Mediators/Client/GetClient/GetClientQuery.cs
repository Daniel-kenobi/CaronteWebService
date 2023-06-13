using Barsa.Commons;
using Barsa.Models.Client;
using Barsa.Modules.Data;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.Client.GetClient
{
    public class GetClientQuery : IRequest<CommonResponse<List<ClientModel>>>, IPaginatedMediatorRequest
    {
        public int Page { get; set; } = 1;
        public int Fetch { get; set; } = 50;
    }
}
