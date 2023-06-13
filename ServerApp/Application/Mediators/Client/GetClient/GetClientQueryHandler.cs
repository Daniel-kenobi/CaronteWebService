using AutoMapper;
using Barsa.Commons;
using Barsa.Models.Client;
using Barsa.Models.Errors;
using Barsa.Modules.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tartaro.ServerApp.Application.Mediators.Client.GetClient
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, CommonResponse<List<ClientModel>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPagination<Data.Entities.Client> _pagination;

        public GetClientQueryHandler(ApplicationDbContext context, IMapper mapper, IPagination<Data.Entities.Client> pagination)
        {
            _context = context;
            _mapper = mapper;
            _pagination = pagination;
        }

        public async Task<CommonResponse<List<ClientModel>>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<ClientModel>>();

            try
            {
                var query = _pagination.Paginate(_context.Clients.AsQueryable<Data.Entities.Client>(), request);
                response.ResponseObject = _mapper.Map<List<ClientModel>>(await query.ToListAsync(cancellationToken: cancellationToken));
            }
            catch (Exception ex)
            {
                response.AddErrors(new Errors(ErrorType.BadRequest, ex?.InnerException?.Message ?? ex.Message, new List<Exception>() { ex }));
            }

            return response;
        }
    }
}
