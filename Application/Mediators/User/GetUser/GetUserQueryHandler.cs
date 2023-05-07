using Barsa.Abstracts;
using Barsa.Commoms;
using Barsa.Models.Enums;
using Barsa.Models.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tartaro.Data;

namespace Tartaro.Application.Mediators.User.GetUser
{
    public class GetUserQueryHandler : Pagination<Data.Entities.User>, IRequestHandler<GetUserQuery, CommomResponse<List<Data.Entities.User>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetUserQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommomResponse<List<Data.Entities.User>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new CommomResponse<List<Data.Entities.User>>();

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
