﻿using Barsa.Models.CreateClientUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tartaro.Application.Mediators.Login;
using Tartaro.Application.Mediators.User;

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
        public async Task<IActionResult> Login([FromBody] ClientUserModel clientUserModel)
        {
            var response = await _mediator.Send(new LoginQuery() { Client = clientUserModel });

            if (response.IsSucessFull)
                return Ok(response.ResponseObject);

            return BadRequest(response.Errors);
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