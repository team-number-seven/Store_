using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.SizeTypeItemQueries.GetAllSizeTypeItems;

namespace Store.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("Store/[controller]")]
    [ApiController]
    public class SizeTypeItemController : ControllerBase
    {
        private readonly ILogger<SizeTypeItemController> _logger;
        private readonly IMediator _mediator;

        public SizeTypeItemController(IMediator mediator, ILogger<SizeTypeItemController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllSizes()
        {
            var response = await _mediator.Send(new QueryGetAllSizesTypeItems());
            _logger.LogInformation(LoggerMessages.DoneMessage("GetAllSizes", User?.FindFirstValue("Id")));

            return StatusCode((int) response.StatusCode, response);
        }
    }
}