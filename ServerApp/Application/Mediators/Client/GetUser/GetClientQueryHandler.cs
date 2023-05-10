using AutoMapper;
using Barsa.Abstracts;
using Barsa.Commoms;
using Barsa.Models.ClientInformation;
using Barsa.Models.Enums;
using Barsa.Models.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tartaro.Data;

namespace Tartaro.ServerApp.Application.Mediators.Client.GetUser
{
    public class GetClientQueryHandler : Pagination<Data.Entities.Client> ,IRequestHandler<GetClientQuery, CommomResponse<List<ClientModel>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetClientQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommomResponse<List<ClientModel>>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var response = new CommomResponse<List<ClientModel>>();

            try
            {
                var query = AddPagination(_context.Clients.AsQueryable<Data.Entities.Client>(), request);
                response.ResponseObject = _mapper.Map<List<ClientModel>>(await query.ToListAsync(cancellationToken: cancellationToken));
            }
            catch (Exception ex)
            {
                response.AddErrors(new MediatorErrors(ErrorType.BadRequest, ex?.InnerException.Message ?? ex?.Message, new List<Exception>() { ex }));
            }

            return response;
        }
    }
}
