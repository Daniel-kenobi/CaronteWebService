using Barsa.Commons;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.Client.PublishCommand
{
    public class PublishUserCommandHandler : IRequestHandler<PublishUserCommand, CommonResponse>
    {
        public PublishUserCommandHandler()
        {

        }

        public Task<CommonResponse> Handle(PublishUserCommand request, CancellationToken cancellationToken)
        {
            var commomResponse = new CommonResponse();

            try
            {

            }
            catch
            {

            }

            return Task.FromResult(commomResponse);
        }
    }
}
