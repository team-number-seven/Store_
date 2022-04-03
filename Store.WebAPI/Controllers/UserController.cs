using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.UserQueries.LoginUser;
using Store.BusinessLogic.Queries.UserQueries.RefreshTokens;

namespace Store.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("Store/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> Login([FromHeader] QueryLoginUser request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{MHFL.Done("Login")}");
            return StatusCode((int) response.StatusCode, response);
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> CreateUser([FromHeader] CommandCreateUser request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{MHFL.Done("CreateUser")}");
            return StatusCode((int) response.StatusCode, response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] QueryRefreshTokens request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{MHFL.Done("RefreshToken")}");
            return StatusCode((int)response.StatusCode, response);
        }
    }
}