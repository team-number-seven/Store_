﻿using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.SeasonItemQueries.GetAllSeasonItem;

namespace Store.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("Store/[controller]")]
    [ApiController]
    public class SeasonItemController : ControllerBase
    {
        private readonly ILogger<SeasonItemController> _logger;
        private readonly IMediator _mediator;

        public SeasonItemController(IMediator mediator, ILogger<SeasonItemController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllSeasonItem()
        {
            var response = await _mediator.Send(new QueryGetAllSeasonItem());
            _logger.LogInformation(LoggerMessages.DoneMessage("GetAllSeasonItem", User?.FindFirstValue("Id")));

            return StatusCode((int) response.StatusCode, response);
        }
    }
}