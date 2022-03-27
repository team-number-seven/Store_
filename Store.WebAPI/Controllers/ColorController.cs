﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
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
        public async Task<IActionResult> GetAllColors([FromBody] QueryGetAllColors request)
        {
           
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{MHFL.Done("GetAllColors", User?.FindFirstValue("Id"))}");
            return StatusCode((int) response.StatusCode, response);
        }
    }
}
