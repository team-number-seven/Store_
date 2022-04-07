using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Commands.ItemCommands.ItemCreate;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Item;
using Store.BusinessLogic.Queries.ItemQueries.GetByFilter;
using Store.BusinessLogic.Queries.ItemQueries.GetById;

namespace Store.WebAPI.Controllers
{
    [Authorize(Policy = "Manager")]
    [Route("Store/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator, ILogger<ItemController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [AllowAnonymous]
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ItemCreateDto request)
        {
            var response = await _mediator.Send(new CommandCreateItem(request));
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Create), User?.FindFirstValue("Id")));

            return StatusCode((int) response.StatusCode, response);
        }

        [AllowAnonymous]
        [Route("GetByFilter")]
        [HttpGet]
        public async Task<IActionResult> GetItemByQuery([FromQuery] ItemFilterQueryDto request)
        {
            var response = await _mediator.Send(new QueryItemFilter(request));
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(GetItemByQuery), User?.FindFirstValue("Id")));

            return StatusCode((int) response.StatusCode, response);
        }

        [AllowAnonymous]
        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] QueryGetItemById request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(GetById), User?.FindFirstValue("Id")));

            return StatusCode((int) response.StatusCode, response);
        }
    }
}