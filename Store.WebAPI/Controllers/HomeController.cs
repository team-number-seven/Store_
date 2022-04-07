using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common.Extensions;
using Store.BusinessLogic.Queries.CountryQueries.GetAllCountries;
using Store.BusinessLogic.Services.EmailService;
using Store.DAL.Entities;

namespace Store.WebAPI.Controllers
{
    /// <summary>
    ///     TEST CONTROLLER
    /// </summary>
    [ApiController]
    [Route("Store/[controller]")]
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;

        public HomeController(IMediator mediator,IEmailService emailService,UserManager<User> userManager)
        {
            _mediator = mediator;
            _emailService = emailService;
            _userManager = userManager;
            return;
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

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> google()
        {
            var userId = "cf5c47b2-9000-4124-8232-d5ff6597d2d2";
            string tokenConfirmation = await _userManager.GenerateEmailConfirmationTokenAsync(userId);


            var url = Url.Action(nameof(VerifyEmail), "Home", new {userId = userId, tokenConfirmation = tokenConfirmation},
                Request.Scheme, Request.Host.ToString());
            var d = Request.Scheme;
            var k = Request.Host.ToString();
            
            var urlAccept =
                $@"https://localhost:5001/Store/Home/VerifyEmail?userId={userId}&tokenConfirmation={tokenConfirmation}";
            await _emailService.SendEmailAsync("pavell.urusov8@gmail.com", "pavel", "confirm", urlAccept + "  \n" + url);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail(string userId, string tokenConfirmation)
        {
            var user = await _userManager.FindByIdAsync("cf5c47b2-9000-4124-8232-d5ff6597d2d2");
            if (user == null) return BadRequest();
            var result = await _userManager.ConfirmEmailAsync(user, tokenConfirmation);

            if (result.Succeeded)
            {
                return Ok("Succeeded");
            }

            return BadRequest();
        }
    }
}