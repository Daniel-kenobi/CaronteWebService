using Barsa.Commoms;
using MediatR;

namespace Tartaro.Application.Mediators.User.PublishCommand
{
    public class PublishUserCommandHandler : IRequestHandler<PublishUserCommand, CommomResponse>
    {
        public PublishUserCommandHandler()
        {
            
        }

        public Task<CommomResponse> Handle(PublishUserCommand request, CancellationToken cancellationToken)
        {
             var commomResponse = new CommomResponse();

            try
            {

            }
            catch (Exception ex)
            {

            }

            return Task.FromResult(commomResponse);
        }
    }
}
