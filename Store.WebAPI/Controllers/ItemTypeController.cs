﻿using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.ItemTypeQueries.GetAllTypeAndSubType;

namespace Store.WebAPI.Controllers
{
    [Route("Store/[controller]")]
    [ApiController]
    public class ItemTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ItemTypeController> _logger;

        public ItemTypeController(IMediator mediator,ILogger<ItemTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllItemTypeAndSubType()
        {
            var response = await _mediator.Send(new QueryGetAllTypeAndSubType());
            _logger.LogInformation(MHFL.Done("GetAllItemTypeAndSubType",User.FindFirstValue("Id")));
            return StatusCode((int) response.StatusCode, response);
        }
    }
}
