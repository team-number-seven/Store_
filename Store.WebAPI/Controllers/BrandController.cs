using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.BrandQueries.GetAllBrands;

namespace Store.WebAPI.Controllers
{
    [ApiController]
    [Route("Store/[controller]")]
    [AllowAnonymous]
    public class BrandController : ControllerBase
    {
        private readonly ILogger<BrandController> _logger;
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator, ILogger<BrandController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllBrands()
        {
            var response = await _mediator.Send(new QueryGetAllBrands());
            _logger.LogInformation(LoggerMessages.DoneMessage("GetAllGenders", User?.FindFirstValue("Id")));

            return StatusCode((int) response.StatusCode, response);
        }
    }
}