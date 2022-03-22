using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Commands.GenderCommands.CreateGender;
using Store.BusinessLogic.Queries.GenderQueries.GetAllGenders;
using Store.BusinessLogic.Queries.GenderQueries.GetGenderById;

namespace Store.WebAPI.Controllers
{
    [Authorize(Policy = "Manager")]
    [Route("[controller]")]
    [Controller]
    public class GenderController : Controller
    {
        private readonly IMediator _mediator;

        public GenderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateGender(CommandCreateGender request)
        {
            var response = await _mediator.Send(request);
            return StatusCode((int) response.StatusCode, response);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAllGenders(QueryAllGenders request)
        {
            var response = await _mediator.Send(request);
            return StatusCode((int) response.StatusCode, response);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetGender(QueryGenderById request)
        {
            var response = await _mediator.Send(request);
            return StatusCode((int) response.StatusCode, response);
        }
    }
}