using Barsa.Commons;
using Barsa.Models.Errors;
using Caronte.Infra.Repository;
using MediatR;
using Tartaro.Data;
using UserEntity = Caronte.Infra.Repository.Database.Entities.User;

namespace Tartaro.ServerApp.Application.Mediators.User.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, CommonResponse<List<UserEntity>>>
    {
        private readonly IRepository<UserEntity> _repository;
        public GetUserQueryHandler(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<CommonResponse<List<UserEntity>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<List<UserEntity>>();

            try
            {
                response.ResponseObject = (await _repository.GetAll(request)).ToList();
            }
            catch (Exception ex)
            {
                response.AddErrors(new Errors(ErrorType.Unspecified, ex?.InnerException?.Message ?? ex.Message, new List<Exception>() { ex }));
            }

            return response;
        }
    }
}
