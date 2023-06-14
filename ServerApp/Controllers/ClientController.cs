using Barsa.Models.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tartaro.ServerApp.Application.Mediators.Client.GetClient;

namespace Tartaro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /*[HttpPost("SendCommand")]
        public async Task<IActionResult> SendCommand([FromBody] ClientCommand userCommand)
        {
            var response = await _mediator.Send(new PublishUserCommand() { UserCommand = userCommand });

            if (response.IsSucessFull)
                return NoContent();

            return BadRequest(response.Errors);
        }

        [HttpPost("Validate")]
        public async Task<IActionResult> Validate([FromBody] ClientModel clientInformation)
        {
            var response = await _mediator.Send(new ValidateClientCommand() { ClientInformation = clientInformation });

            if (response.IsSucessFull)
                return NoContent();

            return BadRequest(response.Errors);
        }*/

        [HttpPost("GetClient")]
        public async Task<IActionResult> GetClient([FromBody] GetClientQuery getClientQuery)
        {
            var response = await _mediator.Send(getClientQuery);

            if (response.IsSucessFull)
                return Ok(response.ResponseObject);

            return BadRequest(response.Errors);
        }
    }
}
