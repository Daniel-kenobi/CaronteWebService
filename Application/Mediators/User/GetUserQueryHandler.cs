using Barsa.Abstracts;
using Barsa.CommomResponses;
using Barsa.Models.Enums;
using Barsa.Models.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tartaro.Data;

namespace Tartaro.Application.Mediators.User
{
    public class GetUserQueryHandler : Pagination<Data.Entities.User>, IRequestHandler<GetUserQuery, CommomMediatorResponse<List<Data.Entities.User>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetUserQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommomMediatorResponse<List<Data.Entities.User>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new CommomMediatorResponse<List<Data.Entities.User>>();

            try
            {
                IQueryable<Data.Entities.User> query = _dbContext.Users;

                if ((request?.UserId ?? 0) > 0)
                    query = query.Where(x => x.UserId == request.UserId);

                if (IsPaginatedRequest(request))
                    query = AddPagination(query, request);

                response.ResponseObject = await query.ToListAsync(cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                response.AddErrors(new MediatorErrors(ErrorType.Unspecified, ex?.InnerException?.Message ?? ex?.Message, new List<Exception>() { ex }));
            }

            return response;
        }
    }
}
