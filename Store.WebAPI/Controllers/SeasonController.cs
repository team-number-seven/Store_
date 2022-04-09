using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.SeasonItemQueries.GetAllSeasons;

namespace Store.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("Store/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ILogger<SeasonController> _logger;
        private readonly IMediator _mediator;

        public SeasonController(IMediator mediator, ILogger<SeasonController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllSeasonItem()
        {
            var response = await _mediator.Send(new GetAllSeasonsQuery());
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(GetAllSeasonItem), User?.FindFirstValue("Id")));

            return StatusCode((int) response.StatusCode, response);
        }
    }
}