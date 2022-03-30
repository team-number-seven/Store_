using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
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
            return Ok();
        }


        [HttpGet]
        [Route("Image")]
        public async Task<IActionResult> ImageTest()
        {
            Response.Headers.Add("___test", "___pavel");
            var file_path = @"C:\Users\Pavel\Desktop\ga.jpeg";
            var file_type = "image/jpeg";
            var file_name = "test.jpeg";
            byte[] mas = System.IO.File.ReadAllBytes(file_path);
            IList<FileContentResult> list = new List<FileContentResult> { new FileContentResult(mas,file_type)};
            return Ok(list);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Tesst([FromForm] ItemCreateDTO item)
        {
            var response = await _mediator.Send(new CommandCreateItem(item));
            return StatusCode((int) response.StatusCode, response);
        }
    }
}