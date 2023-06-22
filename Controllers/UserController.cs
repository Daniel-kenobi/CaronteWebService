using Caronte.Domain.Models.User;
using Caronte.Domain.Querys.User.GetUser;
using Caronte.Domain.Querys.User.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Caronte.Web.Controllers
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
            var response = await _mediator.Send(new LoginQuery() { LoginModel = clientUserModel });

            if (response.IsSucessFull)
                return Ok(response.ResponseObject);

            return Unauthorized(response.Errors);
        }

        [HttpPost("GetUsers")]
        public async Task<IActionResult> GetUsers([FromBody] GetUserQuery query)
        {
            var response = await _mediator.Send(query);

            if (response.IsSucessFull)
                return Ok(response.ResponseObject);

            return BadRequest(response.Errors);
        }
    }
}