using Barsa.Models.CreateClientUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tartaro.Application.Mediators.Login;

namespace Tartaro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] ClientUserModel clientUserModel)
        {
            var response = await _mediator.Send(new LoginQuery() { Client = clientUserModel });


            return Ok();
        }
    }
}