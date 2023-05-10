using AutoMapper;
using Barsa.Commoms;
using Barsa.Models.ClientInformation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tartaro.Data;

namespace Tartaro.ServerApp.Application.Mediators.Client.Validate
{
    public class ValidateClientCommandHandler : IRequestHandler<ValidateClientCommand, CommomResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public ValidateClientCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<CommomResponse> Handle(ValidateClientCommand request, CancellationToken cancellationToken)
        {
            var response = new CommomResponse();
            var client = request.ClientInformation;

            var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                IQueryable<Data.Entities.Client> query = _dbContext.Clients
                    .Where(x => x.ClientName == client.ClientName
                    && x.ProcessorIdentifier == client.ProcessorIdentifier);

                if (client.Osversion?.Length > 0)
                    query = query.Where(x => x.Osversion == client.Osversion);

                var clientFromDatabase = await query.FirstOrDefaultAsync();

                if (clientFromDatabase is null)
                   MapEntityToModel(await InsertClientOnDatabase(client));

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }

            return response;
        }

        private async Task<Data.Entities.Client> InsertClientOnDatabase(ClientModel client)
        {
            var mappedClient = MapModelToEntity(client);
            await _dbContext.Clients.AddAsync(mappedClient);

            return mappedClient;
        }

        private Data.Entities.Client MapModelToEntity(ClientModel client) =>
            _mapper.Map<Data.Entities.Client>(client);

        private ClientModel MapEntityToModel(Data.Entities.Client client) =>
            _mapper.Map<ClientModel>(client);
    }
}
