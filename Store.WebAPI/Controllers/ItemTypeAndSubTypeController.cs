using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.ItemTypeQueries.GetAllTypesAndSubTypes;

namespace Store.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("Store/[controller]")]
    [ApiController]
    public class ItemTypeAndSubTypeController : ControllerBase
    {
        private readonly ILogger<ItemTypeAndSubTypeController> _logger;
        private readonly IMediator _mediator;

        public ItemTypeAndSubTypeController(IMediator mediator, ILogger<ItemTypeAndSubTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllItemTypeAndSubType()
        {
            var response = await _mediator.Send(new GetAllTypesAndSubTypesQuery());
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(GetAllItemTypeAndSubType),
                User?.FindFirstValue("Id")));

            return StatusCode((int) response.StatusCode, response);
        }
    }
}