using CaronteLib.Models.UserLogin;
using CaronteWebService.Responses.Login;
using MediatR;

namespace CaronteWebService.Requests.Login
{
    public class UserLoginRequest : IRequest<UserLoginResponse>
    {
        public UserLoginModel UserLoginCredentials { get; set; }
    }
}
