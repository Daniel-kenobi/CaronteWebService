using AutoMapper;
using Barsa.Commons;
using Barsa.Models.Client;
using Barsa.Models.Errors;
using Barsa.Modules.Data;
using Caronte.Infra.Repository;
using Caronte.Infra.Repository.Database.Interfaces;
using ClientEntity =  Caronte.Infra.Repository.Database.Entities.Client;
using MediatR;
using Caronte.Infra.Mapping;

namespace Tartaro.ServerApp.Application.Mediators.Client.GetClient
{
    public class GetClientQueryHandler : Pagination<ClientEntity>, IRequestHandler<GetClientQuery, CommonResponse<List<ClientModel>>>
    {
        private readonly IRepository<ClientEntity> _clientRepository;
        private readonly IDefaultMapper _defaultMapper;
        public GetClientQueryHandler(IRepository<ClientEntity> clientRepository, IDefaultMapper defaultMapper)
        {
            _clientRepository = clientRepository;
            _defaultMapper = defaultMapper;
        }

        public async Task<CommonResponse<List<ClientModel>>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<ClientModel>>();

            try
            {
                var allClients = await _clientRepository.GetAll(request);
                var clientModels = _defaultMapper.Map<List<ClientModel>>(allClients);
            }
            catch (Exception ex)
            {
                response.AddErrors(new Errors(ErrorType.BadRequest, ex?.InnerException?.Message ?? ex.Message, new List<Exception>() { ex }));
            }

            return response;
        }
    }
}
