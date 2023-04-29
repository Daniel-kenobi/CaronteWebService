using AutoMapper;
using Barsa.CommomResponses;
using Barsa.Models.CreateClientUser;
using Barsa.Models.JWTAppSettingsModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tartaro.Configurations;
using Tartaro.Data;

namespace Tartaro.Application.Mediators.Login
{
    public class LoginQueryHandler : HandleJWT, IRequestHandler<LoginQuery, CommomMediatorResponse<string>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public LoginQueryHandler(ApplicationDbContext dbContext, IMapper mapper, IOptions<JWTAppSettings> jwtModel) : base(jwtModel)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CommomMediatorResponse<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new CommomMediatorResponse<string>();

            try
            {
                response.ResponseObject = await HandleUser(request.Client);
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        private async Task<string> HandleUser(ClientUserModel user)
        {
            if (!await UserExists(user))
                await CreateUser(user);

            return GenerateToken(user);
        }

        private async Task<bool> UserExists(ClientUserModel user)
        {
            return (await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == user.Username && x.OSVersion == user.OSVersion) is not null);
        }

        private async Task CreateUser(ClientUserModel user)
        {
            var userEntity = MapUserModelToEntity(user);
            await _dbContext.Users.AddAsync(userEntity);
        }

        private Data.Entities.User MapUserModelToEntity(ClientUserModel user)
        {
            return _mapper.Map<Data.Entities.User>(user);
        }
    }
}
