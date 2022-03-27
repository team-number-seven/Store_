using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Commands.GenderCommands.CreateGender;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.GenderQueries.GetAllGenders;
using Store.BusinessLogic.Queries.GenderQueries.GetGenderById;

namespace Store.WebAPI.Controllers
{
    [Authorize(Policy = "Manager")]
    [Route("[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GenderController> _logger;

        public GenderController(IMediator mediator,ILogger<GenderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateGender(CommandCreateGender request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation(MHFL.Done("CreateGender", User?.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAllGenders()
        {
            var response = await _mediator.Send(new QueryAllGenders());
            _logger.LogInformation(MHFL.Done("GetAllGenders", User?.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetGender(QueryGenderById request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation(MHFL.Done("GetGender", User.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }
    }
}