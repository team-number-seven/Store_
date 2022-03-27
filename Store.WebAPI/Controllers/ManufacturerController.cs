using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Commands.ManufacturerCommands.CreateManufacturer;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.ManufacturerQueries.GetAllManufacturer;

namespace Store.WebAPI.Controllers
{
    [Authorize(Policy = "Manager")]
    [Route("Store/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ManufacturerController> _logger;

        public ManufacturerController(IMediator mediator,ILogger<ManufacturerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromBody] CommandCreateManufacturer manufacturer)
        {
            var response = await _mediator.Send(manufacturer);
            _logger.LogInformation(MHFL.Done("Create",User.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllManufacturer()
        {
            var response = await _mediator.Send(new QueryGetAllManufacturer());
            _logger.LogInformation(MHFL.Done("GetAllManufacturer", User.FindFirstValue("Id")));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
