using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Commands.UserCommands;

namespace Store.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;


        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///test method
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Index(CreateUser.Command command)
            => Ok(await _mediator.Send(command));
    }
}
