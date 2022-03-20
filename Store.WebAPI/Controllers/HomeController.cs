using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Commands.UserCommands;
using Store.BusinessLogic.Queries.CountryQueries;
using Store.BusinessLogic.Queries.UserQueries;

namespace Store.WebAPI.Controllers
{
    /// <summary>
    /// TEST CONTROLLER
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;


        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CreateUser.Command command)
            => Ok(await _mediator.Send(command));


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Get(GetUserByName.Query query)
        {
            var response = await _mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCountries(GetAllCountries.Query query)
        {
            var response = await _mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
    }
}