using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.CountryQueries.GetAllCountries;

namespace Store.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("Store/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator, ILogger<CountryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllCountries()
        {
            var response = await _mediator.Send(new GetAllCountriesQuery());
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(GetAllCountries), User?.FindFirstValue("id")));

            return StatusCode((int) response.StatusCode, response);
        }
    }
}