using Barsa.Commoms;
using Barsa.Models.ClientInformation;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.Client.Validate
{
    public class ValidateClientCommand : IRequest<CommomResponse>
    {
        public ClientModel ClientInformation { get; set; } = null!;
    }
}
