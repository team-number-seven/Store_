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
    [Authorize(Policy = "Manager")]
    [Route("Store/[controller]")]
    [ApiController]
    public class SizeTypeItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SizeTypeItemController> _logger;

        public SizeTypeItemController(IMediator mediator,ILogger<SizeTypeItemController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllSizes(QueryGetAllSizesTypeItems request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation(MHFL.Done("GetAllSizes", User?.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }
    }
}
