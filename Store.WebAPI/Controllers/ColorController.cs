﻿using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Queries.ColorQueries.GetAllColors;

namespace Store.WebAPI.Controllers
{
    [Authorize(Policy = "Manager")]
    [Route("Store/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ColorController> _logger;

        public ColorController(IMediator mediator,ILogger<ColorController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllColors([FromQuery] QueryGetAllColors request)
        {
            _logger.LogInformation($"[{DateTime.Now}]The GetAllColors method is called");
            var response = await _mediator.Send(request);
            return StatusCode((int) response.StatusCode, response);
        }
    }
}
