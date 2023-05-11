using Barsa.Commons;
using Barsa.Models.Client;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.Client.PublishCommand
{
    public class PublishUserCommand : IRequest<CommonResponse>
    {
        public ClientCommand UserCommand { get; set; }
    }
}
