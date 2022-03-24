using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Queries.CountryQueries.GetAllCountries;

namespace Store.WebAPI.Controllers
{
    /// <summary>
    ///     TEST CONTROLLER
    /// </summary>
    [Controller]
    [Route("Store/[controller]")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;


        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CommandCreateUser command)
        {
            return Ok(await _mediator.Send(command));
        }


        [Authorize(Policy = "Administrator")]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCountries(QueryAllCountries queryAllCountries)
        {
            var response = await _mediator.Send(queryAllCountries);
            return response is null ? NotFound() : Ok(response);
        }
    }
}