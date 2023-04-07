using CaronteWebService.Responses.Login;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CaronteWebService.Requests.Login
{
    public class UserLoginRequestHandler : IRequestHandler<UserLoginRequest, UserLoginResponse>
    {
        public async Task<UserLoginResponse> Handle(UserLoginRequest request, CancellationToken cancellationToken)
        {
            UserLoginResponse response = new();

			try
			{

			}
			catch (Exception ex)
			{

			}

            return response;
        }
    }
}
