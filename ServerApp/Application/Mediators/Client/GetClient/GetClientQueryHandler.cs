using AutoMapper;
using Barsa.Abstracts;
using Barsa.Commons;
using Barsa.Models.Client;
using Barsa.Models.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tartaro.Data;

namespace Tartaro.ServerApp.Application.Mediators.Client.GetClient
{
    public class GetClientQueryHandler : Pagination<Data.Entities.Client> ,IRequestHandler<GetClientQuery, CommonResponse<List<ClientModel>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetClientQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommonResponse<List<ClientModel>>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<ClientModel>>();

            try
            {
                var query = AddPagination(_context.Clients.AsQueryable<Data.Entities.Client>(), request);
                response.ResponseObject = _mapper.Map<List<ClientModel>>(await query.ToListAsync(cancellationToken: cancellationToken));
            }
            catch (Exception ex)
            {
                response.AddErrors(new Errors(ErrorType.BadRequest, ex?.InnerException.Message ?? ex?.Message, new List<Exception>() { ex }));
            }

            return response;
        }
    }
}
