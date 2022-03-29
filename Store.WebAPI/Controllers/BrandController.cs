using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
    public class BrandController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BrandController> _logger;

        public BrandController(IMediator mediator,ILogger<BrandController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllBrands()
        {
            var response = await _mediator.Send(new QueryGetAllBrands());
            _logger.LogInformation(MHFL.Done("GetAllGenders",User?.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }
    }
}
