using Barsa.Models.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tartaro.ServerApp.Application.Mediators.User.GetUser;
using Tartaro.ServerApp.Application.Mediators.User.Login;

namespace Tartaro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel clientUserModel)
        {
            var response = await _mediator.Send(new LoginQuery() { Client = clientUserModel });

            if (response.IsSucessFull)
                return Ok(response.ResponseObject);

            return NotFound(response.Errors);
        }

        [HttpPost("GetUsers")]
        public async Task<IActionResult> GetUsers([FromBody] GetUserQuery query)
        {
            var response = await _mediator.Send(query);

            if(response.IsSucessFull)
                return Ok(response.ResponseObject); 

            return BadRequest(response.Errors);
        }
    }
}