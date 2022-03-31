using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Commands.ImageCommand;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.WebAPI.Controllers
{
    [Route("Store/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ImageController> _logger;

        public ImageController(IMediator mediator,ILogger<ImageController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ImageCreateDTO request)
        {
            var response = await _mediator.Send(new CreateImageCommand(request));
            _logger.LogInformation(MHFL.Done("Create",User?.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }
    }
}
