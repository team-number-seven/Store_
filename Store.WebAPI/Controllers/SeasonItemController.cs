using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.SeasonItemQueries.GetAllSeasonItem;

namespace Store.WebAPI.Controllers
{
    [Authorize(Policy = "Manager")]
    [Route("Store/[controller]")]
    [ApiController]
    public class SeasonItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SeasonItemController> _logger;

        public SeasonItemController(IMediator mediator,ILogger<SeasonItemController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllSeasonItem()
        {
            var response = await _mediator.Send(new QueryGetAllSeasonItem());
            _logger.LogInformation(MHFL.Done("GetAllSeasonItem",User.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }
    }
}
