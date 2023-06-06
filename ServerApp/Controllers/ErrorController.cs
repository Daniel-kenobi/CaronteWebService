using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Tartaro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ErrorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> ReportError([FromBody] Exception exception)
        {
            var response = await _mediator.Send(new object());
            return Ok();
        }
    }
}
