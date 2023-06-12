using Barsa.Commons;
using Barsa.Models.Errors;
using Barsa.Modules.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tartaro.Data;

namespace Tartaro.ServerApp.Application.Mediators.User.GetUser
{
    public class GetUserQueryHandler : Pagination<Data.Entities.User>, IRequestHandler<GetUserQuery, CommonResponse<List<Data.Entities.User>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetUserQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommonResponse<List<Data.Entities.User>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<Data.Entities.User>>();

            try
            {
                IQueryable<Data.Entities.User> query = _dbContext.Users;

                if ((request?.UserId ?? 0) > 0)
                    query = query.Where(x => x.UserId == request.UserId);

                if (IsPaginatedRequest(request))
                    query = AddPaginationToQuery(query, request);

                response.ResponseObject = await query.ToListAsync(cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                response.AddErrors(new Errors(ErrorType.Unspecified, ex?.InnerException?.Message ?? ex?.Message, new List<Exception>() { ex }));
            }

            return response;
        }
    }
}
