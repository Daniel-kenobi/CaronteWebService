using CaronteLib.Models.UserLogin;
using CaronteWebService.Requests.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CaronteWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserLoginController(IMediator mediator)
        {
            _mediator = _mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userLoginModel)
        {
            try
            {
                var response = _mediator.Send(new UserLoginRequest() { });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.Message ?? ex?.Message);
            }
        }
    }
}