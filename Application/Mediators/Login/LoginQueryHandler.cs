using Barsa.CommomResponses;
using MediatR;

namespace Tartaro.Application.Mediators.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, CommomMediatorResponse<string>>
    {
        public LoginQueryHandler()
        {
            
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
    }
}
