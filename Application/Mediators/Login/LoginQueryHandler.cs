using Barsa.CommomResponses;
using MediatR;
using Tartaro.Data;

namespace Tartaro.Application.Mediators.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, CommomMediatorResponse<string>>
    {
        private readonly ApplicationDbContext _dbContext;
        public LoginQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<CommomMediatorResponse<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new CommomMediatorResponse<string>("");

            try
            {

            }
            catch (Exception ex)
            {

            }

            return Task.FromResult(response);
        }

        private bool ValidateUser(LoginQuery request)
        {
            var validated = false;

            if (request.Client is null)
                throw new ArgumentNullException("Credenciais nulas.");

            return validated;
        }
    }
}
