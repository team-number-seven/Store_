using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.UserQueries.LoginUser;

namespace Store.WebAPI.Controllers
{
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
        [Route("[action]")]
        public async Task<IActionResult> Login([FromHeader]QueryLoginUser request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{MHFL.Done("Login")}");
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromHeader]CommandCreateUser request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{MHFL.Done("Create")}");
            return StatusCode((int)response.StatusCode, response);
        }
    }
}   