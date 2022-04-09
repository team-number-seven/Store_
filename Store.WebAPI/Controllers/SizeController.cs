using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.SizeQueries.GetAllSizes;

namespace Store.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("Store/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ILogger<SizeController> _logger;
        private readonly IMediator _mediator;

        public SizeController(IMediator mediator, ILogger<SizeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllSizes()
        {
            var response = await _mediator.Send(new GetAllSizesQuery());
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(GetAllSizes), User?.FindFirstValue("Id")));

            return StatusCode((int) response.StatusCode, response);
        }
    }
}