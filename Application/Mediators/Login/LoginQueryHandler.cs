using AutoMapper;
using Barsa.Commoms;
using Barsa.Models.User;
using Barsa.Models.JWTAppSettingsModel;
using Barsa.Models.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tartaro.Configurations;
using Tartaro.Data;

namespace Tartaro.Application.Mediators.Login
{
    public class LoginQueryHandler : HandleJWT, IRequestHandler<LoginQuery, CommomResponse<string>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public LoginQueryHandler(ApplicationDbContext dbContext, IMapper mapper, IOptions<JWTAppSettings> jwtModel) : base(jwtModel)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CommomResponse<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new CommomResponse<string>();

            try
            {
                response.ResponseObject = await HandleUser(request.Client);
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        private async Task<string> HandleUser(Barsa.Models.User.UserModel user)
        {
            if (!await UserExists(user))
                await CreateUser(user);

            return GenerateToken(user);
        }

        private async Task<bool> UserExists(UserModel user)
        {
            return (await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == user.Username && x.OSVersion == user.OSVersion) is not null);
        }

        private async Task CreateUser(UserModel user)
        {
            var userEntity = MapUserModelToEntity(user);
            await _dbContext.Users.AddAsync(userEntity);
        }

        private Data.Entities.User MapUserModelToEntity(UserModel user)
        {
            return _mapper.Map<Data.Entities.User>(user);
        }
    }
}
