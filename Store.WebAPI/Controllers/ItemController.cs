using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Commands.ItemCommands.ItemCreate;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Queries.ItemQueries.GetById;

namespace Store.WebAPI.Controllers
{
    [Authorize(Policy = "Manager")]
    [Route("Store/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IMediator mediator,ILogger<ItemController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [AllowAnonymous]
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ItemCreateDTO request)
        {
            var response = await _mediator.Send(new CommandCreateItem(request));
            _logger.LogInformation(MHFL.Done("Create",User.FindFirstValue("Ida")));
            return StatusCode((int) response.StatusCode, response);
        }

        [AllowAnonymous]
        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> GetQuery(IFormFile file)
        {


            return Ok();
        }

        [AllowAnonymous]
        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery]QueryGetItemById request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation(MHFL.Done("GetByID",User?.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }

    }
}
