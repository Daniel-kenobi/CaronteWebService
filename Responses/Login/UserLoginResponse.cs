using Microsoft.Net.Http.Headers;

namespace CaronteWebService.Responses.Login
{
    public class UserLoginResponse
    {
        public string JWT { get; set; }
        public bool IsSucessfull { get; set; }
    }
}
