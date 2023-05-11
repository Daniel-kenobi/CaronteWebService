using AutoMapper;
using Barsa.Commons;
using Barsa.Models.Client;
using Barsa.Models.Errors;
using Barsa.Models.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tartaro.Configurations.Authentication;
using Tartaro.Data;

namespace Tartaro.ServerApp.Application.Mediators.User.Login
{
    public class LoginQueryHandler : HandleJWT, IRequestHandler<LoginQuery, CommonResponse<string>>
    {
        private readonly ApplicationDbContext _dbContext;
        public LoginQueryHandler(ApplicationDbContext dbContext, IMapper mapper, IOptions<JWTAppSettings> jwtModel) : base(jwtModel)
        {
            _dbContext = dbContext;
        }

        public async Task<CommonResponse<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<string>();

            try
            {
                response.ResponseObject = await HandleUser(request.Client);
            }
            catch (Exception ex)
            {
                response.AddErrors(new Errors(ErrorType.NotFound, ex?.InnerException?.Message ?? ex?.Message, new List<Exception>() { ex }));
            }

            return response;
        }

        private async Task<string> HandleUser(UserLoginModel user)
        {
            var encryptedPassword = MD5Hash.Generate(user.Password);

            if (await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == user.Username && x.Password == encryptedPassword) is not null)
                return GenerateToken(user);

            throw new Exception("User not found!");
        }
    }
}
