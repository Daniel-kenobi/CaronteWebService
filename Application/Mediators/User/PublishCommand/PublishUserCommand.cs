using Barsa.Commoms;
using Barsa.Models.User;
using MediatR;

namespace Tartaro.Application.Mediators.User.PublishCommand
{
    public class PublishUserCommand : IRequest<CommomResponse>
    {
        public UserCommand UserCommand { get; set; }
    }
}
