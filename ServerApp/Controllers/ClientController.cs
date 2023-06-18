using Caronte.Commons.Modules.Querys;
using Caronte.Domain.Client;
using Microsoft.AspNetCore.Mvc;

namespace Tartaro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("GetClient")]
        public async Task<IActionResult> GetClient([FromBody] GetClientQuery getClientQuery)
        {
           return Ok(_clientService.GetClient(getClientQuery));
        }
    }
}
