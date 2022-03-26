using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Common.Interfaces;
using Store.BusinessLogic.Common.UserModels;
using Store.BusinessLogic.Queries.UserQueries.LoginUser;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.WebAPI.Controllers
{
    [Route("Store/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody]QueryLoginUser userLogin)
        {
            var response = await _mediator.Send(userLogin);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CommandCreateUser command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}   