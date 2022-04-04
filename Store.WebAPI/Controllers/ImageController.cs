using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Commands.ImageCommand;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Queries.ItemQueries.GetById;

namespace Store.WebAPI.Controllers
{
    [Route("Store/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<ImageController> _logger;
        private readonly IMediator _mediator;

        public ImageController(IMediator mediator, ILogger<ImageController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ImageCreateDto request)
        {
            var item = await _mediator.Send(new QueryGetItemById(request.ItemId)) as ResponseGetItemById;
            var response = await _mediator.Send(new CreateImageCommand(request));
            _logger.LogInformation(MHFL.Done("Create", User?.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }
    }
}