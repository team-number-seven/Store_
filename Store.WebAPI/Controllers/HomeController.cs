using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Commands.ItemCommands.ItemCreate;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Queries.CountryQueries.GetAllCountries;

namespace Store.WebAPI.Controllers
{
    /// <summary>
    ///     TEST CONTROLLER
    /// </summary>
    [ApiController]
    [Route("Store/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;


        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CommandCreateUser request)
        {
            return Ok(await _mediator.Send(request));
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCountries(QueryGetAllCountries request)
        {
            var response = await _mediator.Send(request);
            return response is null ? NotFound() : Ok(response);
        }



        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            string name = file.Name;
            string type = "." + file.ContentType.Split("/").Last();
            using (var stream = System.IO.File.Create(@"D:\Projects\GitHub\Store\Shop.DAL\Images\" + name + type))
            {
                await file.CopyToAsync(stream);
            }
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Tesst([FromForm]ItemCreateDTO item)
        {
            var response = await _mediator.Send(new CommandCreateItem(item));
            return StatusCode((int) response.StatusCode, response);
        }
    }
}