using Caronte.Commons.Commons;
using Caronte.Commons.Models.Client;
using Caronte.Infra.Repository.Database.Interfaces;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.Client.GetClient
{
    public class GetClientQuery : IRequest<CommonResponse<List<ClientModel>>>, IPaginatedRequest
    {
        public int Page { get; set; } = 1;
        public int Fetch { get; set; } = 50;
    }
}
