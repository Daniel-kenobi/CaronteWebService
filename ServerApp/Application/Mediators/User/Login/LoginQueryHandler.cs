using AutoMapper;
using Barsa.Commons;
using Barsa.Models.User;
using Barsa.Models.JWT;
using Barsa.Models.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tartaro.Data;
using Tartaro.Configurations.Authentication;

namespace Tartaro.ServerApp.Application.Mediators.User.Login
{
    public class LoginQueryHandler : HandleJWT, IRequestHandler<LoginQuery, CommonResponse<string>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public LoginQueryHandler(ApplicationDbContext dbContext, IMapper mapper, IOptions<JWTAppSettings> jwtModel) : base(jwtModel)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

            }

            return response;
        }

        private async Task<string> HandleUser(UserLoginModel user)
        {
            if (!await UserExists(user))
                await CreateUser(user);

            return GenerateToken(user);
        }

        private async Task<bool> UserExists(UserLoginModel user)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == user.Username) is not null;
        }

        private async Task CreateUser(UserLoginModel user)
        {
            var userEntity = MapUserModelToEntity(user);
            await _dbContext.Users.AddAsync(userEntity);
        }

        private Data.Entities.User MapUserModelToEntity(UserLoginModel user)
        {
            return _mapper.Map<Data.Entities.User>(user);
        }
    }
}
