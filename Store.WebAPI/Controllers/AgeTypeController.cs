using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.AgeTypeItemQueries.GetAllAgeTypeItem;

namespace Store.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("Store/[controller]")]
    [ApiController]
    public class AgeTypeController : ControllerBase
    {
        private readonly ILogger<AgeTypeController> _logger;
        private readonly IMediator _mediator;

        public AgeTypeController(IMediator mediator, ILogger<AgeTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> GetAllAgeTypeItem()
        {
            var response = await _mediator.Send(new QueryGetAllAgeTypeItem());
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(GetAllAgeTypeItem), User?.FindFirstValue("id")));

            return StatusCode((int) response.StatusCode, response);
        }
    }
}