using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Commands.UserCommands.create;
using Store.BusinessLogic.Queries.CountryQueries.getAllCountries;
using Store.BusinessLogic.Queries.UserQueries;
using Store.BusinessLogic.Queries.GenderQueries.getAllGenders;

namespace Store.WebAPI.Controllers
{
    /// <summary>
    /// TEST CONTROLLER
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;


        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CreateUser.Command command)
            => Ok(await _mediator.Send(command));


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Get(GetUserByName.Query query)
        {
            var response = await _mediator.Send(query);
            return response is null ? NotFound() : Ok(response);
        }

        [Authorize(Policy = "user")]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCountries(GetAllCountries.Query query)
        {
            var response = await _mediator.Send(query);
            return response is null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(@"D:\Projects\GitHub\Store\Shop.DAL\Images\", file.Name + ".jpg");
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            return Ok(new {count = files.Count, size});
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetGenders()
        {
            var result = await _mediator.Send(new GetAllGenders.Query());
            return result is null ? NotFound() : Ok(result);
        }
    }
}