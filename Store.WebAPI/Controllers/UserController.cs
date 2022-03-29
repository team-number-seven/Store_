﻿using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.UserQueries.LoginUser;

namespace Store.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("Store/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator,ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> Login([FromHeader]QueryLoginUser request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{MHFL.Done("Login")}");
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> CreateUser([FromHeader]CommandCreateUser request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{MHFL.Done("CreateUser")}");
            return StatusCode((int)response.StatusCode, response);
        }
    }
}   