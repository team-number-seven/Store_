using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Queries.SizeTypeItemQueries.GetAllSizeTypeItems;

namespace Store.WebAPI.Controllers
{
    [Authorize(Policy = "Manager")]
    [Route("Store/[controller]")]
    [ApiController]
    public class SizeTypeItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SizeTypeItemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllSizes([FromQuery] QueryGetAllSizesTypeItems request)
        {
            var response = await _mediator.Send(request);
            return StatusCode((int) response.StatusCode, response);
        }
    }
}
