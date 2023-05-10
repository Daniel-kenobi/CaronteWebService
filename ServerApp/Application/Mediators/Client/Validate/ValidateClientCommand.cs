using Barsa.Commons;
using Barsa.Models.Client;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.Client.Validate
{
    public class ValidateClientCommand : IRequest<CommonResponse>
    {
        public ClientModel ClientInformation { get; set; } = null!;
    }
}
