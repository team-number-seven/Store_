using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Queries.CountryQueries.GetAllCountries;

namespace Store.WebAPI.Controllers
{
    /// <summary>
    ///     TEST CONTROLLER
    /// </summary>
    [Controller]
    [Route("Store/[controller]")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;


        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CommandCreateUser command)
        {
            return Ok(await _mediator.Send(command));
        }


        [Authorize(Policy = "user")]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCountries(QueryAllCountries queryAllCountries)
        {
            var response = await _mediator.Send(queryAllCountries);
            return response is null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            var size = files.Sum(f => f.Length);
            foreach (var file in files)
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(@"D:\Projects\GitHub\Store\Shop.DAL\Images\", file.Name + ".jpg");
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

            return Ok(new {count = files.Count, size});
        }
    }
}