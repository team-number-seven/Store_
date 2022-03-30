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
    [Authorize(Policy = "Administrator")]
    [Route("Store/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly ILogger<GenderController> _logger;
        private readonly IMediator _mediator;

        public GenderController(IMediator mediator, ILogger<GenderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateGender(CommandCreateGender request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation(MHFL.Done("CreateGender", User?.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }

        [AllowAnonymous]
        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> GetAllGenders()
        {
            var response = await _mediator.Send(new QueryAllGenders());
            _logger.LogInformation(MHFL.Done("GetAllGenders", User?.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> GetGenderById(QueryGenderById request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation(MHFL.Done("GetGenderById", User?.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }
    }
}